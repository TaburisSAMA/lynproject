<?php
set_time_limit(200); // Give ourselves a little more time 
// For the input table, we assume there are fields called latitude and longitude, as well
// as a standard id field.
//$input_table = "dams_au";
$input_table = "geodatatable";
// For the output, we'll generate the table definition and full inserts.
$cluster_table = "dams_au_clusters";
// How much to reduce the set at each level. It's important that this be low so that we get
// lots of variation from zoom level to zoom level.
$mean_child_count = 4;
// Minimimum size before we stop partitioning.
$min_divide_size = 10;
// Unwind bottom-level clusters that fall below a certain size threshold. This is
// implemented at the final stage, pruning nodes that fall below the threshold.
$min_cluster_size = 5;
// Number of times to iterate k-means
$kmeans_iterations = 3;
//require ('../../../wp-config.php');
$query = "SELECT id, latitude, longitude FROM $input_table";
try {
    $dbh = new PDO('mysql:host=localhost;dbname=gdata', 'maksud', '123456');
    $dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $items = $dbh->query($query);
} catch (PDOException $e) {
    print "Error: " . $e->getMessage();
    die();
}
// Start by adding all the items each as its own individual cluster, to level 1, and
// creating a "root" cluster at level 0 for them all to initially belong to.
// The item_id field is a reference to the keys in the actual data table, and only 
// exists for leaf nodes.
$clusters_by_id = array();
$root_id = nextClusterId();
$root_children = array();
foreach ($items as $item) {
    if ($item['latitude'] == "0" && $item['longitude'] == "0") {
        // ignore incomplete rows.
        continue;
    }
    $next_id = nextClusterId();
    $clusters_by_id[$next_id] = array('id' => $next_id , 'latitude' => (float) $item['latitude'] , 'longitude' => (float) $item['longitude'] , 'latitude_min' => (float) $item['latitude'] , 'latitude_max' => (float) $item['latitude'] , 'longitude_min' => (float) $item['longitude'] , 'longitude_max' => (float) $item['longitude'] , 'child_count' => 1 , 'item_id' => $item['id']);
    $root_children[] = $next_id;
}
$clusters_by_id[$root_id] = createCluster($root_id, $root_children);
// Okay, now we have our all-encompassing root node, we run a recursive process that
// subdivides that root node, and for each of its children, further subdivides it if it's
// still larger than the threshold.
function maybeSubdivideCluster ($cluster_id)
{
    global $clusters_by_id, $mean_child_count, $min_cluster_size, $min_divide_size;
    $this_cluster = & $clusters_by_id[$cluster_id];
    if (count($this_cluster['children']) > $min_divide_size) {
        $child_clusters = doClustering($this_cluster['children'], $mean_child_count);
        // Special case. If we only get a single cluster out of doClustering, then merge it with the parent
        // cluster and proceed.
        if (count($child_clusters) == 1) {
            $one_cluster = reset($child_clusters); // grab first and only item.
            $this_cluster['children'] = array_merge($this_cluster['children'], $one_cluster['children']);
        } else {
            $this_cluster['children'] = array();
            // Output of doClustering is an array of entities that each contain
            // id, latitude, longitude, and an array of children ids.
            foreach ($child_clusters as $child_id => $child_cluster) {
                // If one of the generated clusters only has a single child node, or its overall child_count
                // is below the acceptable threshold, then we can discard it and hook the single child directly
                // into the parent.
                $new_cluster = createCluster($child_id, $child_cluster['children']);
                if (count($child_cluster['children']) > 1 && $new_cluster['child_count'] >= $min_cluster_size) {
                    $this_cluster['children'][] = $child_id;
                    $clusters_by_id[$child_id] = $new_cluster;
                    maybeSubdivideCluster($child_id);
                } else {
                    $this_cluster['children'] = array_merge($this_cluster['children'], $new_cluster['children']);
                }
            }
        }
    }
}
maybeSubdivideCluster($root_id);
// Final step is to provide the Left/Right values that will permit quick retrieval of this hierarchical
// structure once it's in SQL. This could just be baked into the recursive subdivision system, but it's
// cleaner to do it separately, since it really is a separate task. We also add in parent_id values, which
// simplify the recreation of the $cluster_by_id structure in the request-time code.
function assign_left_right_recursive ($cluster_id, $parent_id, $level)
{
    static $numbering = 0;
    global $clusters_by_id;
    $this_cluster = & $clusters_by_id[$cluster_id];
    $this_cluster['left'] = ++ $numbering;
    $this_cluster['level'] = $level;
    $this_cluster['parent_id'] = $parent_id;
    if (isset($this_cluster['children'])) {
        foreach ($this_cluster['children'] as $child_cluster_id) {
            assign_left_right_recursive($child_cluster_id, $cluster_id, $level + 1);
        }
    }
    $this_cluster['right'] = ++ $numbering;
}
assign_left_right_recursive($root_id, 0, 0);
// Table creation.
echo "CREATE TABLE $cluster_table (
id INT NOT NULL,
latitude DOUBLE NOT NULL,
longitude DOUBLE NOT NULL,
latitude_min DOUBLE NOT NULL,
longitude_min DOUBLE NOT NULL,
latitude_max DOUBLE NOT NULL,
longitude_max DOUBLE NOT NULL,
child_count INT NOT NULL,
parent_id INT NOT NULL,
left_side INT NOT NULL,
right_side INT NOT NULL,
level INT NOT NULL,

