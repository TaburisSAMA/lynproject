package org.maksud.gwt.app.maksudapp.client;

import java.util.List;

import org.maksud.gwt.app.common.client.rpc.AuthenticationService;
import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.mvc.AppController;
import org.maksud.gwt.app.maksudapp.client.mvc.UserController;
import org.maksud.gwt.app.maksudapp.client.widget.*;

import com.extjs.gxt.ui.client.GXT;
import com.extjs.gxt.ui.client.Registry;
import com.extjs.gxt.ui.client.Style.LayoutRegion;
import com.extjs.gxt.ui.client.Style.Scroll;
import com.extjs.gxt.ui.client.core.XDOM;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.extjs.gxt.ui.client.util.Margins;
import com.extjs.gxt.ui.client.widget.Component;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.LayoutContainer;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.extjs.gxt.ui.client.widget.TabPanel;
import com.extjs.gxt.ui.client.widget.Viewport;
import com.extjs.gxt.ui.client.widget.layout.BorderLayout;
import com.extjs.gxt.ui.client.widget.layout.BorderLayoutData;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.core.client.GWT;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.rpc.AsyncCallback;
import com.google.gwt.user.client.rpc.ServiceDefTarget;
import com.google.gwt.user.client.ui.Anchor;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.Widget;

public class MaksudApp implements EntryPoint {

	public final static int UPLOAD = 0;
	public final static int FILES = 1;
	public final static int USERS = 2;

	private Viewport viewport;

	public static final String SERVICE = "BasicRPC";

	public void onModuleLoad() {

		// Service
		BasicRPCAsync service = (BasicRPCAsync) GWT.create(BasicRPC.class);
		ServiceDefTarget endpoint = (ServiceDefTarget) service;
		String moduleRelativeURL = SERVICE;
		endpoint.setServiceEntryPoint(moduleRelativeURL);
		Registry.register(SERVICE, service);

		Dispatcher dispatcher = Dispatcher.get();
		dispatcher.addController(new AppController());
		dispatcher.addController(new UserController());

		dispatcher.dispatch(AppEvents.LoginDialog);

		// FileUploadDialog dialog = new FileUploadDialog();
		// dialog.show();

//		service.test(new AsyncCallback<Void>() {
//
//			@Override
//			public void onSuccess(Void result) {
//				System.out.println("test");
//
//			}
//
//			@Override
//			public void onFailure(Throwable caught) {
//				// TODO Auto-generated method stub
//
//			}
//		});
		
		
//		ImageChooserExample is= new ImageChooserExample();
//		RootPanel.get().add(is);

		GXT.hideLoadingPanel("loading");

	}
}
