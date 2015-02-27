package org.maksud.gwt.app.common.client.constants;

import java.io.Serializable;

import javax.jdo.annotations.EmbeddedOnly;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;

@PersistenceCapable
@EmbeddedOnly
public class UserStatus implements Serializable {
	@Persistent
	public int _status;

	public static final int Banned = 0;
	public static final int Active = 1;
	public static final int Inactive = 2;

	public UserStatus() {
		this(UserStatus.Inactive);
	}

	public UserStatus(int status) {
		super();
		_status = status;
	}

	public int getStatus() {
		return _status;
	}

	public void setStatus(int status) {
		_status = status;
	}

	@Override
	public String toString() {
		switch (_status) {
		case UserStatus.Active:
			return "Active";
		case UserStatus.Banned:
			return "Banned";
		case UserStatus.Inactive:
			return "Inactive";
		}
		return "Unknown";
	}
}
