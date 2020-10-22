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

namespace SqlAdmin
{
	/// <summary>
	/// Summary description for SqlLoginCollection.
	/// </summary>
	public class SqlLoginCollection : ICollection 
	{
		private ArrayList sqlLogins;
		private SqlServer server;


		internal SqlLoginCollection(SqlServer server) {
			this.server  = server;
		}


		/// <summary>
		/// Gets the number of SQL Login in the SqlLoginCollection.
		/// </summary>
		public int Count {
			get {
				if (sqlLogins != null)
					return sqlLogins.Count;
				else
					return 0;
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the login in the SqlLoginCollection can be modified.
		/// </summary>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the SqlLoginCollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the object that can be used to synchronize access to the SqlLoginCollection.
		/// </summary>
		public object SyncRoot {
			get {
				return this;
			}
		}

		/// <summary>
		/// Gets a SqlLogin object from the SqlLoginCollection collection at the specified index.
		/// </summary>
		public SqlLogin this[int index] {
			get {
				if (sqlLogins != null)
					return (SqlLogin)(sqlLogins[index]);
				else
					return null;
			}
		}

		/// <summary>
		/// Gets a SqlLogin object from the SqlLoginCollection collection that has the specified name (case-insensitive).
		/// </summary>
		public SqlLogin this[string name] {
			get {
				if (sqlLogins != null) {
					for (int i = 0; i < sqlLogins.Count; i++) {
						if (name.ToLower() == ((SqlLogin)sqlLogins[i]).Name.ToLower())
							return (SqlLogin)(sqlLogins[i]);
					}
				}

				// If there is no sql login list, or the name does not exist, return null
				return null;
			}
		}


		/// <summary>
		/// Copies the items from the SqlLoginCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
		/// Returns an System.Collections.IEnumerator interface that contains all SqlLogin objects in the SqlLoginCollection.
		/// </summary>
		/// <returns>
		/// A System.Collections.IEnumerator interface that contains all SqlLogin objects in the SqlLoginCollection.
		/// </returns>
		public IEnumerator GetEnumerator() {
			if (sqlLogins == null) {
				sqlLogins = new ArrayList();
			}

			return sqlLogins.GetEnumerator(0, Count);
		}

		/// <summary>
		/// Adds a new SQL Server login
		/// </summary>
		/// <param name="name">The name for the new login</param>
		/// <param name="type">By default, a login is created for use by SQL Server Authentication. Alternately specify the login type to map a Microsoft Windows NT 4.0 or Microsoft Windows 2000 user or group.</param>
		/// <returns>A new SqlLogin Object</returns>
		public SqlLogin Add(string name, SqlLoginType type, string password) {		
			// Validation
			if (name == null || name.Length == 0)
				throw new ArgumentException(SR.GetString("SqlLogin_MustHaveValidName"));

			if (this[name] != null)
				throw new ArgumentException(String.Format(SR.GetString("SqlLogin_NameAlreadyExists"), name));

			// Physically add server
			NativeMethods.ILogin dmoLogin = (NativeMethods.ILogin)new NativeMethods.Login();
			dmoLogin.SetName(name);
			dmoLogin.SetType((int)type);

			if ( type == SqlLoginType.Standard )
				dmoLogin.SetPassword(string.Empty, password);

			this.server.dmoServer.GetLogins().Add(dmoLogin);

			SqlLogin login = new SqlLogin(this.server, dmoLogin.GetName(), (SqlLoginType)dmoLogin.GetType(), (SqlNtAccessType)dmoLogin.GetNTLoginAccessType(), dmoLogin.GetDatabase(), dmoLogin.GetLanguage(), dmoLogin.GetLanguageAlias());
			login.dmoLogin = dmoLogin;

			this.sqlLogins.Add(login);
			return login;
	
		}


		/// <summary>
		/// Updates the SqlLoginCollection  with any changes made since the last call to Refresh.
		/// Refresh is automatically called once when the SqlTable.sqlLogins collection is read.
		/// </summary>
		public void Refresh() {

				server.dmoServer.GetLogins().Refresh(false);
				sqlLogins = new ArrayList();

			for (int i = 0; i < server.dmoServer.GetLogins().GetCount(); i++) {
	
				SqlLogin login;
				NativeMethods.ILogin dmoLogin = null;
 				dmoLogin = server.dmoServer.GetLogins().Item(i+1);

				SqlLoginType type = (SqlLoginType)dmoLogin.GetType();
				SqlNtAccessType ntlogin = (SqlNtAccessType)dmoLogin.GetNTLoginAccessType();
						
				login = new SqlLogin( this.server, dmoLogin.GetName(), type, ntlogin, dmoLogin.GetDatabase(), dmoLogin.GetLanguage(), dmoLogin.GetLanguageAlias());

				sqlLogins.Add(login);

				login.dmoLogin = dmoLogin;
	
			}

			}
		}
	}
