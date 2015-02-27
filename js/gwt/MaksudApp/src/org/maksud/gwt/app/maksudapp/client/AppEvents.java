/*
 * Ext GWT - Ext for GWT
 * Copyright(c) 2007-2009, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */
package org.maksud.gwt.app.maksudapp.client;

import com.extjs.gxt.ui.client.event.EventType;

public class AppEvents {
	public static final EventType Init = new EventType();
	//Show Login Dialog.
	public static final EventType LoginDialog = new EventType();
	public static final EventType Login = new EventType();
	//Show Registration Dialog.
	public static final EventType RegistrationDialog = new EventType();
	public static final EventType Registration = new EventType();
	public static final EventType Error = new EventType();
}
