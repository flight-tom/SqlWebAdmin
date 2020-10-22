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
	/// <summary>
	/// Summary description for Logins.
	/// </summary>
	public partial class ServerLogins : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e) {
			SqlServer server = SqlServer.CurrentServer;
			SqlAdmin.SqlLogin login;
			server.Connect();
			SqlLoginCollection logins = server.Logins;
			server.Disconnect();

			// Create DataSet from list of databases
			DataSet ds = new DataSet();
			ds.Tables.Add();
			ds.Tables[0].Columns.Add("Name");
			ds.Tables[0].Columns.Add("LoginType");
			ds.Tables[0].Columns.Add("NTLoginAccessType");
			ds.Tables[0].Columns.Add("Database");
			ds.Tables[0].Columns.Add("LanguageAlias");
			

			for (int i = 0; i < logins.Count; i++) {
				
				login = logins[i];

				ds.Tables[0].Rows.Add(
					new object[] {
					Server.HtmlEncode(login.Name), 
					Server.HtmlEncode(login.LoginType.ToString()),
					Server.HtmlEncode(login.NTLoginAccessType.ToString()),
					Server.HtmlEncode(login.Database.ToString()),
					Server.HtmlEncode(login.LanguageAlias.ToString()),
							
				});
			
			}
			
			LoginDataGrid.DataSource = ds;
			LoginDataGrid.DataBind();
		
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
