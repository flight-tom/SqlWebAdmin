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
using System.Runtime.InteropServices; 

namespace SqlAdmin {
	/// <summary>
	/// Summary description for SqlLoginCollection.
	/// </summary>
	public class SqlServerRoleCollection : ICollection {
		private ArrayList sqlServerRoles;
		private SqlServer server;


		internal SqlServerRoleCollection(SqlServer server) {
			this.server  = server;
		}


		/// <summary>
		/// Gets the number of server roles in the SqlServerRoleCollection.
		/// </summary>
		public int Count {
			get {
				if (sqlServerRoles != null)
					return sqlServerRoles.Count;
				else
					return 0;
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the server rike in the SqlServerRoleCollection can be modified.
		/// </summary>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the SqlServerRoleCollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the object that can be used to synchronize access to the SqlServerRoleCollection.
		/// </summary>
		public object SyncRoot {
			get {
				return this;
			}
		}

		/// <summary>
		/// Gets a SqlServerRole object from the SqlServerRoleCollection collection at the specified index.
		/// </summary>
		public SqlServerRole this[int index] {
			get {
				if (sqlServerRoles != null)
					return (SqlServerRole)(sqlServerRoles[index]);
				else
					return null;
			}
		}

		/// <summary>
		/// Gets a SqlServerRole object from the SqlServerRoleCollection collection that has the specified name (case-insensitive).
		/// </summary>
		public SqlServerRole this[string name] {
			get {
				if (sqlServerRoles != null) {
					for (int i = 0; i < sqlServerRoles.Count; i++) {
						if (name.ToLower() == ((SqlServerRole)sqlServerRoles[i]).Name.ToLower())
							return (SqlServerRole)(sqlServerRoles[i]);
					}
				}

				// If there is no server role list, or the name does not exist, return null
				return null;
			}
		}


		/// <summary>
		/// Copies the items from the SqlServerRoleCollection to the specified System.Array object, starting at the specified index in the System.Array object.
		/// </summary>
		/// <param name="array">
		/// </param>
		/// <param name="index">
		/// </param>
		public void CopyTo(Array array, int index) {
			for (IEnumerator e = this.GetEnumerator(); e.MoveNext();)
				array.SetValue(e.Current, index++);
		}

		/// <summary>
		/// Returns an System.Collections.IEnumerator interface that contains all SqlServerRole objects in the SqlServerRoleCollection.
		/// </summary>
		/// <returns>
		/// A System.Collections.IEnumerator interface that contains all SqlServerRole objects in the SqlServerRoleCollection.
		/// </returns>
		public IEnumerator GetEnumerator() {
			if (sqlServerRoles == null) {
				sqlServerRoles = new ArrayList();
			}

			return sqlServerRoles.GetEnumerator(0, Count);
		}

		/// <summary>
		/// Updates the SqlServerRoleCollection with any changes made since the last call to Refresh.
		/// Refresh is automatically called once when the SqlTable.sqlServerRoles collection is read.
		/// </summary>
		public void Refresh() {


			server.dmoServer.GetServerRoles().Refresh(false);
			sqlServerRoles = new ArrayList();

			for (int i = 0; i < server.dmoServer.GetServerRoles().GetCount(); i++) {
	
				SqlServerRole role;
				NativeMethods.IServerRole  dmoServerRole = null;
				dmoServerRole = server.dmoServer.GetServerRoles().Item(i+1);

				role = new SqlServerRole( this.server, dmoServerRole.GetName(), dmoServerRole.GetFullName(), dmoServerRole.GetDescription());

				sqlServerRoles.Add(role);

				role.dmoRole = dmoServerRole;
	
			}


		}
	}
}

