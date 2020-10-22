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
	/// Summary description for SqlDatabaseRoleCollection.
	/// </summary>
	public class SqlDatabaseRoleCollection: ICollection {
		private ArrayList sqlDatabaseRoles;
		private SqlDatabase database;


		internal SqlDatabaseRoleCollection(SqlDatabase database) {
			this.database = database;
		}

		/// <summary>
		/// Gets the number of sql roles in SqlDatabaseRoleCollection.
		/// </summary>
		public int Count {
			get {
				if (sqlDatabaseRoles != null)
					return sqlDatabaseRoles.Count;
				else
					return 0;
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the sql role in the SqlDatabaseRoleCollection can be modified.
		/// </summary>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the SqlDatabaseRoleCollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the object that can be used to synchronize access to the SqlDatabaseRoleCollection.
		/// </summary>
		public object SyncRoot {
			get {
				return this;
			}
		}

		/// <summary>
		/// Gets a SqlDatabaseRole object from the SqlDatabaseRoleCollection collection at the specified index.
		/// </summary>
		public SqlDatabaseRole this[int index] {
			get {
				if (sqlDatabaseRoles != null)
					return (SqlDatabaseRole)(sqlDatabaseRoles[index]);
				else
					return null;
			}
		}

		/// <summary>
		/// Gets a SqlDatabaseRole object from the SqlDatabaseRoleCollection collection that has the specified name (case-insensitive).
		/// </summary>
		public SqlDatabaseRole this[string name] {
			get {
				if (sqlDatabaseRoles != null) {
					for (int i = 0; i < sqlDatabaseRoles.Count; i++) {
						if (name.ToLower() == ((SqlDatabaseRole)sqlDatabaseRoles[i]).Name.ToLower())
							return (SqlDatabaseRole)(sqlDatabaseRoles[i]);
					}
				}

				// If there is no stored procedure list, or the name does not exist, return null
				return null;
			}
		}

		/// <summary>
		/// Copies the items from the SqlDatabaseRoleCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
		/// Returns an System.Collections.IEnumerator interface that contains all SqlDatabaseRole objects in the SqlDatabaseRoleCollection.
		/// </summary>
		/// <returns>
		/// A System.Collections.IEnumerator interface that contains all SqlDatabaseRole objects in the SqlDatabaseRoleCollection.
		/// </returns>
		public IEnumerator GetEnumerator() {
			if (sqlDatabaseRoles == null) {
				sqlDatabaseRoles = new ArrayList();
			}

			return sqlDatabaseRoles.GetEnumerator(0, Count);
		}


		/// <summary>
		/// Updates the SqlDatabaseRoleCollection with any changes made since the last call to Refresh.
		/// 
		/// </summary>
		public void Refresh() {

			// Force internal refresh of roles.
			database.dmoDatabase.GetDatabaseRoles().Refresh(false);

			// Clear out old list
			this.sqlDatabaseRoles = new ArrayList();

			for (int i = 0; i < database.dmoDatabase.GetDatabaseRoles().GetCount(); i++) {
				NativeMethods.IDatabaseRole DmoRole = database.dmoDatabase.GetDatabaseRoles().Item(i + 1);

				SqlDatabaseRole role;

				role = new SqlDatabaseRole(DmoRole.GetName());
				
				this.sqlDatabaseRoles.Add(role);

				role.dmoDatabaseRole = DmoRole;
				role.Database = this.database;
			}

		}

	}
}
