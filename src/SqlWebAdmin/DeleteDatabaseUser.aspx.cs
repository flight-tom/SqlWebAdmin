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
	public partial class DeleteDatabaseUser : System.Web.UI.Page
	{

		protected void Yes_Click(object sender, EventArgs e) 
		{
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);
			database.Users[Request["user"]].Remove();
			
			server.Disconnect();
			Response.Redirect("DatabaseUsers.aspx?database=" + Request["database"]);
		}

		protected void No_Click(object sender, EventArgs e) 
		{
			Response.Redirect("DatabaseUsers.aspx?database=" + Request["database"]);
		}

		protected override void OnLoad(EventArgs e)
		{
			UserLabel.Text = Request["user"];

			base.OnLoad (e);
		}

	}
}
