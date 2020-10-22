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
	public partial class CreateDatabaseRole : System.Web.UI.Page
	{
		protected ItemPicker RoleUsers;
		protected TextBox RolePassword;

		protected void CreateRole_Click(object sender, EventArgs e) 
		{
			if (Page.IsValid) 
			{
				try 
				{
					SqlServer server = SqlServer.CurrentServer;
					server.Connect();

					SqlDatabase database = SqlDatabase.CurrentDatabase(server);

					// TODO: Finish

					server.Disconnect();
				} 
				catch (Exception ex) 
				{
					ErrorMessage.Text = ex.Message;
				}
			}
		}
	}
}
