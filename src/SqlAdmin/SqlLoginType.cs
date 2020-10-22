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
	/// Summary description for SqlNtAccessType.
	/// </summary>
	public enum SqlLoginType {

		/// <summary>
		/// The login is an NT User
		/// </summary>
		NTUser = 0,

		/// <summary>
		/// The login is an NT Groups
		/// </summary>
		NTGroup = 1,

		/// <summary>
		/// The login is a SQL Server login
		/// </summary>
	  Standard = 2
	
	}
}
