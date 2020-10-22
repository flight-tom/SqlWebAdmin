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
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SqlAdmin
{
	/// <summary>
	/// Describes a User of this tool.
	/// </summary>
	[Serializable]
	public class AdminUser
	{
		/// <summary>
		/// Constructor for Sql authentication.
		/// </summary>
		public AdminUser(string username, string password, string server, bool useIntegratedSecurity) {
			this.username = username;
			this.password = password;
			this.server = server;
			this.useIntegratedSecurity = useIntegratedSecurity;
		}

		private string username;
		/// <summary>
		/// The Sql Username used for this user on the selected server.
		/// </summary>
		public string Username {
			get {return username;}
		}

		private string password = String.Empty;
		/// <summary>
		/// The Sql Password used for this user on the selected server.
		/// </summary>
		/// <remarks>
		/// This property is not used for Integrated Security.
		/// </remarks>
		public string Password {
			get {return password;}
		}

		private string server;
		/// <summary>
		/// The Sql Server this user is administering.
		/// </summary>
		public string Server {
			get {return server;}
		}

		private bool useIntegratedSecurity;
		/// <summary>
		/// Determines whether or not to use Integrated Security for the selected servers Authentication.
		/// </summary>
		public bool UseIntegratedSecurity {
			get {return useIntegratedSecurity;}
		}

		/// <summary>
		/// Returns or Sets the current user based on the current HttpContext.
		/// </summary>
		public static AdminUser CurrentUser {
			get { return HttpContext.Current.Session["CurrentUser"] as AdminUser;}
			set { HttpContext.Current.Session["CurrentUser"] = value; }
		}
	}
}
