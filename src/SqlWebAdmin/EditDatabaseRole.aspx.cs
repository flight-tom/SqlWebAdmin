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
using SqlAdmin.Controls;

namespace SqlWebAdmin
{
	public partial class EditDatabaseRole : System.Web.UI.Page
	{

		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				if (Request["role"] == null)
					Response.Redirect("DatabaseRoles.aspx?database=" + Request["database"]);

				SqlServer server = SqlServer.CurrentServer;
				server.Connect();

				SqlDatabase database = SqlDatabase.CurrentDatabase(server);

				SqlDatabaseRole role = database.DatabaseRoles[Request["role"]];
				if (role == null)
					Response.Redirect("DatabaseRoles.aspx?database=" + Request["database"]);

				RoleNameLabel.Text = role.Name;
				RoleTypeLabel.Text = role.AppRole?"Application":"Standard";

				if (role.AppRole) 
				{
					ApplicationRolePanel.Visible = true;
				} 
				else 
				{
					StandardRolePanel.Visible = true;
					// Parse out names from Users
					ArrayList userNames = new ArrayList();
					foreach (SqlUser user in database.Users) 
					{
						userNames.Add(user.Name);
					}
					RoleUsers.DataSource = userNames;
					RoleUsers.DataBind();

					foreach(ListItem item in RoleUsers.Items) 
					{
						foreach(string name in role.GetDatabaseRoleMembers()) 
						{
							if (item.Value == name) 
							{
								item.Selected = true;
								break;
							}
						}
					}
				}

				server.Disconnect();
			}
			base.OnLoad (e);
		}

		protected void Save_Click(object sender, EventArgs e) 
		{
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();
			try 
			{
				SqlDatabase database = SqlDatabase.CurrentDatabase(server);
				SqlDatabaseRole role = database.DatabaseRoles[Request["Role"]];

				foreach(ListItem item in RoleUsers.Items) 
				{
					SqlUser user = database.Users[item.Value];
					if (user.IsMember(role.Name) && !item.Selected) 
					{
						role.DropMember(user.Name);
					} 
					else if (!user.IsMember(role.Name) && item.Selected)
					{
						role.AddMember(role.Name);
					}
				}
			} 
			catch (Exception ex) 
			{
				ErrorMessage.Text = ex.Message;
				return;
			} 
			finally 
			{
				server.Disconnect();
			}

			Response.Redirect("DatabaseRoles.aspx?database=" + Request["database"]);
		}
	}
}
