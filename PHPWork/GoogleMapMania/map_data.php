<?php


// This script serves points from MySQL based on a viewport query. The viewport takes the form
// of two parameters: sw and ne, each a comma-separated latlng pair.

$fetch_generations = 5;
$viewport_points_upper_limit = 80;

switch ($_GET['data']) {
	case 'us' :
		$clusters_table = "dams_us_clusters";
		break;
	default :
		$clusters_table = "dams_au_clusters";
}

//require ('../../wp-config.php');

try {
	$dbh = new PDO('mysql:host=localhost;dbname=gdata', 'maksud', '123456');
	$dbh->setAttribute(PDO :: ATTR_ERRMODE, PDO :: ERRMODE_EXCEPTION);
} catch (PDOException $e) {
	print "Error: " . $e->getMessage();
	die();
}

// Firstly, we need to find the smallest cluster that fully encloses the given viewport. This
// approach won't work across the dateline, which is why we need to first yank down the viewport
// to be on one side or the other of it. A more intelligent approach might be to run two separate
// queries, one for each side of the line. That approach still excludes the possibility of any
// clusters straddling the dateline, but that's a whole different issue, since we know already
// that the data doesn't contain anything like this.

list ($latitude_min, $longitude_min) = explode(',', $_GET['sw']);
list ($latitude_max, $longitude_max) = explode(',', $_GET['ne']);

if ($longitude_min > $longitude_max) {
	if (abs($longitude_min) > abs($longitude_max)) {
		$longitude_min = -179.99;
	} else {
		$longitude_max = 179.99;
	}
}

$viewport_query = $dbh->prepare("SELECT * FROM $clusters_table WHERE
  latitude_min <= :latitude_min AND
  latitude_max >= :latitude_max AND
  longitude_min <= :longitude_min AND
  longitude_max >= :longitude_max
  ORDER BY level DESC LIMIT 1");
$viewport_query->bindParam(':latitude_min', $latitude_min);
$viewport_query->bindParam(':latitude_max', $latitude_max);
$viewport_query->bindParam(':longitude_min', $longitude_min);
$viewport_query->bindParam(':longitude_max', $longitude_max);

$viewport_query->execute();

// If we can't find a singular cluster that encloses the whole viewport, we instead
// grab the "max" cluster and work from there.
if ($viewport_query->rowCount() > 0) {
	$parent_cluster = $viewport_query->fetch(PDO :: FETCH_ASSOC);
} else {
	$viewport_query_wide = $dbh->prepare("SELECT * FROM $clusters_table WHERE LEVEL=0 LIMIT 1");
	$viewport_query_wide->execute();
	$parent_cluster = $viewport_query_wide->fetch(PDO :: FETCH_ASSOC);
}

// Now that we know which cluster encloses the viewport, we can fetch all children
// of that view, up to a certain depth. The ordering is important here---we sort first
// by level, and secondarily by the number of children in each node. This is providing
// the order in which the clusters will be expanded: higher-level ones first, and
// within each level, ones that are larger first.
// The exlusion by lat/lng here is a little different than the other one. In this case,
// we only want to eliminate sub-clusters that are *entirely* outside the viewport.
$root_level = $parent_cluster['level'];
$min_level = $root_level + $fetch_generations;
$children_query = $dbh->prepare("SELECT * FROM $clusters_table WHERE
  left_side >= :left AND
  right_side <= :right AND
  level <= :level_min AND NOT (
    latitude_min > :latitude_max OR
    latitude_max < :latitude_min OR
    longitude_min > :longitude_max OR
    longitude_max < :longitude_min
  )
  ORDER BY level ASC, child_count DESC");
$children_query->bindParam(':level_min', $min_level);
$children_query->bindParam(':left', $parent_cluster['left_side']);
$children_query->bindParam(':right', $parent_cluster['right_side']);
$children_query->bindParam(':latitude_min', $latitude_min);
$children_query->bindParam(':latitude_max', $latitude_max);
$children_query->bindParam(':longitude_min', $longitude_min);
$children_query->bindParam(':longitude_max', $longitude_max);

$children_query->execute();

// Now we break up the flat list of fetched ids into an array structure keyed to
// the id, with each cluster containing an array of the ids of its children.
$clusters_by_id = array ();
$root_cluster_id = 0;
while ($this_cluster = $children_query->fetch(PDO :: FETCH_ASSOC)) {
	$this_cluster_id = $this_cluster['id'];
	$this_cluster['children'] = array ();
	$this_cluster['included'] = false;
	$clusters_by_id[$this_cluster_id] = $this_cluster;
	if ($this_cluster['level'] == $root_level) {
		$root_cluster_id = $this_cluster_id;
	} else {
		$clusters_by_id[$this_cluster['parent_id']]['children'][] = $this_cluster_id;
	}
}

//var_dump($clusters_by_id);

// Finally, we have to pick out the ones we want to actually show. The basic process here
// that we start with the base node and then iterate, each time checking if we can expand the
// next cluster while still staying under the ceiling imposed by $viewport_points_upper_limit.

$total = 1;
$clusters_by_id[$root_cluster_id]['included'] = true;

foreach ($clusters_by_id as & $this_cluster) {
	if ($this_cluster['included']) {
		if ($total +count($this_cluster['children']) - 1 <= $viewport_points_upper_limit) {
			if (count($this_cluster['children']) > 0) {
				$total += count($this_cluster['children']) - 1;
				foreach ($this_cluster['children'] as $included_id) {
					$clusters_by_id[$included_id]['included'] = true;
				}
				$this_cluster['included'] = false;
			}
		} else {
			break; // If it doesn't fit, then we're done.
		}
	}
}
unset ($this_cluster); // Required for foreach with reference.

echo "/* " . count($clusters_by_id) . " clusters from SQL, chose " . $total . " for display. */\n";

$items_text = array ();

foreach ($clusters_by_id as $this_cluster) {
	if ($this_cluster['included']) {
		$items_text[] = "[" . $this_cluster['id'] . "," . $this_cluster['latitude'] . "," . $this_cluster['longitude'] . "," . $this_cluster['child_count'] . "]";
	}
}

echo '[' . implode(", ", $items_text) . ']';
?>