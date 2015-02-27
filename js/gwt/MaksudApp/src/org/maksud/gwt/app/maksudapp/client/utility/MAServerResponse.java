package org.maksud.gwt.app.maksudapp.client.utility;

public class MAServerResponse {

	MAResponseResult result;
	Object data;

	public MAServerResponse() {
		this.data = null;
	}

	public MAServerResponse(MAResponseResult result, Object data) {
		super();
		this.result = result;
		this.data = data;
	}

	public MAResponseResult getResult() {
		return result;
	}

	public void setResult(MAResponseResult result) {
		this.result = result;
	}

	public Object getData() {
		return data;
	}

	public void setData(Object data) {
		this.data = data;
	}

}
