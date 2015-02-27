package org.maksud.gwt.app.common.server;

public class AppSettings {

	static String email = "";
	static String appName = "";
	static String appUrl = "";

	public static final String getEmail() {
		return email;
	}

	public static final void setEmail(String email) {
		AppSettings.email = email;
	}

	public static final String getAppName() {
		return appName;
	}

	public static final void setAppName(String appName) {
		AppSettings.appName = appName;
	}

	public static final String getAppUrl() {
		return appUrl;
	}

	public static final void setAppUrl(String appUrl) {
		AppSettings.appUrl = appUrl;
	}

}
