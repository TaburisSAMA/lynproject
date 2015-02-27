<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Documentation Easy PHP Upload</title>


<script type="text/javascript" src="jquery/jquery-1.2.6.js"></script>
<script type="text/javascript" src="jquery/jquery.form.js"></script>
<script type="text/javascript">

$(document).ready(function() {
	$("#loading")
	.ajaxStart(function(){
		$(this).show();
	})
	.ajaxComplete(function(){
		$(this).hide();
	});
	var options = {
		beforeSubmit:  showRequest,
		success:       showResponse,
		url:       'upload4jquery.php',  // your upload script
		dataType:  'json'
	};
	$('#Form1').submit(function() {
		document.getElementById('message').innerHTML = '';
		$(this).ajaxSubmit(options);
		return false;
	});
}); 

function showRequest(formData, jqForm, options) {
	var fileToUploadValue = $('input[@name=fileToUpload]').fieldValue();
	if (!fileToUploadValue[0]) {
		document.getElementById('message').innerHTML = 'Please select a file.';
		return false;
	} 

	return true;
} 

function showResponse(data, statusText)  {
	if (statusText == 'success') {
		if (data.img != '') {
			document.getElementById('result').innerHTML = '<img src="/upload/thumb/'+data.img+'" />';
			document.getElementById('message').innerHTML = data.error;
		} else {
			document.getElementById('message').innerHTML = data.error;
		}
	} else {
		document.getElementById('message').innerHTML = 'Unknown error!';
	}
} 

</script>


</head>

<body>

<form id="Form1" name="Form1" method="post" action=""><input
	type="hidden" name="MAX_FILE_SIZE" value="<?php
echo $max_size;
?>" /> Select an image from your hard disk:

<div><input type="file" name="fileToUpload" id="fileToUpload" size="18" />
<input type="Submit" value="Submit" id="buttonForm" /></div>
</form>
<img id="loading" src="loading.gif" style="display: none;" />

<p id="message">


<p id="result">

</body>
</html>




