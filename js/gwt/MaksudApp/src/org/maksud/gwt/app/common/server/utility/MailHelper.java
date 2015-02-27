package org.maksud.gwt.app.common.server.utility;

import java.util.Properties;

import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class MailHelper {

	public static boolean sendEmail(String sender, String senderName, String receiver, String receiverName, String msgSubject, String msgBody) {
		Properties props = new Properties();
		Session session = Session.getDefaultInstance(props, null);

		try {
			Message msg = new MimeMessage(session);
			msg.setFrom(new InternetAddress(sender, senderName));
			msg.addRecipient(Message.RecipientType.TO, new InternetAddress(receiver, receiverName));
			msg.setSubject(msgSubject);
			msg.setText(msgBody);
			Transport.send(msg);

		} catch (Exception e) {
			return false;
		}
		return true;
	}
}
