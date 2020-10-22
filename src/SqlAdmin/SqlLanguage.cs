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

namespace SqlAdmin
{
	/// <summary>
	/// Represents a single language within SQL Server
	/// </summary>
	public class SqlLanguage {

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="server">A SqlServer object</param>
		/// <param name="name">The name of the language</param>
		/// <param name="id">The language Id</param>
		internal SqlLanguage(SqlServer server, string name, int id, string alias){
			this.server = server;
			this.name = name;
			this.id = id;
			this.alias = alias;
		}

		#region Properties

		SqlServer server = null;
		private string name;
		private string alias;
		private int id;

		/// <summary>
		/// The name of language
		/// </summary>
		public string Name {
			get {return name;}
		}

		/// <summary>
		/// The language ID
		/// </summary>
		public int ID {
			get {return id;}
		}

		/// <summary>
		/// Alias for this language
		/// </summary>
		public string Alias {
			get {return alias;}
		}
		#endregion

	}
}
