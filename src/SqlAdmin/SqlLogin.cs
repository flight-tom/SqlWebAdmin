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

namespace SqlAdmin
{
	/// <summary>
	/// Represents a SQL Login 
	/// </summary>
	public class SqlLogin {

		
		internal SqlLogin(SqlServer server, string name, SqlLoginType loginType, SqlNtAccessType nTLoginAccessType, string database, string defaultLanguage, string languageAlias ) {
			this.server = server;
			this.name = name;
			this.loginType = loginType;
			this.database = database;
			this.nTLoginAccessType = nTLoginAccessType;
			this.language = defaultLanguage;
			this.languageAlias = languageAlias;
		}
		
		#region properties

		internal NativeMethods.ILogin dmoLogin = null;
		SqlServer server = null;

		string database = null;
		bool denyNTLogin;
		string name = null;
		SqlNtAccessType  nTLoginAccessType;
		string language = null;
		string languageAlias = null; 
		bool systemObject;
		SqlLoginType loginType;
	
		/// <summary>
		/// Identifies the default database for this SQL Server login
		/// </summary>
		public string Database {
			get {
				return database;
			}		
			set {
				dmoLogin.SetDatabase(value);
				database = value;			
			}
		}

		/// <summary>
		/// Controls access to an instance of Microsoft SQL Server for login records that identify Microsoft Windows NT users or groups.
		/// 
		/// When TRUE, any Windows NT authenticated connection attempt that specifies the user or group name fails authentication.
		/// 
		/// When FALSE, the Windows NT user or group is allowed access to the instance of SQL Server on which the login is defined. 
		/// Access rights are established through login and user role memberships and permissions explicitly granted on databases and 
		/// database objects.
		/// </summary>
		public bool DenyNTLogin {
			get {
				return denyNTLogin;
			}
			set {
				dmoLogin.SetDenyNTLogin(value);
				denyNTLogin = value;
			}
		}

		/// <summary>
		/// Controls direct language use for a client connection using the referenced login.
		/// </summary>
		public string Language {
			get {
				return language;
			}
			set {
				dmoLogin.SetLanguage(value);
				language = value;
			}
		}

		/// <summary>
		/// returns a friendly name for a language used by a Microsoft® SQL Server™ 2000 login
		/// </summary>
		public string LanguageAlias {
			get {
				return languageAlias; 
			}
		}


		/// <summary>
		/// The name of this login.
		/// </summary>
		public string Name {
			get {
				return name;
			}
		}

		/// <summary>
		/// reports whether a Microsoft Windows NT 4.0 login has explicit permissions to connect to a server.
		/// </summary>
		public SqlNtAccessType  NTLoginAccessType {
			get {
				return nTLoginAccessType ;
			}
		}

		public bool SystemObject {
			get {
				return systemObject;
			}
		}

		/// <summary>
		/// The type of login
		/// </summary>
		public SqlLoginType LoginType{
			get {
				return loginType;
			}
			set {
				loginType = value;
			}	
		}

		#endregion

		#region methods


		/// <summary>
		/// The GetUserName method returns the database user used by the referenced login, when a connection using that login accesses the specified database.
		/// </summary>
		/// <param name="Database"></param>
		/// <returns></returns>
		public string GetUserName( string Database ) {
			return dmoLogin.GetUserName( Database );
		}

		/// <summary>
		/// The IsMember method returns TRUE when the user or login referenced is a member of the role identified in the Role argument.
		/// </summary>
		/// <param name="Role"></param>
		/// <returns></returns>
		public bool IsMember( string Role ) {
			return dmoLogin.IsMember( Role );
		}

		/// <summary>
		/// The ListMembers method returns a NameList object that enumerates the Microsoft® SQL Server™ 2000 database roles in which a database user has membership, or the server roles in which a login has membership.
		/// </summary>
		/// <returns></returns>
		public ArrayList ListMembers() {
			ArrayList members = new ArrayList();

			for( int i=0; i < dmoLogin.ListMembers().GetCount(); i ++ ) {
				members.Add( dmoLogin.ListMembers().Item(i+1) );
			}

			return members;
		}

		/// <summary>
		/// Permanently removes this login from the database.
		/// </summary>
		public void Remove() {
			// Permanently delete this stored procedure
			dmoLogin.Remove();
		}

		/// <summary>
		/// The SetPassword method changes the password for the referenced login.
		/// </summary>
		/// <param name="oldPassword"></param>
		/// <param name="newPassword"></param>
		public void SetPassword( string oldPassword, string newPassword ) {
			dmoLogin.SetPassword( oldPassword, newPassword );
		}

		#endregion

	}
}
