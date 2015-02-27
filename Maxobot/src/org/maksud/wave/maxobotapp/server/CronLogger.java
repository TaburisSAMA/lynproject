package org.maksud.wave.maxobotapp.server;

import java.io.IOException;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.wave.maxobotapp.server.entity.LogEntity;
import org.maksud.wave.maxobotapp.server.entity.PMF;

public class CronLogger extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public void doWork(HttpServletRequest req, HttpServletResponse res) {

		try {
			PersistenceManager pm = PMF.get().getPersistenceManager();
			LogEntity le = new LogEntity();
			le.setLog("Hello, " + req.getRemoteAddr());
			pm.makePersistent(le);

			res.getWriter().write("Success");

		} catch (Exception exp) {
			try {
				res.getWriter().write("Exception" + exp.getMessage());
			} catch (IOException e) {
				e.printStackTrace();
			}
			exp.printStackTrace();
		}
	}

	public void doGet(HttpServletRequest req, HttpServletResponse res)
			throws ServletException, IOException {
		doWork(req, res);
	}

	public void doPost(HttpServletRequest req, HttpServletResponse res)
			throws ServletException, IOException {
		doWork(req, res);
	}

}
