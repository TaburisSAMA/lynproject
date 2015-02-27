<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Clustering Demo</title>
<script	src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAq-ZE2g3HsdIx_TvrRCkfTBR3IWAYz8RJWOauRf02cdleTea_OxSgCdbezrGn3MBxd-tVEXs_xkd6gQ" 	type="text/javascript"></script>
<script
	src="http://gmaps-utility-library.googlecode.com/svn/trunk/labeledmarker/release/src/labeledmarker.js"
	type="text/javascript"></script>
<script src="map_functions.js" type="text/javascript"></script>
<link href="style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
<?php
switch ($_GET['data']) {
    case 'us':
        echo "var centerLatitude = 39, centerLongitude = -99, startZoom = 5, data_url = 'map_data.php?data=us&';";
        break;
    default:
        echo "var centerLatitude = -29, centerLongitude = 132.5, startZoom = 5, data_url = 'map_data.php?';";
}
?>
</script>
</head>
<body class="sidebar-right">
<div id="toolbar">
<h1>Clustering Demo</h1>
<ul id="options">
	<li><a href="http://maksud.byethost24.com">website</a></li>
	<li><a href="http://maksud.iblogger.org">blog</a></li>
</ul>
</div>
<div id="content">
<div id="map-wrapper">
<div id="map"></div>
</div>
<div id="sidebar">
<h2>What is this?</h2>
<p>This is server side Clustering...</p>
</div>
</div>
</body>
</html>