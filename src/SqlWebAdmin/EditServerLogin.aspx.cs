using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SqlAdmin;

namespace SqlWebAdmin
{

	public partial class EditServerLogin : System.Web.UI.Page
	{
		
		SqlLogin sqlLogin = null;
		SqlDatabaseCollection databases = null;
		SqlServerRoleCollection allRoles = null;

		protected override void OnLoad(EventArgs e)
		{
			if (Request["Login"] == null)
				Response.Redirect("CreateLogin.aspx");
			
			LoginLabel.Text = Request["Login"].ToUpper();
		
			if (!Page.IsPostBack) 
			{
				SqlServer server = SqlServer.CurrentServer;
				server.Connect();
				
				sqlLogin = server.Logins[Request["Login"]];

				if (sqlLogin == null)
					Response.Redirect("CreateLogin.aspx");

				if (sqlLogin.LoginType == SqlLoginType.NTUser || sqlLogin.LoginType == SqlLoginType.NTGroup) 
				{
					SecurityAccess.Enabled = true;
					SecurityAccessLabel.Enabled = true;
					
					if (sqlLogin.NTLoginAccessType == SqlNtAccessType.Deny) 
					{
						SecurityAccess.Items[1].Selected = true;
					} 
					else 
					{
						SecurityAccess.Items[0].Selected = true;
					}
				}

				databases = server.Databases;

				DefaultDatabase.DataSource = databases;
				DefaultDatabase.DataBind();

				DatabaseAccessGrid.DataSource = databases;
				DatabaseAccessGrid.DataBind();

				// Select default database
				ListItem databaseItem = DefaultDatabase.Items.FindByValue(sqlLogin.Database);
				if (databaseItem != null) 
				{
					databaseItem.Selected = true;	
				} 
				else 
				{
					databaseItem = DefaultDatabase.Items.FindByValue("master");
					if (databaseItem != null)
						databaseItem.Selected = true;
				}

				allRoles = server.Roles;
				
				ServerRoles.DataSource = allRoles;
				ServerRoles.DataBind();

				// Select member roles
				foreach(ListItem item in ServerRoles.Items) 
				{
					if (sqlLogin.IsMember(item.Value)) 
					{
						item.Selected = true;
					}
				}

				DefaultLanguage.DataSource = server.Languages;
				DefaultLanguage.DataBind();

				// Select default language
				ListItem languageItem = DefaultLanguage.Items.FindByValue(sqlLogin.Language);
				if (languageItem != null) 
				{
					languageItem.Selected = true;
				} 
				else 
				{
					languageItem = DefaultLanguage.Items.FindByValue("English");
					if (languageItem != null)
						languageItem.Selected = true;
				}

				server.Disconnect();
				focusPanel(GeneralPanel);
			}
			base.OnLoad(e);
		}

		protected void DatabaseAccessGrid_ItemCommand(object sender, DataGridCommandEventArgs e) 
		{
			switch (e.CommandName) 
			{
				case "EditRoles":
					if (this.Save()) 
					{
						Response.Redirect("DatabaseRoles.aspx?database=" + (string)DatabaseAccessGrid.DataKeys[e.Item.ItemIndex]);
					}
					break;
			}
		}

		protected void DatabaseAccessGrid_Databound(object sender, DataGridItemEventArgs e) 
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item) 
			{
				SqlDatabase database = databases[(string)DatabaseAccessGrid.DataKeys[e.Item.ItemIndex]];

				if (sqlLogin.GetUserName(database.Name) != null) 
				{
					CheckBox cb = e.Item.FindControl("DatabaseAccess")  as CheckBox;
					if (cb != null)
						cb.Checked = true;
				}
			}
		}

		protected void Sections_Changed(object sender, EventArgs e) 
		{
			switch(Sections.SelectedValue) 
			{
				case "General":
					focusPanel(GeneralPanel);
					break;
				case "Roles":
					focusPanel(RolesPanel);
					break;
				case "Databases":
					focusPanel(DatabasesPanel);
					break;

			}
		}

		protected void Save_Click(object sender, EventArgs e) 
		{
			if (this.Save()) 
			{
				Response.Redirect("ServerLogins.aspx");
			}
		}

		private bool Save() 
		{
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();
			
			try 
			{
				// Save Login settings
				sqlLogin = server.Logins[Request["Login"]];

				if (SecurityAccess.Enabled) 
				{
					sqlLogin.DenyNTLogin = SecurityAccess.SelectedValue=="Deny"?true:false;
				}
			
				sqlLogin.Database = DefaultDatabase.SelectedValue;
				sqlLogin.Language = DefaultLanguage.SelectedValue;

				// Save server roles
				foreach(ListItem item in ServerRoles.Items) 
				{
					if (sqlLogin.IsMember(item.Value) && !item.Selected) 
					{
						server.Roles[item.Value].DropMember(sqlLogin.Name);
					} 
					else if (!sqlLogin.IsMember(item.Value) && item.Selected) 
					{
						server.Roles[item.Value].AddMember(sqlLogin.Name);
					}
				}

				databases = server.Databases;

				// Save database access
				foreach(DataGridItem item in DatabaseAccessGrid.Items) 
				{
					SqlDatabase database = databases[(string)DatabaseAccessGrid.DataKeys[item.ItemIndex]];
					CheckBox cb = item.FindControl("DatabaseAccess") as CheckBox;
					if (database != null && cb != null) 
					{
						string dbName = sqlLogin.GetUserName(database.Name);
						if (dbName != null && !cb.Checked) 
						{
							database.Users[dbName].Remove();
						} 
						else if (dbName == null && cb.Checked)
						{
							database.Users.Add(sqlLogin.Name, sqlLogin.Name);
						}
					}
				}
			} 
			catch (Exception ex) 
			{
				ErrorMessage.Text = ex.Message;
				return false;
			} 
			finally 
			{
				server.Disconnect();
			}
			return true;
		}

		private void focusPanel(Panel focusPanel) 
		{
			Panel[] panels = new Panel[]{GeneralPanel, RolesPanel, DatabasesPanel};
			foreach(Panel panel in panels) 
			{
				panel.Visible = false;
			}

			focusPanel.Visible = true;
		}
	}
}
