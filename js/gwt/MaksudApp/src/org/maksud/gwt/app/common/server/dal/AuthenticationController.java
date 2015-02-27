package org.maksud.gwt.app.common.server.dal;

import java.util.Date;
import java.util.UUID;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.AppSettings;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;
import org.maksud.gwt.app.common.server.utility.MailHelper;

import com.google.appengine.api.datastore.KeyFactory;

public class AuthenticationController {

	public static boolean hasUser(String userid) {
		return UserDBController.getUserEntity(userid) != null;
	}

	public static boolean isValidUser(String userid, String password) {
		try {
			UserEntity user = UserDBController.getUserEntity(userid);
			if (user != null && user.getPassword() == password
					&& user.getStatus().getStatus() == UserStatus.Active)
				return true;
			else
				return false;
		} catch (Exception e) {
			return false;
		}
	}

	public static boolean registerUser(String userid, String password,
			String retype, String email, String web) {
		String activationKey = UUID.randomUUID().toString().replace("-", "");

		try {

			if (hasUser(userid)) {
				System.out.println("User already exists.");
				return false;
			}

			if (password.equals(retype) && password.length() > 0) {
				boolean regSuccess = UserDBController.createUser(userid,
						password, retype, email, web, activationKey);

				if (regSuccess) {
					MailHelper.sendEmail(AppSettings.getEmail(), "webmaster",
							email, userid, "Activate", "Please Activate by "
									+ AppSettings.getAppUrl()
									+ "/activate?user=" + userid + "&key="
									+ activationKey);

					System.out.println("User registration successfull.");
					return true;
				} else
					return false;
			} else {
				System.out
						.println("User registration failed. Password Problem.");
				return false;
			}
		} catch (Exception e) {
			System.out.println("User registration failed. Exception");
			e.printStackTrace();
			return false;
		}
	}

	public static boolean activateUser(String userid, String activationKey) {
		try {
			UserEntity user = UserDBController.getUserEntity(userid);
			if (user.getActivationKey().equals(activationKey)) {
				user.setStatus(new UserStatus(UserStatus.Active));
				UserDBController.updateUser(user);
				System.out.println("User is activated!");
				return true;
			} else {
				System.out.print("Activation Problem!");
				return false;
			}
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	public static boolean login(String userid, String password) {
		try {
			if (isValidUser(userid, password)) {
				return true;
			}
		} catch (Exception exp) {

		}
		return false;
	}

}
