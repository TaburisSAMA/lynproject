package org.maksud.gwt.app.maksudapp.client.widget;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Basic;

import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.model.*;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.data.ModelData;
import com.extjs.gxt.ui.client.store.ListStore;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.LayoutContainer;
import com.extjs.gxt.ui.client.widget.grid.ColumnConfig;
import com.extjs.gxt.ui.client.widget.grid.ColumnData;
import com.extjs.gxt.ui.client.widget.grid.ColumnModel;
import com.extjs.gxt.ui.client.widget.grid.Grid;
import com.extjs.gxt.ui.client.widget.grid.GridCellRenderer;
import com.extjs.gxt.ui.client.widget.layout.FitLayout;
import com.extjs.gxt.ui.client.widget.layout.FlowLayout;
import com.extjs.gxt.ui.client.widget.table.NumberCellRenderer;
import com.google.gwt.i18n.client.DateTimeFormat;
import com.google.gwt.i18n.client.NumberFormat;
import com.google.gwt.user.client.Element;
import com.google.gwt.user.client.rpc.AsyncCallback;

public class UserGridSample extends LayoutContainer {

	@Override
	protected void onRender(Element parent, int index) {
		super.onRender(parent, index);
		setLayout(new FlowLayout(10));

		final List<ColumnConfig> configs = new ArrayList<ColumnConfig>();

		ColumnConfig column;
		configs.add(new ColumnConfig("login", "UserId", 100));

		column = new ColumnConfig("name", "Name", 150);
		configs.add(column);

		column = new ColumnConfig("email", "Email", 200);
		configs.add(column);

		column = new ColumnConfig("url", "Website", 200);
		configs.add(column);

		column = new ColumnConfig("register_date", "Date Joined", 200);
		column.setAlignment(HorizontalAlignment.RIGHT);
		column.setDateTimeFormat(DateTimeFormat.getShortDateFormat());
		configs.add(column);

		column = new ColumnConfig("status", "Status", 200);
		configs.add(column);

		/*
		 * final NumberFormat number = NumberFormat.getFormat("0.00");
		 * GridCellRenderer<Employee> checkSalary = new GridCellRenderer() {
		 * 
		 * public String render(Employee model, String property, ColumnData
		 * config, int rowIndex, int colIndex, ListStore<Employee> employeeList,
		 * Grid<Employee> grid) { double val = (Double) model.get(property); //
		 * String style = val < 70000 ? "red" : "green"; return "" +
		 * number.format(val) + ""; }
		 * 
		 * @Override public Object render(ModelData model, String property,
		 * ColumnData config, int rowIndex, int colIndex, ListStore store, Grid
		 * grid) { double val = (Double) model.get(property); // String style =
		 * val < 70000 ? "red" : "green"; return "" + number.format(val) + ""; }
		 * }; column.setRenderer(checkSalary); configs.add(column);
		 */

		// BasicRPC.Util.getInstance().getEmployees(new
		// AsyncCallback<List<Employee>>() {
		//
		// @Override
		// public void onSuccess(List<Employee> employees) {
		// ListStore<Employee> employeeList = new ListStore<Employee>();
		// employeeList.add(employees);
		//
		// ColumnModel cm = new ColumnModel(configs);
		// Grid<Employee> grid = new Grid<Employee>(employeeList, cm);
		// grid.setStyleAttribute("borderTop", "none");
		// grid.setAutoExpandColumn("name");
		// grid.setBorders(true);
		// grid.setStripeRows(true);
		//
		// ContentPanel cp = new ContentPanel();
		// cp.setBodyBorder(false);
		// cp.setHeading("Employee List");
		// cp.setButtonAlign(HorizontalAlignment.CENTER);
		// cp.setLayout(new FitLayout());
		// cp.setSize(700, 300);
		// cp.add(grid); //
		// add(cp);
		//
		// }
		//
		// @Override
		// public void onFailure(Throwable caught) {
		//
		// }
		// });

		final UserGridSample self = this;

		BasicRPC.Util.getInstance().getUsers(new AsyncCallback<List<User>>() {

			@Override
			public void onSuccess(List<User> result) {
				try

				{
					final ListStore<User> store = new ListStore<User>();
					store.add(result);

					ContentPanel cp = new ContentPanel();
					cp.setBodyBorder(false);
					// cp.setIcon(Examples.ICONS.table());
					cp.setHeading("Users");
					cp.setButtonAlign(HorizontalAlignment.CENTER);
					cp.setLayout(new FitLayout());
					cp.setSize(600, 300);

					ColumnModel cm = new ColumnModel(configs);
					Grid<User> grid = new Grid<User>(store, cm);
					grid.setStyleAttribute("borderTop", "none");
					grid.setAutoExpandColumn("login");
					grid.setBorders(true);
					grid.setStripeRows(true);

					cp.add(grid);
					self.add(cp);
				} catch (Exception e) {
					System.out.println("Exception:  " + e.getMessage());
				}
			}

			@Override
			public void onFailure(Throwable caught) {
				System.out.println("Failure:  " + caught.getMessage());
			}
		});

		/*
		 * final NumberFormat currency = NumberFormat.getCurrencyFormat(); final
		 * NumberFormat number = NumberFormat.getFormat("0.00"); final
		 * NumberCellRenderer<Grid<UserEntity>> numberRenderer = new
		 * NumberCellRenderer<Grid<UserEntity>>(currency);
		 * 
		 * GridCellRenderer<UserEntity> change = new
		 * GridCellRenderer<UserEntity>() { public String render(UserEntity
		 * model, String property, ColumnData config, int rowIndex, int
		 * colIndex, ListStore<UserEntity> store, Grid<UserEntity> grid) {
		 * double val = (Double) model.get(property); String style = val < 0 ?
		 * "red" : "green"; return "<span style='color:" + style + "'>" +
		 * number.format(val) + "</span>"; } };
		 * 
		 * GridCellRenderer<UserEntity> gridNumber = new
		 * GridCellRenderer<UserEntity>() { public String render(UserEntity
		 * model, String property, ColumnData config, int rowIndex, int
		 * colIndex, ListStore<UserEntity> store, Grid<UserEntity> grid) {
		 * return numberRenderer.render(null, property, model.get(property)); }
		 * };
		 * 
		 * final List<ColumnConfig> configs = new ArrayList<ColumnConfig>();
		 * 
		 * ColumnConfig column = new ColumnConfig(); column.setId("name");
		 * column.setHeader("Company"); column.setWidth(200);
		 * configs.add(column);
		 * 
		 * column = new ColumnConfig(); column.setId("symbol");
		 * column.setHeader("Symbol"); column.setWidth(100);
		 * configs.add(column);
		 * 
		 * column = new ColumnConfig(); column.setId("last");
		 * column.setHeader("Last");
		 * column.setAlignment(HorizontalAlignment.RIGHT); column.setWidth(75);
		 * column.setRenderer(gridNumber); configs.add(column);
		 * 
		 * column = new ColumnConfig("change", "Change", 100);
		 * column.setAlignment(HorizontalAlignment.RIGHT);
		 * column.setRenderer(change); configs.add(column);
		 * 
		 * column = new ColumnConfig("date", "Last Updated", 100);
		 * column.setAlignment(HorizontalAlignment.RIGHT);
		 * column.setDateTimeFormat(DateTimeFormat.getShortDateFormat());
		 * configs.add(column);
		 * 
		 * final ListStore<UserEntity> store = new ListStore<UserEntity>();
		 * 
		 * 
		 * BasicRPC.Util.getInstance().getUsers(new
		 * AsyncCallback<List<UserEntity>>() {
		 * 
		 * @Override public void onSuccess(List<UserEntity> result) { // TODO
		 * Auto-generated method stub store.add(result); ColumnModel cm = new
		 * ColumnModel(configs);
		 * 
		 * ContentPanel cp = new ContentPanel(); cp.setBodyBorder(false);
		 * //cp.setIcon(Examples.ICONS.table()); cp.setHeading("Basic Grid");
		 * cp.setButtonAlign(HorizontalAlignment.CENTER); cp.setLayout(new
		 * FitLayout()); cp.setSize(600, 300);
		 * 
		 * Grid<UserEntity> grid = new Grid<UserEntity>(store, cm);
		 * grid.setStyleAttribute("borderTop", "none");
		 * grid.setAutoExpandColumn("name"); grid.setBorders(true);
		 * grid.setStripeRows(true); cp.add(grid);
		 * 
		 * add(cp);
		 * 
		 * }
		 * 
		 * @Override public void onFailure(Throwable caught) { // TODO
		 * Auto-generated method stub
		 * 
		 * } });
		 */
	}
}