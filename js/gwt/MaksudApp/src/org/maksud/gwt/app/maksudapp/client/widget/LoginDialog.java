package org.maksud.gwt.app.maksudapp.client.widget;

import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.AppEvents;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.event.ButtonEvent;
import com.extjs.gxt.ui.client.event.ComponentEvent;
import com.extjs.gxt.ui.client.event.EventType;
import com.extjs.gxt.ui.client.event.KeyListener;
import com.extjs.gxt.ui.client.event.SelectionListener;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.extjs.gxt.ui.client.util.IconHelper;
import com.extjs.gxt.ui.client.widget.Dialog;
import com.extjs.gxt.ui.client.widget.Status;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.form.TextField;
import com.extjs.gxt.ui.client.widget.layout.FormLayout;
import com.extjs.gxt.ui.client.widget.toolbar.FillToolItem;
import com.google.gwt.user.client.Timer;

public class LoginDialog extends Dialog {

	// public String result = "";
	// public User user;

	protected TextField<String> userName;
	protected TextField<String> password;
	protected Button register;
	protected Button reset;
	protected Button login;
	protected Status status;

	public LoginDialog() {
		FormLayout layout = new FormLayout();
		layout.setLabelWidth(90);
		layout.setDefaultWidth(155);
		setLayout(layout);

		setButtonAlign(HorizontalAlignment.LEFT);
		setButtons("");
		// setIcon(IconHelper.createStyle("user"));
		setHeading("Maksud App Login");
		setModal(true);
		setBodyBorder(true);
		setBodyStyle("padding: 8px;background: none");
		setWidth(300);
		setResizable(false);

		KeyListener keyListener = new KeyListener() {
			public void componentKeyUp(ComponentEvent event) {
				validate();
			}
		};

		userName = new TextField<String>();
		userName.setMinLength(4);
		userName.setFieldLabel("Username");
		userName.addKeyListener(keyListener);
		add(userName);

		password = new TextField<String>();
		password.setMinLength(4);
		password.setPassword(true);
		password.setFieldLabel("Password");
		password.addKeyListener(keyListener);
		add(password);

		setFocusWidget(userName);
	}

	@Override
	protected void createButtons() {
		super.createButtons();
		status = new Status();
		status.setBusy("please wait...");
		status.hide();
		status.setAutoWidth(true);
		getButtonBar().add(status);

		getButtonBar().add(new FillToolItem());

		register = new Button("Sign Up");
		register.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				onSubmit(AppEvents.RegistrationDialog);
			}
		});

		reset = new Button("Reset");
		reset.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				userName.reset();
				password.reset();
				validate();
				userName.focus();
			}

		});

		login = new Button("Login");
		login.disable();
		login.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				onSubmit(AppEvents.Login);
			}
		});

		addButton(register);
		addButton(reset);
		addButton(login);

	}

	protected void onSubmit(EventType event) {
		this.hide();
		if (event == AppEvents.RegistrationDialog) {
			AppEvent eveAppEvent = new AppEvent(AppEvents.RegistrationDialog);
			Dispatcher.forwardEvent(eveAppEvent);
		} else if (event == AppEvents.Login) {
			User user = new User(userName.getValue(), password.getValue());
			AppEvent eveAppEvent = new AppEvent(AppEvents.Login, user);
			Dispatcher.forwardEvent(eveAppEvent);
		}
	}

	protected boolean hasValue(TextField<String> field) {
		return field.getValue() != null && field.getValue().length() > 0;
	}

	protected void validate() {
		login.setEnabled(hasValue(userName) && hasValue(password) && password.getValue().length() > 3);
	}

}
