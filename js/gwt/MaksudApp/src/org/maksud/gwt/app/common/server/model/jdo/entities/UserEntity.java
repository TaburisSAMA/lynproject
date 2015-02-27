package org.maksud.gwt.app.common.server.model.jdo.entities;

import java.util.Date;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserLevelEnum;
import org.maksud.gwt.app.common.client.constants.UserStatus;

import com.google.appengine.api.datastore.Key;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class UserEntity {

	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Key id;

	@Persistent
	private String login;

	@Persistent
	private String password;

	@Persistent
	private String name;

	@Persistent
	private String email;

	@Persistent
	private String url;

	@Persistent
	private Date register_date;

	@Persistent
	private String activation_key;

	@Persistent
	private UserStatus status;

	@Persistent
	private UserLevel level;

	public UserEntity() {

	}

	public UserEntity(String login, String password, String name, String email, String url) {
		super();
		this.login = login;
		this.password = password;
		this.name = name;
		this.email = email;
		this.url = url;
		this.register_date = new Date();
		this.activation_key = "";
		this.level = new UserLevel(UserLevelEnum.Contributor);
		this.status = new UserStatus(UserStatus.Inactive);
	}

	public Key getId() {
		return id;
	}

	public void setId(Key id) {
		this.id = id;
	}

	public String getLogin() {
		return login;
	}

	public void setLogin(String login) {
		this.login = login;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public Date getRegister_date() {
		return register_date;
	}

	public void setRegister_date(Date registerDate) {
		register_date = registerDate;
	}

	public String getActivationKey() {
		return activation_key;
	}

	public void setActivationKey(String activationKey) {
		activation_key = activationKey;
	}

	public UserLevel getLevel() {
		return level;
	}

	public void setLevel(UserLevel level) {
		this.level = level;
	}

	public UserStatus getStatus() {
		return status;
	}

	public void setStatus(UserStatus status) {
		this.status = status;
	}
}
