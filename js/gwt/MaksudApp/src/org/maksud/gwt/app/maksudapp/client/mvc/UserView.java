package org.maksud.gwt.app.maksudapp.client.mvc;

import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.widget.LoginDialog;
import org.maksud.gwt.app.maksudapp.client.widget.RegistrationDialog;

import com.extjs.gxt.ui.client.event.Events;
import com.extjs.gxt.ui.client.event.Listener;
import com.extjs.gxt.ui.client.event.WindowEvent;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;
import com.extjs.gxt.ui.client.mvc.View;
import com.extjs.gxt.ui.client.widget.MessageBox;

public class UserView extends View {

	private RegistrationDialog regDialog;
	private LoginDialog loginDialog;

	public UserView(Controller controller) {
		super(controller);
	}

	@Override
	protected void handleEvent(AppEvent event) {
		if (event.getType() == AppEvents.RegistrationDialog) {
			showRegistrationDialog();
		} else if (event.getType() == AppEvents.LoginDialog) {
			showLoginDialog();
		}
	}

	void showRegistrationDialog() {
		if (regDialog == null) {
			regDialog = new RegistrationDialog();
			regDialog.setClosable(false);
		}
		regDialog.show();
	}

	private void showLoginDialog() {
		if (loginDialog == null) {
			loginDialog = new LoginDialog();
			loginDialog.setClosable(false);
		}
		loginDialog.show();
	}
}
