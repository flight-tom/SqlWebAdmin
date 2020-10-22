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
using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;
using SqlAdmin;

namespace SqlWebAdmin {
    public class Global : System.Web.HttpApplication {

			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;

        protected void Application_Error(Object sender, EventArgs e) {
            Application.Add("Error", Server.GetLastError());
       }

			protected void Application_AuthenticateRequest(Object sender, EventArgs e) {

				if (Context.User == null ) {
				
					String cookieName = FormsAuthentication.FormsCookieName;
					HttpCookie authCookie = Context.Request.Cookies[cookieName];
		
					if(null == authCookie) {
						//There is no authentication cookie.
						return;
					}
					FormsAuthenticationTicket authTicket = null;
					try {
						authTicket = FormsAuthentication.Decrypt(authCookie.Value);
					}
					catch (Exception ex) {
						//Write the exception to the Event Log.
						return;
					}
					if(null == authTicket) {
						//Cookie failed to decrypt.
						return;		
					}		

					string[] loginType = authTicket.UserData.Split(new char[]{','});;
					GenericIdentity id = new GenericIdentity(authTicket.Name, "webAuth");
					//This principal flows throughout the request.
					GenericPrincipal principal = new GenericPrincipal(id, loginType);
					Context.User = principal;
				
				
				}
				 //Context.User = (System.Security.Principal.IPrincipal)System.Security.Principal.WindowsIdentity.GetCurrent();

			}
            protected void Session_End(Object sender, EventArgs e)
            {
                SqlServer server = SqlServer.CurrentServer;           

                SqlDatabase database = SqlDatabase.CurrentDatabase(server);
                server = null;
                database = null;
            }

			public Global() {
				InitializeComponent();
			}	

			#region Web Form Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent() {    
				this.components = new System.ComponentModel.Container();
			}
			#endregion
    }
}

//<%@ Application Inherits="SqlWebAdmin.Global" Language="C#" %>