PRIMARY KEY (`id`) ) ENGINE=innodb;\n\n";
echo "INSERT INTO $cluster_table (id, 
latitude, longitude,
latitude_min, longitude_min,
latitude_max, longitude_max,
child_count, parent_id, left_side, right_side, level) VALUES \n";
$first = true;
foreach ($clusters_by_id as $this_cluster) {
    extract($this_cluster);
    if (! $first) {
        echo ",\n";
    }
    echo "($id, $latitude, $longitude, $latitude_min, $longitude_min, $latitude_max, $longitude_max, $child_count, $parent_id, $left, $right, $level)";
    $first = false;
}
// This is a utility function that creates a cluster's data array based on the array of children_ids,
// including calculating its center point and extents.
function createCluster ($new_cluster_id, $children_ids)
{
    global $clusters_by_id;
    $latitude_total = 0;
    $longitude_total = 0;
    $latitude_min = 90;
    $latitude_max = - 90;
    $longitude_min = 180;
    $longitude_max = - 180;
    $child_count = 0;
    foreach ($children_ids as $child_id) {
        $child_cluster = $clusters_by_id[$child_id];
        $latitude_total += $child_cluster['latitude'];
        $longitude_total += $child_cluster['longitude'];
        $latitude_min = min($latitude_min, $child_cluster['latitude_min']);
        $latitude_max = max($latitude_max, $child_cluster['latitude_max']);
        $longitude_min = min($longitude_min, $child_cluster['longitude_min']);
        $longitude_max = max($longitude_max, $child_cluster['longitude_max']);
        $child_count += $child_cluster['child_count'];
    }
    return array('id' => $new_cluster_id , 'latitude' => $latitude_total / count($children_ids) , 'longitude' => $longitude_total / count($children_ids) , 'latitude_min' => $latitude_min , 'latitude_max' => $latitude_max , 'longitude_min' => $longitude_min , 'longitude_max' => $longitude_max , 'child_count' => $child_count , 'children' => $children_ids);
}
/// Helper/clustering functions
function nextClusterId ()
{
    static $next_id = 0;
    return ++ $next_id;
}
function randomScalar ()
{
    return mt_rand(0, 2e9) / 2e9;
}
// Expects array entities both containing latitude and longitude members.
function distanceSquared ($a, $b)
{
    $latitude_delta = $a['latitude'] - $b['latitude'];
    $longitude_delta = $a['longitude'] - $b['longitude'];
    return ($latitude_delta * $latitude_delta + $longitude_delta * $longitude_delta);
}
// This is the heart of k-means++
function chooseSmartCenters ($item_ids, $cluster_count)
{
    global $clusters_by_id;
    $centers = array(); // tuples of array('id' => id, 'latitude' => y, 'longitude' => x), keyed to id.
    $num_local_tries = 2 + round(log($cluster_count));
    // first center is created based on a position chosen randomly from the input data points.
    $random_item_id = $item_ids[array_rand($item_ids)];
    $next_id = nextClusterId();
    $centers[$next_id] = array('id' => $next_id , 'latitude' => $clusters_by_id[$random_item_id]['latitude'] , 'longitude' => $clusters_by_id[$random_item_id]['longitude']);
    // Calculate distance to each of the items
    $closest_distance_squared = array();
    foreach ($item_ids as $id) {
        $closest_distance_squared[$id] = distanceSquared($clusters_by_id[$id], $centers[$next_id]);
    }
    $current_potential = array_sum($closest_distance_squared);
    // Choose remaining centers  
    for ($i = 1; $i < $cluster_count; $i ++) {
        // Repeat multiple trials
        $best_new_potential = - 1;
        $best_new_index = 0;
        // Take multiple stabs each of the successive centers
        for ($j = 0; $j < $num_local_tries; $j ++) {
            $rand_val = randomScalar() * $current_potential;
            foreach ($item_ids as $id_of_potential_center) {
                if ($rand_val <= $closest_distance_squared[$id_of_potential_center]) {
                    break;
                } else {
                    $rand_val -= $closest_distance_squared[$id_of_potential_center];
                }
            }
            // Compute new potential based on index chosen for the new center.
            $new_potential = 0;
            foreach ($item_ids as $id) {
                $new_potential += min(distanceSquared($clusters_by_id[$id], $clusters_by_id[$id_of_potential_center]), $closest_distance_squared[$id]);
            }
            if ($best_new_potential < 0 || $new_potential < $best_new_potential) {
                $best_new_potential = $new_potential;
                $best_new_id = $id_of_potential_center;
            }
        }
        $next_id = nextClusterId();
        $centers[$next_id] = array('id' => $next_id , 'latitude' => $clusters_by_id[$best_new_id]['latitude'] , 'longitude' => $clusters_by_id[$best_new_id]['longitude']);
        $current_potential = $best_new_potential;
        foreach ($item_ids as $id) {
            $closest_distance_squared[$id] = min(distanceSquared($clusters_by_id[$id], $clusters_by_id[$best_new_id]), $closest_distance_squared[$id]);
        }
    }
    return $centers;
}
function assignItemsToNearestCluster ($item_ids, & $clusters)
{
    global $clusters_by_id;
    foreach ($clusters as & $this_cluster) {
        $this_cluster['children'] = array();
    }
    unset($this_cluster);
    foreach ($item_ids as $item_id) {
        $nearest_id = 0;
        $nearest_distance = - 1;
        foreach ($clusters as $cluster_id => $this_cluster) {
            $distance = distanceSquared($clusters_by_id[$item_id], $this_cluster);
            if ($nearest_distance < 0 || $distance < $nearest_distance) {
                $nearest_distance = $distance;
                $nearest_id = $cluster_id;
            }
        }
        $clusters[$nearest_id]['children'][] = $item_id;
    }
    unset($this_item);
    // Remove any clusters that don't have items. I believe this can only really happen if the dataset has multiple points at the exact same
    // latlng. Under these conditions, it's impossible to further subdivide... all items get thrown into the first cluster created, and the
    // others remain empty.
    $cluster_ids = array_keys($clusters);
    foreach ($cluster_ids as $cluster_id) {
        if (count($clusters[$cluster_id]['children']) < 1) {
            unset($clusters[$cluster_id]);
        }
    }
    return $changed;
}
// If any of the clusters doesn't contain any member points, this function removes
// it from the array.
function computeClusterCenters (& $clusters)
{
    global $clusters_by_id;
    foreach ($clusters as & $this_cluster) {
        $count = count($this_cluster['children']);
        if ($count < 1) {
            unset($this_cluster);
            continue;
        }
        $latitude_total = 0;
        $longitude_total = 0;
        foreach ($this_cluster['children'] as $child_cluster_id) {
            $latitude_total += $clusters_by_id[$child_cluster_id]['latitude'];
            $longitude_total += $clusters_by_id[$child_cluster_id]['longitude'];
        }
        $this_cluster['latitude'] = $latitude_total / $count;
        $this_cluster['longitude'] = $longitude_total / $count;
    }
    unset($this_cluster);
}
// Use k-means++ smart selection to pick our starting centers, then ordinary
// k-means to create clusters.
function doClustering ($item_ids, $clusters_to_find)
{
    global $kmeans_iterations;
    $centers = chooseSmartCenters($item_ids, $clusters_to_find);
    assignItemsToNearestCluster($item_ids, $centers);
    // Now that we have the starting centers, we can use those to run the ordinary k-means.
    for ($i = 0; $i < $kmeans_iterations; $i ++) {
        computeClusterCenters($centers);
        if (! assignItemsToNearestCluster($item_ids, $centers))
            break; // returns false if nothing changed.
    }
    return $centers;
}
?>