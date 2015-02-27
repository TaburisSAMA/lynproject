<%@ page language="java" contentType="text/html; UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="java.util.List"%>
<%@ page import="org.maksud.gwt.app.maksudapp.server.dal.*"%>
<%@ page import="org.maksud.gwt.app.maksudapp.server.data.entities.*"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>User List</title>
</head>
<body>
<%
	List<UserEntity> userEntities = UserController.getAllUsers();
	out.write("<table>");
	for (int i = 0; i < userEntities.size(); i++) {
		UserEntity user = userEntities.get(i);

		out.write("<tr>");
		out.write("<td>" + user.getLogin() + "</td>");
		out.write("<td>" + user.getName() + "</td>");
		out.write("<td>" + user.getEmail() + "</td>");
		out.write("<td>" + user.getActivationKey() + "</td>");
		out.write("<td>" + user.getStatus() + "</td>");

		out.write("</tr>");
	}
	out.write("</table>");
%>

</body>
</html>