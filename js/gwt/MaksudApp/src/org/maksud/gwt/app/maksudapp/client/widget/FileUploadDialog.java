package org.maksud.gwt.app.maksudapp.client.widget;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import org.maksud.gwt.app.common.client.TestData;
import org.maksud.gwt.app.common.client.gxtmodel.Stock;
import org.maksud.gwt.app.maksudapp.client.AppEvents;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.event.ButtonEvent;
import com.extjs.gxt.ui.client.event.Events;
import com.extjs.gxt.ui.client.event.FormEvent;
import com.extjs.gxt.ui.client.event.Listener;
import com.extjs.gxt.ui.client.event.SelectionListener;
import com.extjs.gxt.ui.client.store.ListStore;
import com.extjs.gxt.ui.client.widget.Dialog;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.extjs.gxt.ui.client.widget.Slider;
import com.extjs.gxt.ui.client.widget.Status;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.form.CheckBox;
import com.extjs.gxt.ui.client.widget.form.CheckBoxGroup;
import com.extjs.gxt.ui.client.widget.form.ComboBox;
import com.extjs.gxt.ui.client.widget.form.DateField;
import com.extjs.gxt.ui.client.widget.form.FileUploadField;
import com.extjs.gxt.ui.client.widget.form.FormButtonBinding;
import com.extjs.gxt.ui.client.widget.form.FormPanel;
import com.extjs.gxt.ui.client.widget.form.Radio;
import com.extjs.gxt.ui.client.widget.form.RadioGroup;
import com.extjs.gxt.ui.client.widget.form.SliderField;
import com.extjs.gxt.ui.client.widget.form.TextArea;
import com.extjs.gxt.ui.client.widget.form.TextField;
import com.extjs.gxt.ui.client.widget.form.TimeField;
import com.extjs.gxt.ui.client.widget.form.ComboBox.TriggerAction;
import com.extjs.gxt.ui.client.widget.form.FormPanel.Encoding;
import com.extjs.gxt.ui.client.widget.form.FormPanel.Method;
import com.extjs.gxt.ui.client.widget.layout.FormData;
import com.extjs.gxt.ui.client.widget.toolbar.FillToolItem;

public class FileUploadDialog extends Dialog {

	private FormData formData = new FormData("-20");
	FormPanel form;
	protected Button upload;
	protected Status status;

	public FileUploadDialog() {

		setWidth(350);
		setButtons("");
		// setIcon(IconHelper.createStyle("user"));
		setHeading("Maksud App Login");
		setModal(true);
		setBodyBorder(true);
		setBodyStyle("padding: 8px;background: none");
		setResizable(false);

		form = new FormPanel();
		form.setHeaderVisible(false);
		form.setWidth(340);
		form.setHeading("File Upload");
		form.setFrame(false);
		form.setAction("/fileupload");
		form.setEncoding(Encoding.MULTIPART);
		form.setMethod(Method.POST);
		form.setButtonAlign(HorizontalAlignment.CENTER);

		TextField<String> title = new TextField<String>();
		title.setFieldLabel("Title");
		title.setAllowBlank(false);
		form.add(title, formData);

		FileUploadField file = new FileUploadField();
		file.setAllowBlank(false);
		file.setFieldLabel("File");
		file.setName("fupload");
		form.add(file);

		form.addListener(Events.Submit, new Listener<FormEvent>() {
			public void handleEvent(FormEvent be) {
				// status.setVisible(false);
				String html = be.getResultHtml();

				try {
					// JSONValue jsonValue = JSONParser.parse(html);
					MessageBox.info("Uploaded", html, null);

				} catch (Exception e) {
					MessageBox.info("Exception", e.getMessage(), null);
				}

			}
		});

		this.add(form);

	}

	@Override
	protected void createButtons() {
		super.createButtons();
		status = new Status();
		status.setBusy("please wait...");
		status.hide();
		status.setAutoWidth(true);
		getButtonBar().add(status);

		getButtonBar().add(new FillToolItem());

		upload = new Button("Upload");
		upload.addSelectionListener(new SelectionListener<ButtonEvent>() {
			public void componentSelected(ButtonEvent ce) {
				// onSubmit(AppEvents.RegistrationDialog);
			}
		});

		upload.addSelectionListener(new SelectionListener<ButtonEvent>() {
			@Override
			public void componentSelected(ButtonEvent ce) {
				if (!form.isValid()) {
					return;
				}
				form.submit();
				// MessageBox.info("Action", "You file was uploaded", null);
			}
		});
		addButton(upload);
	}

}
