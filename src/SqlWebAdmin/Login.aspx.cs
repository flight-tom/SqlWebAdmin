//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2003  Microsoft Corporation.  All rights reserved.
//
//=====================================================================
using SqlAdmin;
using System;
using System.Web.UI;

namespace SqlWebAdmin {
    /// <summary>
    /// Summary description for Login.
    /// </summary>
    public partial class Login : Page {
        readonly Security security = new Security();

		public Login() {
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, EventArgs e) {


			if (ServerTextBox.Text != null && ServerTextBox.Text.Length == 0) {
				ServerTextBox.Text = ".\\SQLEXPRESS"; // "localhost";
			}

			ErrorLabel.Visible = false;
			LogoutInfoLabel.Visible = false;
			LoginInfoLabel.Visible = false;

			if (Request["error"] != null) {
				switch (Request["error"]) {
					case "sessionexpired":
						ErrorLabel.Text = "Your session has expired or you have already logged out. Please enter your login info again to reconnect.";
						break;
					case "userinfo":
						ErrorLabel.Text = "Invalid username and/or password, or server does not exist.";
						break;
					default:
						ErrorLabel.Text = "An unknown error occured.";
						break;
				}
				ErrorLabel.Visible = true;
			}
			else if (Request["action"] == "logout") {
				LogoutInfoLabel.Visible = true;
			}
			else {
				LoginInfoLabel.Visible = true;
			}
		}

		protected void Page_Init(object sender, EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
		}
		#endregion

		protected void LoginButton_Click(object sender, EventArgs e) {
			if (!IsValid)
				return;

			bool useIntegrated;
			SqlServer server;
			SqlAdmin.Security security = new SqlAdmin.Security();

			if (AuthRadioButtonList.SelectedItem.Value == "windows") {

				if (security.WebServer == "iis" && System.Security.Principal.WindowsIdentity.GetCurrent().Name != this.UsernameTextBox.Text) {

					ErrorLabel.Visible = true;
					ErrorLabel.Text = "IIS verion of SQL Web Admin doesn't support windows logins other than your own.<br>";

				}

				try {

					server = new SqlServer(ServerTextBox.Text, this.UsernameTextBox.Text, this.PasswordTextBox.Text, true);
					useIntegrated = true;

				}
				catch (System.ComponentModel.Win32Exception w32Ex) {

					ErrorLabel.Visible = true;
					ErrorLabel.Text = "Invalid username and/or password, or server does not exist.";
					return;

				}
				catch (Exception ex) {

					ErrorLabel.Visible = true;
					ErrorLabel.Text = ex.Message;
					return;
				}

			}
			else {
				server = new SqlServer(ServerTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, false);
				useIntegrated = false;

			}

			if (server.IsUserValid()) {
				if (useIntegrated) {
					AdminUser.CurrentUser = new AdminUser(UsernameTextBox.Text, PasswordTextBox.Text, ServerTextBox.Text, true);

					security.WriteCookieForFormsAuthentication(
						server.Username,
						server.Password,
						false,
						SqlLoginType.NTUser);
				}
				else {
					AdminUser.CurrentUser = new AdminUser(UsernameTextBox.Text, PasswordTextBox.Text, ServerTextBox.Text, false);

					security.WriteCookieForFormsAuthentication(
						server.Username,
						server.Password,
						false,
						SqlLoginType.Standard);
				}



				Response.Redirect("databases.aspx");
			}
			else {
				ErrorLabel.Visible = true;
				ErrorLabel.Text = "Invalid username and/or password, you are using a windows login that is not your own, or server does not exist.<br>";
			}
		}

		protected void AuthRadioButtonList_SelectedIndexChanged(object sender, EventArgs e) {

			string authMethod = AuthRadioButtonList.SelectedItem.Value;

			switch (authMethod) {
				case "sql":
					UsernameTextBox.Text = "";
					UsernameTextBox.Enabled = true;
					PasswordTextBox.Enabled = true;
					break;
				default:

					break;
			}
		}
	}
}
