package org.maksud.gwt.app.common.server.jsp.servlets;

import java.io.IOException;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.dal.AuthenticationController;
import org.maksud.gwt.app.common.server.dal.UserDBController;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;

import com.google.appengine.api.datastore.KeyFactory;

public class ActivationServlet extends HttpServlet {

	public void doGet(HttpServletRequest req, HttpServletResponse res)
			throws ServletException, IOException {
		String userid = (String) req.getParameter("user");
		String activationKey = (String) req.getParameter("key");

		if (AuthenticationController.activateUser(userid, activationKey)) {
			// Show Success Message...
			res.getWriter().print("Successfully Activated!");
		} else {
			// Show Failure
			res.getWriter().print("Activation Problem!");
		}
	}
}
