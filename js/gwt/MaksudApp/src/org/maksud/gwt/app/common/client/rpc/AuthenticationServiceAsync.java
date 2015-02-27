package org.maksud.gwt.app.common.client.rpc;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface AuthenticationServiceAsync {
	public void isAuthenticated(String userid, String password, AsyncCallback<Boolean> callback);

	public void isSessionValid(AsyncCallback<Boolean> callback);

	public void registerUser(String userid, String password, String retype, String email, String web, AsyncCallback<Boolean> callback);

	
}
