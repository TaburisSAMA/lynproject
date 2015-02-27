/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package org.maksud.gwt.app.common.client.images;

import com.google.gwt.user.client.ui.AbstractImagePrototype;
import com.google.gwt.user.client.ui.ImageBundle;

/**
 *
 * @author Administrator
 */

public interface IconSet extends ImageBundle {

  @Resource("add.png")
  AbstractImagePrototype add();

  @Resource("find.png")
  AbstractImagePrototype find();

  @Resource("save.png")
  AbstractImagePrototype save();

  @Resource("save.png")
  AbstractImagePrototype update();

}
