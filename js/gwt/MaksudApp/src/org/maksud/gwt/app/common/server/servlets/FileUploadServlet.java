package org.maksud.gwt.app.common.server.servlets;

import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.util.Date;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.fileupload.FileItemIterator;
import org.apache.commons.fileupload.FileItemStream;
import org.apache.commons.fileupload.FileUploadBase.SizeLimitExceededException;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.IOUtils;
import org.maksud.gwt.app.common.client.rpc.MyResponseResult;
import org.maksud.gwt.app.common.client.rpc.MyServerResponse;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UploadedFile;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;

import com.google.appengine.api.datastore.Blob;
import com.google.appengine.api.datastore.KeyFactory;

public class FileUploadServlet extends HttpServlet {
	private static final long serialVersionUID = 3862214295751771516L;

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		try {
			MyServerResponse maResp = new MyServerResponse();

			// res.setContentType("application/octet-stream");
			res.setContentType("text/html");
			ServletFileUpload upload = new ServletFileUpload();
			upload.setSizeMax(500000);

			try {
				FileItemIterator iterator = upload.getItemIterator(req);
				while (iterator.hasNext()) {
					FileItemStream item = iterator.next();
					InputStream in = item.openStream();

					if (item.isFormField()) {
						// out.println("Got a form field: " +
						// item.getFieldName());
					} else {
						try {
							PersistenceManager pm = PMF.get().getPersistenceManager();

							UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), "maksud"));

							if (user == null) {

							}

							UploadedFile fileEntity = new UploadedFile();
							fileEntity.setUploader(user.getId());

							byte[] data = IOUtils.toByteArray(in);
							fileEntity.setData(new Blob(data));
							fileEntity.setDate(new Date());
							fileEntity.setFilename(item.getName());
							fileEntity.setFilesize(data.length);
							fileEntity.setFiletype(item.getContentType());

							// Save The file into database
							pm.makePersistent(fileEntity);

							maResp.setResult(MyResponseResult.Success);

							/*
							 * for (int i = 0; i < file.length; i++) {
							 * out.write((file[i] & 0xFF)); }
							 */
							// out.write(fileContents);
							// out.print(fileContents);
							// out.print();
						} catch (Exception e) {
							maResp.setResult(MyResponseResult.Fail);
							maResp.setData(e.getMessage());
						} finally {
							IOUtils.closeQuietly(in);
						}

					}
				}
			} catch (SizeLimitExceededException e) {
				maResp.setResult(MyResponseResult.Fail);
				maResp.setData(e.getMessage());
				// out.print(e.getMessage());
				// out.println("You exceeded the maximu size (" +
				// e.getPermittedSize() + ") of the file (" + e.getActualSize()
				// + ")");
			}
			//out.print("S");
		} catch (Exception ex) {
			throw new ServletException(ex);
		}

	}
}
