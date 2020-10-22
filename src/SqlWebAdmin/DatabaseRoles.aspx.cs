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
	public partial class DatabaseRoles : System.Web.UI.Page
	{
		//protected HyperLink CreateRoleLink;
		
		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				SqlServer server = SqlServer.CurrentServer;
				server.Connect();

				SqlDatabase database = SqlDatabase.CurrentDatabase(server);
				
				RolesGrid.DataSource = database.DatabaseRoles;
				RolesGrid.DataBind();

				//CreateRoleLink.NavigateUrl="CreateDatabaseRole.aspx?database=" + Request["database"];

				server.Disconnect();
			}
			base.OnLoad (e);
		}

	}
}
