package org.maksud.gwt.app.common.server.utility;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Logger;

public class UrlHelper {
	private static final Logger log = Logger.getLogger(UrlHelper.class.getName());

	public static String getContents(String addr) {

		String line = "";
		try {
			URL url = new URL(addr);
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setDoOutput(true);
			connection.setRequestMethod("GET");
			connection.setConnectTimeout(30000);// 30 Seconds

			if (connection.getResponseCode() == HttpURLConnection.HTTP_OK) {

				// line = (String)connection.getContent();

				//log.info("Date: " + connection.getDate());
				//log.info("Type: " + connection.getContentType());
				//log.info("Exp: " + connection.getExpiration());
				//log.info("Last M: " + connection.getLastModified());
				//log.info("Length: " + connection.getContentLength());
				//log.info("Content-Type: " + connection.getContentType());

				InputStream is = connection.getInputStream();
				int ch;
				while (((ch = is.read()) != -1))
					line += (char) ch;
				is.close();
			} else {
				// sslog.severe("HTTP Error.");
			}
		} catch (MalformedURLException e) {
			// log.severe("MalformedURLException:" + e.getMessage());
		} catch (IOException e) {
			// log.severe("IOException:" + e.getMessage());
		}
		return line;
	}
}
