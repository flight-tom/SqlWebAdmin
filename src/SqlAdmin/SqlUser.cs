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
	/// Represents a MS SQL Server Database User
	/// </summary>
	public class SqlUser {

		#region Constructors

		/// <summary>
		/// Default Constructor for a SQL Server Database User.
		/// </summary>
		/// <param name="database">A valid SqlDatabase object</param>
		/// <param name="hasDbAccess">Indicates whether user has DBAccess. (True or False)</param>
		/// <param name="login">User's Login name</param>
		/// <param name="id">User ID</param>
		/// <param name="name">User name</param>
		/// <param name="systemObject">Indicates whether or not this is a system object.</param>
		internal SqlUser( SqlDatabase database, bool hasDbAccess, string login, int id, string name, bool systemObject ) {
		
			this.database = database;
			this.hasDbAccess = hasDbAccess;
			this.login = login;
			this.id = id;
			this.name = name;
			this.systemObject = systemObject;
		}
		 

		#endregion

		#region properties

		internal NativeMethods.IUser dmoUser = null;
		SqlDatabase database = null;

		private bool hasDbAccess;
		private string login;
		private string role;
		private int id;
		private string name;
		private bool systemObject;

		/// <summary>
		/// Get or set User's Login name
		/// </summary>
		public string Login {
			get { return login; }
			set { 
				dmoUser.SetLogin(value); 
				this.login = value;
			}
		}

		/// <summary>
		/// Can only be set if you are creating user. Otherwise you'll return an exception.
		/// </summary>
		public string Role {
			get { return dmoUser.GetRole(); }
			set { dmoUser.SetRole(value); }
		}

		/// <summary>
		/// User's ID
		/// </summary>
		public int ID {
			get {return id;}
		}
		
		/// <summary>
		/// Get or set Object name
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
		/// Does this user has explicit access to the database?" 
		/// </summary>
		public bool HasDbAccess {
			get { return hasDbAccess; }
		}

		/// <summary>
		/// Is this object a System (required) object
		/// </summary>
		public bool SystemObject {
			get { return systemObject; }
		}

			public SqlDatabase Database {
			get { return this.database; }
			set {this.database = value;}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Removes this user from the database.
		/// </summary>
		public void Remove() {
		
			this.dmoUser.Remove();
		
		}


		/// <summary>
		/// User is Member of these DatabaseRoles.
		/// </summary>
		/// <returns>ArrayList of all DatabaseRoles that this User is a Member of.</returns>
		public ArrayList ListMembers(){
		
			ArrayList members = new ArrayList();

			for( int i=0; i < dmoUser.ListMembers().GetCount(); i ++ ) {
			
				members.Add( dmoUser.ListMembers().Item(i+1) );

			}

			return members;
		
		}

		/// <summary>
		/// Is current User a member of the specified DatabaseRole?"
		/// </summary>
		/// <param name="role">The role name.</param>
		/// <returns>true or false.</returns>
		public bool IsMember(string role) {
			return dmoUser.IsMember(role);
		}

		#endregion

	}
}
