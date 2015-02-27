package org.maksud.gwt.app.maksudapp.client.widget;

import java.util.Date;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.AppEvents;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.event.ButtonEvent;
import com.extjs.gxt.ui.client.event.ComponentEvent;
import com.extjs.gxt.ui.client.event.EventType;
import com.extjs.gxt.ui.client.event.KeyListener;
import com.extjs.gxt.ui.client.event.SelectionListener;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.extjs.gxt.ui.client.widget.Dialog;
import com.extjs.gxt.ui.client.widget.Status;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.form.TextField;
import com.extjs.gxt.ui.client.widget.layout.FormLayout;
import com.extjs.gxt.ui.client.widget.toolbar.FillToolItem;

public class RegistrationDialog extends Dialog {

	public String result = "";

	protected TextField<String> userName;
	protected TextField<String> password;
	protected TextField<String> retype;
	protected TextField<String> email;
	protected TextField<String> website;
	protected Button reset;
	protected Button signup;
	protected Button login;
	protected Status status;

	public RegistrationDialog() {
		FormLayout layout = new FormLayout();
		layout.setLabelWidth(90);
		layout.setDefaultWidth(155);
		setLayout(layout);

		setButtonAlign(HorizontalAlignment.LEFT);
		setButtons("");
		// setIcon(IconHelper.createStyle("user"));
		setHeading("MaksudApp Registration Dialog");
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
		userName.setFieldLabel("UserId");
		userName.addKeyListener(keyListener);
		add(userName);

		password = new TextField<String>();
		password.setMinLength(4);
		password.setPassword(true);
		password.setFieldLabel("Password");
		password.addKeyListener(keyListener);
		add(password);

		retype = new TextField<String>();
		retype.setMinLength(4);
		retype.setPassword(true);
		retype.setFieldLabel("Retype");
		retype.addKeyListener(keyListener);
		add(retype);

		email = new TextField<String>();
		email.setFieldLabel("Email");
		add(email);

		website = new TextField<String>();
		website.setFieldLabel("Website");
		add(website);

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

		login = new Button("Login");
		login.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				onSubmit(AppEvents.LoginDialog);
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

		signup = new Button("Sign Up");
		// signup.disable();
		signup.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				onSubmit(AppEvents.Registration);
			}
		});

		addButton(login);
		addButton(reset);
		addButton(signup);
	}

	protected void onSubmit(EventType event) {
		this.hide();

		if (event == AppEvents.LoginDialog) {
			Dispatcher.forwardEvent(AppEvents.LoginDialog);
		} else if (event == AppEvents.Registration) {

			try {
				User usr = new User(userName.getValue(), password.getValue(), userName.getValue(), email.getValue(), website.getValue(), new Date(), "",
						UserLevel.Contributor, UserStatus.Inactive);
				Dispatcher.forwardEvent(AppEvents.Registration, usr);
			} catch (Exception e) {
				System.out.print(e.getMessage());
			}
		}
	}

	protected boolean hasValue(TextField<String> field) {
		return field.getValue() != null && field.getValue().length() > 0;
	}

	protected void validate() {
		// signup.setEnabled(hasValue(userName) && hasValue(password) &&
		// password.getValue().length() > 3);
	}

}
