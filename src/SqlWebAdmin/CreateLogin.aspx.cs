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
	public partial class CreateLogin : System.Web.UI.Page
	{


		protected void AuthType_Changed(object sender, EventArgs e) 
		{
			if (AuthType.SelectedValue == "Standard") 
			{
				Password.Enabled = true;
				PasswordLabel.Enabled = true;
			} 
			else 
			{
				Password.Enabled = false;
				PasswordLabel.Enabled = false;
			}
		}

		protected void AddLogin_Click(object sender, EventArgs e) 
		{
			if (Page.IsValid) 
			{
				SqlLoginCollection logins;
				SqlServer server = SqlServer.CurrentServer;
				server.Connect();

				if ( server.IsUserValid() ) 
				{
					logins = server.Logins;
					try 
					{
						SqlLogin newLogin = logins.Add(
							LoginName.Text.Trim(), 
							(SqlLoginType)Enum.Parse(typeof(SqlLoginType), AuthType.SelectedValue), 
							Password.Text.Trim()
							);
				
						// Redirect user to the edit screen so they can edit more properties
						Response.Redirect("EditServerLogin.aspx?Login=" + newLogin.Name);
					} 
					catch (Exception ex) 
					{
						ErrorMessage.Text = ex.Message;
					}
				}

				server.Disconnect();
			}
		}
	}
}
