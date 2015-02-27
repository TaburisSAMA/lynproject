package org.maksud.gwt.app.common.server.model.jdo.entities;

import java.util.Date;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

import com.google.appengine.api.datastore.Blob;
import com.google.appengine.api.datastore.Key;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class UploadedFile {
	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Long id;

	@Persistent
	private String filename;

	@Persistent
	private long filesize;

	@Persistent
	private String filetype;

	@Persistent
	private Key uploader;

	@Persistent
	private Date date;

	@Persistent
	private Blob data;

	public UploadedFile() {
	}

	public UploadedFile(String fullname, Key uploader, byte[] data) {
		this.filename = fullname;
		this.filesize = data.length;
		this.filetype = "oct";
		this.uploader = uploader;
		this.data = new Blob(data);
		this.date = new Date();
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}

	public long getFilesize() {
		return filesize;
	}

	public void setFilesize(long filesize) {
		this.filesize = filesize;
	}

	public String getFiletype() {
		return filetype;
	}

	public void setFiletype(String filetype) {
		this.filetype = filetype;
	}

	public Key getUploader() {
		return uploader;
	}

	public void setUploader(Key uploader) {
		this.uploader = uploader;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public Blob getData() {
		return data;
	}

	public void setData(Blob data) {
		this.data = data;
	}

}
