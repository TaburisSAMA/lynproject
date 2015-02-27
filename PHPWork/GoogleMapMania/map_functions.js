var map;

// Tracking what we've added allows us to avoid unnecessarily adding and
// removing
// markers.
var markers_on_map = {};

// How much to extend the actual viewport as a proportion of its size.
var extend_proportion = 0.4;

var icons = {
	0 : {
		file :"blue-16.png",
		width :16
	},
	1 : {
		file :"blue-32.png",
		width :32
	},
	2 : {
		file :"blue-48.png",
		width :48
	},
	3 : {
		file :"blue-64.png",
		width :64
	}
}

var fields = {
	'id' :0,
	'latitude' :1,
	'longitude' :2,
	'child_count' :3
}

function newViewport() {
	var viewport = map.getBounds();

	// Extend the bounds by a proportion in each direction.
	var extend_lat_range = (viewport.getNorthEast().lat() - viewport.getSouthWest().lat()) * extend_proportion;
	var extend_lng_range = (viewport.getNorthEast().lng() - viewport.getSouthWest().lng()) * extend_proportion;

	viewport.extend(new GLatLng(viewport.getSouthWest().lat() - extend_lat_range, viewport.getSouthWest().lng() - extend_lng_range));
	viewport.extend(new GLatLng(viewport.getNorthEast().lat() + extend_lat_range, viewport.getNorthEast().lng() + extend_lng_range));

	GDownloadUrl(data_url + 'sw=' + viewport.getSouthWest().toUrlValue() + '&ne=' + viewport.getNorthEast().toUrlValue() + '', 
			function(data) {
				initMarkers(eval('(' + data + ')'));
	});
}

function initMarkers(markers) {
	var i;
	var old_markers = markers_on_map;
	markers_on_map = {};

	for (i = 0; i < markers.length; i++) {
		if (old_markers[markers[i][fields.id]]) {
			// marker already on the map
			markers_on_map[markers[i][fields.id]] = old_markers[markers[i][fields.id]];
			delete old_markers[markers[i][fields.id]];
		} else {
			// not already on map
			markers_on_map[markers[i][fields.id]] = createMarker(markers[i]);
			map.addOverlay(markers_on_map[markers[i][fields.id]]);
		}
	}

	// Zap remaining old markers
	for (id in old_markers) {
		map.removeOverlay(old_markers[id]);
	}
}

function createMarker(pointData) {
	var latlng = new GLatLng(pointData[fields.latitude],
			pointData[fields.longitude]);
	var icon_choice;

	var label = pointData[fields.child_count];
	if (pointData[fields.child_count] == 1) {
		icon_choice = 0;
		label = '';
	} else if (pointData[fields.child_count] < 20) {
		icon_choice = 1;
	} else if (pointData[fields.child_count] < 50) {
		icon_choice = 2;
	} else {
		icon_choice = 3;
	}

	var icon = icons[icon_choice];

	opts = {
		"icon" :icon.gicon,
		"labelText" :label,
		"labelOffset" :new GSize(-(icon.width / 2), -(icon.width / 2)),
		"labelClass" :"blueLabel" + icon.width,
		"clickable" :true
	};

	var marker = new LabeledMarker(latlng, opts);

	return marker;
}

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

function init() {
	handleResize();

	map = new GMap(document.getElementById("map"));
	map.addControl(new GSmallMapControl());
	map.setCenter(new GLatLng(centerLatitude, centerLongitude), startZoom);
	map.addControl(new GMapTypeControl());

	for (id in icons) {
		icons[id].gicon = new GIcon();
		icons[id].gicon.image = "http://uwmike.com/maps/dams/img/"
				+ icons[id].file;
		icons[id].gicon.iconSize = new GSize(icons[id].width, icons[id].width);
		icons[id].gicon.iconAnchor = new GPoint(icons[id].width / 2,
				icons[id].width / 2);
	}

	newViewport();
	GEvent.addListener(map, 'moveend', function() {
		newViewport();
	});
}

window.onresize = handleResize;
window.onload = init;
window.onunload = GUnload;
