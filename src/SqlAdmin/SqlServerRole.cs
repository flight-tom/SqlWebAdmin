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
	/// A SQL Server level Role
	/// </summary>
	public class SqlServerRole {
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="server">A SqlServer object</param>
		/// <param name="name">The name of the sql server role.</param>
		/// <param name="fullName">The full name of the sql server role.</param>
		/// <param name="description">A description of the sql server role.</param>
		public SqlServerRole(SqlServer server, string name, string fullName, string description){
		
			this.server = server;
			this.name = name;
			this.fullName = fullName;
			this.description = description;
		
		}

		#region properties

		internal NativeMethods.IServerRole dmoRole = null;
		SqlServer server = null;
		string name = null;
		string fullName = null;
		string description = null;

		/// <summary>
		/// The name of the sql server role
		/// </summary>
		public string Name {
			get { 
				return this.name;
			}
		}

		/// <summary>
		/// The full name of the sql server role. Provides descriptive data.
		/// </summary>
		public string FullName {
			get {
				return this.fullName;
			}
		}

		/// <summary>
		/// Provides additional data about the sql server role.
		/// </summary>
		public string Description{
			get{
				return this.description;
			}
		}

		#endregion

		#region methods

		public void AddMember(string loginName ) {
		
			this.dmoRole.AddMember( loginName );
		
		}
		public void DropMember( string loginName ) {
			
			this.dmoRole.DropMember( loginName );
		
		}

		/// <summary>
		/// returns a ArrayList object that enumerates the members of a SQL Server fixed server security role
		/// </summary>
		/// <returns>An ArrayList with a username (string) for each item.</returns>
		public ArrayList GetServerRoleMembers() {
	
			ArrayList members = new ArrayList();
			string member = null;

			int rows = 0;
			rows = this.dmoRole.GetEnumServerRoleMember().GetRows();

			for ( int i = 0; i < rows; i ++ ) {
				member = this.dmoRole.GetEnumServerRoleMember().GetColumnString( i+1, 1 );
				members.Add( member );
			}

			return members;
		
		}

		#endregion
	}
}
