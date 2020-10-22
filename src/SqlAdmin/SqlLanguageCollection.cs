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
	/// Collection of SQL Language objects
	/// </summary>
	public class SqlLanguageCollection : ICollection {
		private ArrayList sqlLanguages;
		private SqlServer server;


		internal SqlLanguageCollection(SqlServer server) {
			this.server  = server;
		}


		/// <summary>
		/// Gets the number of language objects in the SqlLanguageCollection.
		/// </summary>
		public int Count {
			get {
				if (sqlLanguages != null)
					return sqlLanguages.Count;
				else
					return 0;
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the login in the SqlLanguageCollection can be modified.
		/// </summary>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the SqlLanguageCollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets the object that can be used to synchronize access to the SqlLanguageCollection.
		/// </summary>
		public object SyncRoot {
			get {
				return this;
			}
		}

		/// <summary>
		/// Gets a SqlLanguage object from the SqlLanguageCollection collection at the specified index.
		/// </summary>
		public SqlLanguage this[int index] {
			get {
				if (sqlLanguages != null)
					return (SqlLanguage)(sqlLanguages[index]);
				else
					return null;
			}
		}

		/// <summary>
		/// Gets a SqlLanguage object from the SqlLanguageCollection collection that has the specified name (case-insensitive).
		/// </summary>
		public SqlLanguage this[string name] {
			get {
				if (sqlLanguages != null) {
					for (int i = 0; i < sqlLanguages.Count; i++) {
						if (name.ToLower() == ((SqlLanguage)sqlLanguages[i]).Name.ToLower())
							return (SqlLanguage)(sqlLanguages[i]);
					}
				}

				// If there is no sql login list, or the name does not exist, return null
				return null;
			}
		}

		/// <summary>
		/// Copies the items from theSqlLanguageCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
		/// Returns an System.Collections.IEnumerator interface that contains all SqlLanguage objects in the SqlLanguageCollection.
		/// </summary>
		/// <returns>
		/// A System.Collections.IEnumerator interface that contains all SqlLanguage objects in the SqlLanguageCollection.
		/// </returns>
		public IEnumerator GetEnumerator() {
			if (sqlLanguages == null) {
				sqlLanguages = new ArrayList();
			}

			return sqlLanguages.GetEnumerator(0, Count);
		}

		/// <summary>
		/// Updates the SqlLanguageCollection  with any changes made since the last call to Refresh.
		/// 
		/// </summary>
		public void Refresh() {

			server.dmoServer.GetLanguages().Refresh(false);
			sqlLanguages = new ArrayList();

			for (int i = 0; i < server.dmoServer.GetLanguages().GetCount(); i++) {
	
				SqlLanguage language;
				NativeMethods.ILanguage dmoLanguage = null;
				dmoLanguage = server.dmoServer.GetLanguages().Item(i + 1);
		
				language = new  SqlLanguage(this.server, dmoLanguage.GetName(), dmoLanguage.GetID(), dmoLanguage.GetAlias());

				this.sqlLanguages.Add(language);
	
			}
		}
	}
}
