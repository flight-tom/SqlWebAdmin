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

	public partial class EditServerRole : System.Web.UI.Page
	{
		protected ListBox CurrentLogins;

		protected void RoleLogins_Changed(object sender, ItemPickerEventArgs e) 
		{
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();
			try 
			{
				SqlServerRole role = server.Roles[Request["Role"]];
			
				switch (e.Action) 
				{
					case ItemAction.Add:
						role.AddMember(e.Item.Value);
						break;
					case ItemAction.Remove:
						role.DropMember(e.Item.Value);
						break;
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
		}

		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				if (Request["Role"] == null)
					Response.Redirect("ServerRoles.aspx");

				SqlServer server = SqlServer.CurrentServer;
				server.Connect();

				RoleLabel.Text = Request["Role"].ToUpper();
				SqlServerRole role = server.Roles[Request["Role"]];
				if (role == null)
					Response.Redirect("ServerRoles.aspx");

				ArrayList serverLoginNames = new ArrayList();
				foreach(SqlLogin login in server.Logins) 
				{
					serverLoginNames.Add(login.Name);
				}

				RoleLogins.Items = serverLoginNames;
				RoleLogins.SelectedItems = role.GetServerRoleMembers();

				server.Disconnect();
			}

			base.OnLoad(e);
		}

	}
}
