<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
    "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css" href="css/style.css"
	media="screen" />
<title>User Registration</title>
</head>
<body>
<div id="container">
<div id="head">
<h1><a> Web Design </a></h1>

<ul id="menu">
	<li><a class="current" href="index.html" title="">Home</a></li>
	<li><a href="" title="">About Us</a></li>
	<li><a href="" title="">Services</a></li>
	<li><a href="" title="">Portfolio</a></li>
	<li><a href="contact.html" title="">Contact</a></li>
</ul>
<div class="top_head_banner">Top Banner</div>
</div>

<div id="area">Area</div>

<div id="main">
<div id="welcome">
<h1>My journey to Web 2 Development...</h1>
</div>

<div id="content_left">
<%
	boolean isReg = false;
	try {
		String result = (String) request.getAttribute("error");
		if (result.equals("Success")) {
			response.getWriter().println("Successfully Registered");
			isReg = true;
		} else {
		}
	} catch (Exception e) {
	}
%> <%
 	if (!isReg) {
 %>
<h3>Registration</h3>

<div id="form">
<form action="/register" method="post">
<div id="fields"><label for="userid">User Id:</label> <input
	id="userid" type="text" name="userid" /><br />

<label for="password">Password:</label> <input id="password"
	type="password" name="password" /><br />

<label for="retype">Retype Password:</label> <input id="retype"
	type="password" name="retype" /><br />

<label for="email">Email:</label> <input id="email" type="text"
	name="email" /><br />

<label for="web">Web:</label> <input id="web" type="text" name="web" /><br />
</div>
<div id="send"><input type="image" src="images/send.gif"
	value="send" /></div>
</form>
</div>
<%
	}
%>
</div>

<div id="content_right">
<h4>Latest News</h4>

<div>... ... ... ...</div>
</div>



<div class="spacer"></div>
</div>

<div id="footer">
<div style="float: left; padding-left: 40px;">Copyright 2009
&copy; Maksud</div>
<div id="madeby"><a href="#"><img src="images/csscreme.jpg"
	width="200" height="35" border="0" alt="csscreme" title="csscreme" /></a><br />
<a href="#" title="This site is W3C compliant">Xhtml</a> <a
	href="http://jigsaw.w3.org/css-validator/validator?uri=www.csscreme.com&amp;usermedium=all"
	title="This site is coded with validate CSS">css</a></div>
</div>


</div>

</body>
</html>
