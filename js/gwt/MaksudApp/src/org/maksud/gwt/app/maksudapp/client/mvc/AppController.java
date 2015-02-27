package org.maksud.gwt.app.maksudapp.client.mvc;

import org.maksud.gwt.app.common.client.gxtmodel.Folder;
import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.BasicRPCAsync;
import org.maksud.gwt.app.maksudapp.client.MaksudApp;
import org.maksud.gwt.app.maksudapp.client.mvc.AppView;

import com.extjs.gxt.ui.client.Registry;
import com.extjs.gxt.ui.client.event.EventType;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.google.gwt.user.client.rpc.AsyncCallback;

public class AppController extends Controller {

	private AppView appView;
	private BasicRPCAsync service;

	public AppController() {
		registerEventTypes(AppEvents.Init);
		//registerEventTypes(AppEvents.LoginDialog);
		registerEventTypes(AppEvents.Error);
	}

	public void handleEvent(AppEvent event) {
		EventType type = event.getType();
		if (type == AppEvents.Init) {
			onInit(event);
		} else if (type == AppEvents.LoginDialog) {
			onLogin(event);
		} else if (type == AppEvents.Error) {
			onError(event);
		}
	}

	public void initialize() {
		appView = new AppView(this);
	}

	protected void onError(AppEvent ae) {
		System.out.println("error: " + ae.<Object> getData());
	}

	private void onInit(AppEvent event) {
		forwardToView(appView, event);
		service = (BasicRPCAsync) Registry.get(MaksudApp.SERVICE);
		
		/*
		service.getMailFolders("darrell", new AsyncCallback<Folder>() {
			public void onFailure(Throwable caught) {
				Dispatcher.forwardEvent(AppEvents.Error, caught);
			}

			public void onSuccess(Folder result) {
				Dispatcher.forwardEvent(AppEvents.Register, result);
			}
		});*/

	}

	private void onLogin(AppEvent event) {
		forwardToView(appView, event);
	}
	


}
