package org.maksud.gwt.app.maksudapp.client;

import java.util.List;

import org.maksud.gwt.app.common.client.model.Employee;
import org.maksud.gwt.app.common.client.model.User;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface BasicRPCAsync {
	void test(AsyncCallback<Void> callback);
	
	void getUsers(AsyncCallback<List<User>> callback);
	void getEmployees(AsyncCallback<List<Employee>> callback);
	void registerUser(User user, AsyncCallback<Boolean> callback);

	void loginUser(User user, AsyncCallback<Boolean> callback);

}
