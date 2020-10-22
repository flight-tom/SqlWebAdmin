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
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Web;

namespace SqlAdmin {
	/// <summary>
	/// Represents a Microsoft SQL Server.
	/// </summary>
	public class SqlServer {

		internal NativeMethods.ISqlServer dmoServer;

		private string name;
		private string username;
		private string password;
		private bool IntegratedSecurity = false;
		Security security;

		/// <summary>
		/// Initializes a new instance of the SqlServer class.
		/// </summary>
		/// <param name="name">The name of the server (e.g. localhost)</param>
		/// <param name="username">The username to connect with</param>
		/// <param name="password">The password to connect with</param>
		public SqlServer(string name, string username, string password, bool useIntegrated) {
			string domain = null;
      string userName = null;
      
      this.name        = name;
			this.username    = username;
			this.password    = password;
			this.IntegratedSecurity = useIntegrated;

			if ( this.IntegratedSecurity ) {
  				security = new Security();
        try {
          domain = this.username.Split(char.Parse(@"\"))[0];
          userName = this.username.Split(char.Parse(@"\"))[1];
        } catch (Exception ex) {
          throw new ApplicationException(@"Username is formatted incorrectly. Please use computername\username");
        }
					security.Impersonate(userName, domain, this.password);
			}
		}
		/// <summary>
		/// Initializes a new instance of the SqlServer class.
		/// </summary>
		/// <param name="name">The name of the server (e.g. localhost)</param>
		public SqlServer(string name) {
			this.name = name;
			this.IntegratedSecurity = true;
		}


		/// <summary>
		/// Gets a collection of SqlDatabase objects that represent the individual databases on this server.
		/// </summary>
		/// <remarks>
		/// Only databases which the current user has permission to access will be listed.
		/// </remarks>
		public SqlDatabaseCollection Databases {
			get {
				SqlDatabaseCollection dbCollection = new SqlDatabaseCollection(this);
				dbCollection.Refresh();
				return dbCollection;
			}
		}

		/// <summary>
		/// Gets or sets the name of the server to connect to.
		/// </summary>
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		/// <summary>
		/// Gets or sets the password to connect with.
		/// </summary>
		public string Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}

		/// <summary>
		/// Gets or sets the username to connect with.
		/// </summary>
		public string Username {
			get {
				return username;
			}
			set {
				username = value;
			}
		}
			
		/// <summary>
		/// Collection contains ServerRole objects that enumerate the security administration units
		/// </summary>
		public SqlServerRoleCollection Roles {
			get {
				SqlServerRoleCollection dbRoles = new SqlServerRoleCollection(this);
				dbRoles.Refresh();
				return dbRoles;
			}
		}

		/// <summary>
		/// Gets Server level logins
		/// </summary>
		public SqlLoginCollection Logins {
			get {
		
				SqlLoginCollection dbLogins = new SqlLoginCollection(this);
				dbLogins.Refresh();
				return dbLogins;
		
			}

		}

		/// <summary>
		/// Contains Language objects referencing the language records 
		/// </summary>
		public SqlLanguageCollection Languages {
			get {
				SqlLanguageCollection dbLanguages = new SqlLanguageCollection(this);
				dbLanguages.Refresh();
				return dbLanguages;
			}
		}

		/// <summary>
		/// Determines if integrated security is used instead of SQL login. False by default.
		/// </summary>
		public bool LoginSecure {
			get {
				return this.IntegratedSecurity;
			}
			set {
				this.IntegratedSecurity = value;
			}
		}

		/// <summary>
		/// Establishes a connection to the server specified in the Name property.
		/// </summary>
		public void Connect() {

			dmoServer = (NativeMethods.ISqlServer)new NativeMethods.SqlServer();
			dmoServer.Bogus_LoginSecure2(this.IntegratedSecurity);
			if(this.IntegratedSecurity == false) {
				dmoServer.Connect(Name, Username, Password);
			}
			else {

				dmoServer.Connect(Name, null, null);
				

			}


		}

		/// <summary>
		/// Disconnects the connection to the server.
		/// </summary>
		public void Disconnect() {
			if (dmoServer != null) {
				// Physically disconnect from server
				dmoServer.DisConnect();
			}
			if ( this.IntegratedSecurity )
				security.EndImpersonate();
		}

		/// <summary>
		/// Gets an ADO.NET-compatible connection string for this server.
		/// </summary>
		/// <returns>
		/// An ADO.NET-compatible connection string for this server.
		/// </returns>
		public string GetConnectionString() {
			// Create connection string by inserting all non-default settings to string
			ArrayList s = new ArrayList();

			if (Name != "")
				s.Add("Server=" + Name);
            
			if(this.IntegratedSecurity == false) {
												
				if (Username != "")
					s.Add("User ID=" + Username);
				if (Password != "")
					s.Add("Password=" + Password);
			}
			else {
				s.Add("Trusted_Connection=Yes;");
			}

			string[] ss = (string[])s.ToArray(typeof(string));
			return String.Join("; ", ss);
		}

		/// <summary>
		/// Attempts to authenticate the current username and password to the current server.
		/// </summary>
		/// <returns></returns>
		public bool IsUserValid() {

			bool success = true;
			SqlConnection myConnection = new SqlConnection(GetConnectionString());

			try {
				myConnection.Open();
			}
			catch (SqlException ex) {
				string message = ex.Message;
				success = false;
			}
			finally {
				myConnection.Close();
			}

			return success;

		}

		/// <summary>
		/// Runs a batch of SQL queries on the server.
		/// </summary>
		/// <param name="query">
		/// A string containing a batch of SQL queries.
		/// </param>
		/// <returns>
		/// An array of DataTable objects containing grids for each result set (if any)
		/// </returns>
		public DataTable[] Query(string query) {
			return Query(query, null);
		}

		/// <summary>
		/// Runs a batch of SQL queries on the server using a specific database.
		/// </summary>
		/// <param name="query">
		/// A string containing a batch of SQL queries.
		/// </param>
		/// <param name="database">
		/// The name of a database to run the query on.
		/// </param>
		/// <returns>
		/// An array of DataTable objects containing grids for each result set (if any)
		/// </returns>
		public DataTable[] Query(string query, string database) {
			// Use ADO.NET for doing raw queries
			// Parse at each "go" statement and execute each batch independently

			SqlConnection myConnection = null;
			ArrayList result = new ArrayList();

            try
            {
                // Get connection string and add database name if necessary
                if (database == null || database.Length == 0)
                    myConnection = new SqlConnection(GetConnectionString());
                else
                    myConnection = new SqlConnection(GetConnectionString() + "; Initial Catalog=" + database);

                myConnection.Open();

                // Tack on whitespace so that the RegEx doesn't mess up
                query += "\r\n";

                // Split query at each "go"
                Regex regex = new Regex("[\r\n][gG][oO][\r\n]");

                MatchCollection matches = regex.Matches(query);

                int prevIndex = 0;
                string tquery;

                for (int i = 0; i < matches.Count; i++)
                {
                    Match m = matches[i];

                    tquery = query.Substring(prevIndex, m.Index - prevIndex);

                    if (tquery.Trim().Length > 0)
                    {
                        SqlDataAdapter myCommand = new SqlDataAdapter(tquery.Trim(), myConnection);

                        DataSet singleresult = new DataSet();
                        myCommand.Fill(singleresult);

                        for (int j = 0; j < singleresult.Tables.Count; j++)
                        {
                            result.Add(singleresult.Tables[j]);
                        }
                    }

                    prevIndex = m.Index + 3;
                }

                tquery = query.Substring(prevIndex, query.Length - prevIndex);

                if (tquery.Trim().Length > 0)
                {
                    SqlDataAdapter myCommand = new SqlDataAdapter(tquery.Trim(), myConnection);

                    DataSet singleresult = new DataSet();
                    myCommand.Fill(singleresult);

                    for (int j = 0; j < singleresult.Tables.Count; j++)
                    {
                        result.Add(singleresult.Tables[j]);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
			finally {
				myConnection.ChangeDatabase("master");
				myConnection.Close();
			}

			return (DataTable[])result.ToArray(typeof(DataTable));
		}

		/// <summary>
		/// Retrieves a SqlServer instance based on the current user.  Redirects
		/// to the homepage if one doesn't exist.
		/// </summary>
		public static SqlServer CurrentServer {
			get {
				if (AdminUser.CurrentUser == null) {
					HttpContext.Current.Response.Redirect("~/Default.aspx?error=sessionexpired");
					return null;
				} 

				if (AdminUser.CurrentUser.UseIntegratedSecurity) {
					return new SqlServer(AdminUser.CurrentUser.Server, AdminUser.CurrentUser.Username, AdminUser.CurrentUser.Password, true);
				}
				else {
					return new SqlServer(AdminUser.CurrentUser.Server, AdminUser.CurrentUser.Username, AdminUser.CurrentUser.Password, false);
				
				}
			}
		}
		
	}
}
