package org.maksud.gwt.app.maksudapp.client.widget;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.event.ButtonEvent;
import com.extjs.gxt.ui.client.event.Events;
import com.extjs.gxt.ui.client.event.FormEvent;
import com.extjs.gxt.ui.client.event.Listener;
import com.extjs.gxt.ui.client.event.SelectionListener;
import com.extjs.gxt.ui.client.widget.LayoutContainer;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.form.FileUploadField;
import com.extjs.gxt.ui.client.widget.form.FormPanel;
import com.extjs.gxt.ui.client.widget.form.TextField;
import com.extjs.gxt.ui.client.widget.form.FormPanel.Encoding;
import com.extjs.gxt.ui.client.widget.form.FormPanel.Method;
import com.google.gwt.json.client.JSONParser;
import com.google.gwt.json.client.JSONValue;
import com.google.gwt.user.client.Element;

public class GWTFileUpload extends LayoutContainer {

	@Override
	protected void onRender(Element parent, int index) {
		super.onRender(parent, index);
		setStyleAttribute("margin", "10px");

		final FormPanel form = new FormPanel();
		form.setHeading("File Upload Example");
		form.setFrame(true);
		form.setAction("/fileupload");
		form.setEncoding(Encoding.MULTIPART);
		form.setMethod(Method.POST);
		form.setButtonAlign(HorizontalAlignment.CENTER);
		form.setWidth(350);

		TextField<String> name = new TextField<String>();
		name.setFieldLabel("Name");
		form.add(name);

		FileUploadField file = new FileUploadField();
		file.setAllowBlank(false);
		file.setFieldLabel("File");
		file.setName("fupload");
		form.add(file);

		Button btn = new Button("Submit");
		btn.addSelectionListener(new SelectionListener<ButtonEvent>() {

			@Override
			public void componentSelected(ButtonEvent ce) {
				if (!form.isValid()) {
					return;
				}
				form.submit();
				// MessageBox.info("Action", "You file was uploaded", null);
			}
		});
		form.addButton(btn);

		form.addListener(Events.Submit, new Listener<FormEvent>() {
			public void handleEvent(FormEvent be) {
				// status.setVisible(false);
				// String html = be.getResultHtml();

				try {
					// JSONValue jsonValue = JSONParser.parse(html);

				} catch (Exception e) {
					MessageBox.info("Exception", e.getMessage(), null);
				}

			}
		});

		add(form);
	}

}
