<?php
require_once ("mysqldb.php");
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Clustering Demo</title>
<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAq-ZE2g3HsdIx_TvrRCkfTBR3IWAYz8RJWOauRf02cdleTea_OxSgCdbezrGn3MBxd-tVEXs_xkd6gQ" type="text/javascript"></script>
<script	src="http://gmaps-utility-library.googlecode.com/svn/trunk/markermanager/release/src/markermanager.js"></script>
<script
	src="http://gmaps-utility-library.googlecode.com/svn/trunk/extlargemapcontrol/1.0/src/extlargemapcontrol.js"></script>

<script src="ClusterMarker.js" type="text/javascript"></script>
<link href="style.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
	var map;
	var mgr;
	var geocoder;
	var clickedLink = false;
	var markers = new Array();
	var cluster;

	var aaTitles = new Array();
	var aaContents = new Array();


			
	function displayCenter(stuff) {
		document.getElementById("message").innerHTML = stuff;
	}

	function testMarkers()
	{
		var mapMarkers = [];
		mapMarkers = this.cluster._mapMarkers;

		var stuff="";
		for (i = mapMarkers.length - 1; i >= 0; i--) {
			$marker = mapMarkers[i];
			if ($marker._isVisible && this.map.getBounds().contains($marker.getLatLng()) ) {
				stuff+=this.aaTitles[$marker._id];
				stuff+=this.aaContents[$marker._id]+"<br/><br/>";
				displayCenter(stuff);
			}
		}
	}

    function initialize() {
      if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("map"), {logoPassive: true});
        setupMarkers();
        map.setCenter(new GLatLng(44.213709909702054, -94.04296875), 4);
		//map.addControl(new GLargeMapControl());
		map.addControl(new ExtLargeMapControl());
        map.addControl(new GMapTypeControl());
        //
        
		geocoder = new GClientGeocoder();
		map.enableScrollWheelZoom();
		var mgrOptions = { borderPadding: 50, maxZoom: 15, trackMarkers: true };
		
		//mgr = new MarkerManager(map,mgrOptions);
        GEvent.addListener(map, "zoomend", function(oldlevel,newlevel) {
		  if ( ! clickedLink ) {
			  var center = map.getCenter();
			  var zoomLevel = map.getZoom();
			  testMarkers();
//			  GDownloadUrl("areainrange.php?lat="+center.lat()+"&lng="+center.lng(),displayCenter);			  
		  }
		  else {
		  	clickedLink = false;
		  }
         });
		GEvent.addListener(map, "moveend", function() {
		  if ( ! clickedLink ) {
			  var center = map.getCenter();
			  var zoomLevel = map.getZoom();
			  testMarkers();
//			  GDownloadUrl("areainrange.php?lat="+center.lat()+"&lng="+center.lng(),displayCenter);
		  }
		  else {
		  	clickedLink = false;
		  }
		});
      }
    } 
	function createMarker(latitude,longitude,markertitle,content) {
		var marker = new GMarker(new GLatLng(latitude,longitude),{title: markertitle});
		GEvent.addListener(marker, "click", function() {
			marker.openInfoWindowHtml(content);
		});
		return marker;
	}
	function initMarkers() {
		var batch = [];
		
<?php

$db = new MySQLDB();
$sql = "SELECT * from `geodatatable`";
$result = $db->query($sql);
while ($row = mysql_fetch_array($result)) {
    echo "this.aaTitles['" . $row['id'] . "'] = " . '\'<a onmouseover="centerMap(' . $row['id'] . ',' . $row['latitude'] . ',' . $row['longitude'] . ');return false;" href="#">' . addslashes($row['name']) . '</a><br/>\';';
    echo "this.aaContents['" . $row['id'] . "'] = '" . addslashes($row['content']) . "';";
    echo "marker = createMarker(" . $row['latitude'] . ", " . $row['longitude'] . ", '" . addslashes($row['name']) . "', '" . addslashes($row['name']) . "' +'<br/>'+ this.aaContents['" . $row['id'] . "']);";
    echo 'markers["' . $row['id'] . '"] = marker;';
    echo 'marker._id="' . $row['id'] . '";';
    echo 'batch.push(marker);';
}
?>		
		
		return batch;
	}
	
	function setupMarkers() {
		cluster=new ClusterMarker(map, { markers:initMarkers() } );
		cluster.fitMapToMarkers();
	
		//mgr.addMarkers(initMarkers(), 8);
		//mgr.refresh();
	}
	function doSearch() {
		var box = document.getElementById('searchbox');
		showAddress(box.value);
	}
	function centerMap(inID,lat,lng) {
		clickedLink = true;
		if ( markers[inID].isHidden() ) {
			map.setCenter(new GLatLng(lat, lng), 8);
			clickedLink = true;
		}
		GEvent.trigger(markers[inID],"click");
	}
	function showAddress(address) {
		geocoder.getLatLng(
			address,
			function(point) {
				if (!point) {
					document.getElementById("message").innerHTML = address + " not found";
				} else {
					document.getElementById("message").innerHTML = address + " found";
					map.setCenter(point, 8);
				}
			}
		);
	}
window.onload = function() {
	handleResize();
	initialize();
}
window.onunload = function() {
	GUnload();
}
var mapExpanded = false;

function windowHeight() {
	// Standard browsers (Mozilla, Safari, etc.)
	if (self.innerHeight)
		return self.innerHeight;
	// IE 6
	if (document.documentElement && document.documentElement.clientHeight)
		return document.documentElement.clientHeight;
	// IE 5
	if (document.body)
		return document.body.clientHeight;
	// Just in case.
	return 0;
}
function handleResize() {
	var height = windowHeight()	- document.getElementById('toolbar').offsetHeight - 30;
	document.getElementById('map').style.height = height + 'px';
	document.getElementById('sidebar').style.height = height + 'px';
}

window.onresize = handleResize; 

</script>

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

<form onsubmit="doSearch();return false;">
Search:
<div id="map_search" Search:
	<input
	type="text" name="searchbox" id="searchbox" value="enter"/></div>
<input type="submit" />
</form>
</div>
<div id="content">
<div id="map-wrapper">
<div id="map"></div>
</div>
<div id="sidebar">

<div id="message">
<?
$sql = "SELECT * from `geodatatable`";
$result = $db->query($sql);
while ($row = mysql_fetch_array($result)) {
    echo '<a onmouseover="centerMap(' . $row['id'] . ',' . $row['latitude'] . ',' . $row['longitude'] . ');return false;" href="#">' . $row['name'] . '</a><br/>';
    echo $row['content'];
    echo '<br/><br/>';
}
?>
</div>
</div>
</div>
</body>
</html>