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
	public partial class DatabaseUsers : System.Web.UI.Page
	{

		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				SqlServer server = SqlServer.CurrentServer;
				server.Connect();

				SqlDatabase database = SqlDatabase.CurrentDatabase(server);

				UsersGrid.DataSource = database.Users;
				UsersGrid.DataBind();

				CreateUserLink.NavigateUrl="CreateDatabaseUser.aspx?database=" + database.Name;

				server.Disconnect();
			}
			base.OnLoad (e);
		}

	}
}
