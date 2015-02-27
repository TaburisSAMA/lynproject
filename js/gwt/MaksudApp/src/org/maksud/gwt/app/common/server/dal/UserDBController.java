package org.maksud.gwt.app.common.server.dal;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.logging.Logger;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.client.model.UserDetail;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;

import com.google.appengine.api.datastore.KeyFactory;

public class UserDBController {
    private static final Logger log = Logger.getLogger(UserDBController.class
	    .getName());

    public static List<UserEntity> getAllUserEntity() {
	return getUserList("select from " + UserEntity.class.getName());
    }

    public static UserEntity getUserEntity(String userid) {
	try {
	    PersistenceManager pm = PMF.get().getPersistenceManager();
	    UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class,
		    KeyFactory.createKey(UserEntity.class.getSimpleName(),
			    userid));
	    return user;
	} catch (Exception e) {
	    return null;
	}
    }

    private static List<UserEntity> getUserList(String query) {
	List<UserEntity> userEntities = new ArrayList<UserEntity>();
	try {
	    PersistenceManager pm = PMF.get().getPersistenceManager();
	    userEntities = (List<UserEntity>) pm.newQuery(query).execute();
	    System.err.println("Total Records Found: " + userEntities.size());
	} catch (Exception e) {
	    log.info("Problem Finding Users" + e.getMessage());
	} finally {
	}
	return userEntities;
    }

    public static boolean createUser(String userid, String password,
	    String retype, String email, String web, String activationKey) {
	try {
	    UserEntity user = new UserEntity();
	    user.setLogin(userid);
	    user.setEmail(email);
	    user.setPassword(password);
	    user.setLevel(new UserLevel());
	    user.setName(userid);
	    user.setRegister_date(new Date());
	    user.setStatus(new UserStatus());
	    user.setUrl(web);
	    user.setActivationKey(activationKey);
	    user.setId(KeyFactory.createKey(UserEntity.class.getSimpleName(),
		    user.getLogin()));

	    PersistenceManager pm = PMF.get().getPersistenceManager();
	    pm.makePersistent(user);
	    // pm.close();
	    return true;
	} catch (Exception exp) {
	    return false;
	}

    }

    public static boolean deleteUser(String userid) {
	try {
	    PersistenceManager pm = PMF.get().getPersistenceManager();
	    UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class,
		    KeyFactory.createKey(UserEntity.class.getSimpleName(),
			    userid));
	    pm.deletePersistent(user);
	    pm.close();
	    System.err.print("Deleted");
	    log.info("Delete User: " + userid);
	    return true;
	} catch (Exception e) {
	    System.err.print("Problem Deleting.. " + userid);
	    log.info("Problem Delete User: " + userid);
	    return false;
	}
    }

    public static boolean updateUser(UserEntity user) {

	try {
	    PMF.get().getPersistenceManager().makePersistent(user);
	    return true;
	} catch (Exception exp) {
	    return false;
	}
    }

    public static boolean updateUser(UserDetail pUser) {
	try {
	    PersistenceManager pm = PMF.get().getPersistenceManager();
	    UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class,
		    KeyFactory.createKey(UserEntity.class.getSimpleName(),
			    pUser.getUserId()));

	    user.setEmail(pUser.getEmail());
	    user.setLevel(pUser.getLevel());
	    user.setStatus(pUser.getStatus());
	    user.setName(pUser.getName());
	    user.setPassword(pUser.getPassword());
	    user.setUrl(pUser.getUrl());

	    pm.makePersistent(user);
	    // pm.close();
	    System.err.print("Updated");
	    log.info("Update User: " + pUser.getUserId());
	    return true;
	} catch (Exception e) {
	    System.err.print("Problem Updating.. ");
	    log.info("Problem Updating User: ");
	    return false;
	}
    }
}
