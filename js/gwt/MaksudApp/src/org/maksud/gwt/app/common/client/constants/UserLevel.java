package org.maksud.gwt.app.common.client.constants;

import java.io.Serializable;

import javax.jdo.annotations.EmbeddedOnly;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;

@PersistenceCapable
@EmbeddedOnly
public class UserLevel implements Serializable {
	@Persistent
	private String _level;

	public UserLevel() {
		_level = UserLevelEnum.Contributor.toString();
	}

	public UserLevel(UserLevelEnum level) {
		_level = level.toString();
	}

	public UserLevel(String string) {
		_level = string;
	}

	public String getLevel() {
		return _level;
	}

	public void setLevel(UserLevelEnum status) {
		_level = status.toString();
	}

	@Override
	public String toString() {
		return _level;
	}
}
