package org.maksud.gwt.app.common.client.model;

import com.extjs.gxt.ui.client.data.BaseModel;

import java.io.Serializable;
import java.util.*;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;

public class UserDetail extends BaseModel {

	// private String login;
	// private String password;
	// private String name;
	// private String email;
	// private String url;
	// private Date register_date;
	// private String activation_key;
	// private UserLevelEnum level;
	// private UserStatusEnum status;

	private static final long serialVersionUID = -2586208348201224917L;

	public UserDetail() {

	}

	public UserDetail(String login, String password) {
		super();
		set("login", login);
		set("password", password);
	}

	public UserDetail(String login, String password, String name, String email, String url, Date registerDate, String activationKey, UserLevel level,
			UserStatus status) {
		super();
		set("login", login);
		set("password", password);
		set("name", name);
		set("email", email);
		set("url", url);
		set("register_date", registerDate);
		set("activation_key", activationKey);

		if (level != null)
		{
			System.err.print("Level Found!");
			set("level", level.getLevel());
		}
		else
		{
			System.err.print("Level NOT Found!");
			set("level", (new UserLevel()).getLevel());
		}

		if (status != null)
		{
			System.err.print("Status Found!");
			set("status", status.getStatus());
		}
		else
		{
			System.err.print("Status NOT Found!");
			set("status", UserStatus.Inactive);
		}
	}

	public String getUserId() {
		return get("login");
	}

	public void setUserId(String login) {
		set("login", login);
	}

	public String getPassword() {
		return get("password");
	}

	public void setPassword(String password) {
		set("password", password);
	}

	public String getName() {
		return get("name");
	}

	public void setName(String name) {
		set("name", name);
	}

	public String getEmail() {
		return get("email");
	}

	public void setEmail(String email) {
		set("email", email);
	}

	public String getUrl() {
		return get("url");
	}

	public void setUrl(String url) {
		set("url", url);
	}

	public Date getRegisterDate() {
		return get("register_date");
	}

	public void setRegisterDate(Date registerDate) {
		set("register_date", registerDate);
	}

	public String getActivationKey() {
		return get("activation_key");
	}

	public void setActivationKey(String activationKey) {
		set("activation_key", activationKey);
	}

	public UserLevel getLevel() {
		return new UserLevel((String)get("level"));
	}

	public void setLevel(UserLevel level) {
		set("level", level.getLevel());
	}

	public UserStatus getStatus() {
		int status = get("status");
		return new UserStatus(status);
	}

	public void setStatus(UserStatus status) {
		set("status", status.getStatus());
	}

}
