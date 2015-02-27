package org.maksud.gwt.app.common.client.rpc;

public class MyServerResponse {
	int result;
	Object data;

	public MyServerResponse() {
		this.data = null;
	}

	public MyServerResponse(int result, Object data) {
		super();
		this.result = result;
		this.data = data;
	}

	public int getResult() {
		return result;
	}

	public void setResult(int result) {
		this.result = result;
	}

	public Object getData() {
		return data;
	}

	public void setData(Object data) {
		this.data = data;
	}
}
