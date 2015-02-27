<?php
$input_file = "dams_au.txt";
$table_name = "dams_au";
$default_varchar = 64;
$column_mappings = array("longitude" => "longitude_other" , "latitude" => "latitude_other" , "x-coordinate" => "longitude" , "y-coordinate" => "latitude");
$column_excludes = array("z" , "m" , "area" , "perimeter" , "id");
$file_lines = file($input_file);
// Grab the first row and explode it into some column labels.
$labels = explode("\t", trim(strtolower(array_shift($file_lines))));
// Input data to a PHP array.
$data = array();
foreach ($file_lines as $this_line) {
    $fields = explode("\t", $this_line);
    $line_data = array();
    foreach ($labels as $index => $this_label) {
        if (array_key_exists($this_label, $column_mappings)) {
            $this_label = $column_mappings[$this_label];
        }
        if (! in_array($this_label, $column_excludes)) {
            $line_data[$this_label] = $fields[$index];
        }
    }
    $data[] = $line_data;
}
$final_labels = array();
foreach ($labels as $this_label) {
    if (array_key_exists($this_label, $column_mappings)) {
        $this_label = $column_mappings[$this_label];
    }
    if (in_array($this_label, $column_excludes)) {
        continue;
    }
    $final_labels[] = $this_label;
}
// Figure out some column types to use, based on the data in the
// first row of the results.
$sql_columns = array("id INT NOT NULL AUTO_INCREMENT");
foreach ($final_labels as $this_label) {
    $example_data = $data[0][$this_label];
    if (is_numeric($example_data)) {
        if (intval($example_data) == $example_data) {
            $type = "INT";
        } else {
            $type = "DOUBLE";
        }
    } else {
        $type = "VARCHAR($default_varchar)";
    }
    $sql_columns[] = "$this_label $type";
}
echo "CREATE TABLE $table_name (\n" . implode(",\n", $sql_columns) . ",
PRIMARY KEY (`id`) ) ENGINE=innodb;\n\n";
$sql_rows = array();
foreach ($data as $this_row_fields) {
    foreach ($this_row_fields as $index => $field) {
        if (! is_numeric($field)) {
            $this_row_fields[$index] = "'" . addslashes($field) . "'";
        }
    }
    $sql_rows[] = "(" . implode(",", $this_row_fields) . ")";
}
echo "INSERT INTO $table_name (" . implode(", ", $final_labels) . ")\n VALUES " . implode(",\n", $sql_rows);
?>