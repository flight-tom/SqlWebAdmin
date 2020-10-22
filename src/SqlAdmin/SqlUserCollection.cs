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

namespace SqlAdmin {

	/// <summary>
	/// A collection of SQL Server Datbase User Objects (SqlUser)
	/// </summary>
	public class SqlUserCollection : ICollection {

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="database">SqlDatabase object</param>
		internal SqlUserCollection(SqlDatabase database) {
			this.database = database;
		}

		private ArrayList sqlUsers;
		private SqlDatabase database;

		/// <summary>
		/// Gets the number of sql users in SqlUserCollection.
		/// </summary>
		public int Count {
			get {
				if (sqlUsers != null)
					return sqlUsers.Count;
				else
					return 0;
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the sql user in the SqlUserCollection can be modified.
		/// </summary>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the SqlUserCollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the object that can be used to synchronize access to the SqlUserCollection.
		/// </summary>
		public object SyncRoot {
			get {
				return this;
			}
		}

		/// <summary>
		/// Gets a SqlUser object from the SqlUserCollection collection at the specified index.
		/// </summary>
		public SqlUser this[int index] {
			get {
				if (sqlUsers != null)
					return (SqlUser)(sqlUsers[index]);
				else
					return null;
			}
		}

		/// <summary>
		/// Gets a SqlUser object from the SqlUserCollection collection that has the specified name (case-insensitive).
		/// </summary>
		public SqlUser this[string name] {
			get {
				if (sqlUsers != null) {
					for (int i = 0; i < sqlUsers.Count; i++) {
						if (name.ToLower() == ((SqlUser)sqlUsers[i]).Name.ToLower())
							return (SqlUser)(sqlUsers[i]);
					}
				}

				// If there is no stored procedure list, or the name does not exist, return null
				return null;
			}
		}

		/// <summary>
		/// Copies the items from the SqlUserCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
		/// Returns an System.Collections.IEnumerator interface that contains all SqlUser objects in the SqlUserCollection.
		/// </summary>
		/// <returns>
		/// A System.Collections.IEnumerator interface that contains all SqlUser objects in the SqlUserCollection.
		/// </returns>
		public IEnumerator GetEnumerator() {
			if (sqlUsers == null) {
				sqlUsers = new ArrayList();
			}

			return sqlUsers.GetEnumerator(0, Count);
		}

		/// <summary>
		/// Adds a login to a database.
		/// </summary>
		/// <param name="login">A valid login name.</param>
		/// <returns>A SqlUser object.</returns>
		public SqlUser Add(string login, string userName) {
		
			// Validation
			if (login == null || login.Length == 0)
				throw new ArgumentException(SR.GetString("SqlLogin_MustHaveValidName"));

			if (this[login] != null)
				throw new ArgumentException(String.Format(SR.GetString("SqlLogin_NameAlreadyExists"), login));

			// Physically add server
			NativeMethods.IUser dmoUser = (NativeMethods.IUser)new NativeMethods.User();
			dmoUser.SetLogin(login);
			dmoUser.SetName(userName);
			
			this.database.dmoDatabase.GetUsers().Add(dmoUser);

			SqlUser user = new SqlUser(this.database, dmoUser.GetHasDBAccess(), dmoUser.GetLogin(), dmoUser.GetId(), dmoUser.GetName(), dmoUser.GetSystemObject());
			user.dmoUser = dmoUser;

			this.sqlUsers.Add(user);
			return user;	
		
		}

		/// <summary>
		/// Updates the SqlUserCollection with any changes made since the last call to Refresh.
		/// </summary>
		public void Refresh() {

			// Force internal refresh of users.
			database.dmoDatabase.GetUsers().Refresh(false);

			// Clear out old list
			this.sqlUsers = new ArrayList();

			for (int i = 0; i < database.dmoDatabase.GetUsers().GetCount(); i++) {
				NativeMethods.IUser DmoUser = database.dmoDatabase.GetUsers().Item(i + 1);

				SqlUser user;


				if (DmoUser.GetSystemObject())
					user = new SqlUser(this.database, DmoUser.GetHasDBAccess(), DmoUser.GetLogin(), DmoUser.GetId(), DmoUser.GetName(), true);
				else
					user = new SqlUser(this.database, DmoUser.GetHasDBAccess(), DmoUser.GetLogin(), DmoUser.GetId(), DmoUser.GetName(), false);

				this.sqlUsers.Add(user);

				user.dmoUser = DmoUser;
				user.Database = this.database;
			}

		}

	}
}
