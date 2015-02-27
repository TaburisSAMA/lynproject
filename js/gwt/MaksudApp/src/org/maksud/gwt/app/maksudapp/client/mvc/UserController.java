package org.maksud.gwt.app.maksudapp.client.mvc;

import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.BasicRPCAsync;

import com.extjs.gxt.ui.client.event.EventType;
import com.extjs.gxt.ui.client.event.Listener;
import com.extjs.gxt.ui.client.event.MessageBoxEvent;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.google.gwt.user.client.rpc.AsyncCallback;

public class UserController extends Controller {
	private UserView userView;
	private BasicRPCAsync service;

	public UserController() {
		service = BasicRPC.Util.getInstance();

		registerEventTypes(AppEvents.Registration);
		registerEventTypes(AppEvents.Login);
		registerEventTypes(AppEvents.LoginDialog);
		registerEventTypes(AppEvents.RegistrationDialog);
	}

	public void initialize() {
		userView = new UserView(this);
	}

	@Override
	public void handleEvent(AppEvent event) {
		if (event.getType() == AppEvents.RegistrationDialog) {
			showDialog(event);
		} else if (event.getType() == AppEvents.LoginDialog) {
			showDialog(event);
		} else if (event.getType() == AppEvents.Registration) {
			registerUser((User) event.getData());
		} else if (event.getType() == AppEvents.Login) {
			loginUser((User) event.getData());
		}
	}

	private void showDialog(AppEvent event) {
		forwardToView(userView, event);
	}

	private void onLogin(AppEvent event) {

		// forwardToView(userView, event);
	}

	private void registerUser(User user) {

		service.registerUser(user, new AsyncCallback<Boolean>() {

			@Override
			public void onSuccess(Boolean result) {
				if (result) {
					MessageBox.info("Registration", "User registraion is successfull. An activation url is sent to your mail.",

					new Listener<MessageBoxEvent>() {

						@Override
						public void handleEvent(MessageBoxEvent be) {
							Dispatcher.forwardEvent(AppEvents.LoginDialog);
						}
					});

				} else {
					MessageBox.alert("Registration", "User registraion failed.", new Listener<MessageBoxEvent>() {

						@Override
						public void handleEvent(MessageBoxEvent be) {

							@SuppressWarnings("unused")
							EventType evt = be.getType();
							if (be.getType() != null)
								Dispatcher.forwardEvent(AppEvents.LoginDialog);

							Dispatcher.forwardEvent(AppEvents.RegistrationDialog);

						}
					});

				}
			}

			@Override
			public void onFailure(Throwable caught) {
				// TODO Auto-generated method stub

			}
		});
	}

	private void loginUser(User user) {
		service.loginUser(user, new AsyncCallback<Boolean>() {

			@Override
			public void onSuccess(Boolean result) {
				if (result)
					MessageBox.info("Login", "User login is successfull. An activation url is sent to your mail.", null);
				else {
					MessageBox.alert("Login", "User login failed.", new Listener<MessageBoxEvent>() {

						@Override
						public void handleEvent(MessageBoxEvent be) {
							Dispatcher.forwardEvent(AppEvents.LoginDialog);

						}
					});

				}

			}

			@Override
			public void onFailure(Throwable caught) {
				// TODO Auto-generated method stub

			}
		});
	}

}
