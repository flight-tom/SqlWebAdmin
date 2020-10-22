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
	/// Represents a Database Role
	/// </summary>
	public class SqlDatabaseRole {

		#region properties

		internal NativeMethods.IDatabaseRole dmoDatabaseRole = null;
		internal SqlDatabase database = null;

		private string name;

		/// <summary>
		/// Database Application Role. Exposes the security context for a database role.
		/// </summary>
		public bool AppRole {
			get { return dmoDatabaseRole.GetAppRole(); }
			set { dmoDatabaseRole.SetAppRole(value); }
		}

		/// <summary>
		/// Database Role Name
		/// </summary>
		public string Name {
			get { return name; }
			set { 
				dmoDatabaseRole.SetName(value);
				this.name = value;
			}
		}

		/// <summary>
		/// Password for Database Application Role
		/// </summary>
		public string Password {
			get { return dmoDatabaseRole.GetPassword(); }
			set { dmoDatabaseRole.SetPassword(value); }
		}

		/// <summary>
		/// Is current DatabaseRole a fixed role?" 
		/// Returns TRUE when the database role referenced is system-defined.
		/// </summary>
		public bool IsFixedRole {
			get { return dmoDatabaseRole.GetIsFixedRole(); }
		}

		public SqlDatabase Database {
			get { return this.database; }
			set {this.database = value;}
		}

		#endregion

		#region constructors

		public SqlDatabaseRole() {}
		internal SqlDatabaseRole(string name) {
			this.name = name;
		}

		#endregion
	
		#region methods

		/// <summary>
		/// Add a new User to current database role.
		/// </summary>
		/// <param name="userName">The UserName</param>
		public void AddMember(string userName) {		
			dmoDatabaseRole.AddMember(userName);		
		}

		/// <summary>
		/// Remove a User to current database role
		/// </summary>
		/// <param name="userName">The UserName</param>
		public void DropMember(string userName) {		
			dmoDatabaseRole.DropMember(userName);
		}

		/// <summary>
		/// returns a ArrayList object that enumerates the members of a SQL Server fixed server security role
		/// Each item in the ArrayList contains a database username.
		/// </summary>
		/// <returns>An ArrayList filled with a username for each item (String).</returns>
		public ArrayList GetDatabaseRoleMembers() {
			ArrayList members = new ArrayList();
			string member = null;
			int rows = 0;
			rows = this.dmoDatabaseRole.GetEnumDatabaseRoleMember().GetRows();

			for ( int i = 0; i < rows; i ++ ) {
				member = this.dmoDatabaseRole.GetEnumDatabaseRoleMember().GetColumnString( i+1, 1 );
				members.Add( member );
			}
			return members;
		}
		#endregion
	}
}
