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
	/// Summary description for SqlPermissions.
	/// </summary>
	public class SqlPermissions
	{
		public SqlPermissions() {}

		#region properties

		private bool granted;
		private string grantee;
		private int objectId;
		private string objectName;
		private string objectOwner;
		private SqlObjectType objectType;
		private string objectTypeName;
		private SqlPrivilegeType privilegeType;
		private string privilegeTypeName;
		private ArrayList privilegeColumns = new ArrayList();

		public ArrayList PrivilegeColumns {
			get { return privilegeColumns; }
			set { privilegeColumns = value; }
		}


		/// <summary>
		/// True if a GRANT, else a DENY
		/// </summary>
		public bool Granted {
			get{ return granted; }
			set{ granted = value; }
		}

		/// <summary>
		/// User or Group granted this privilege
		/// </summary>
		public string Grantee {
			get { return grantee; }
			set { grantee = value; }
		}

		/// <summary>
		/// Object's Database ID (if object privilege)
		/// </summary>
		public int ObjectId {
			get { return objectId; }
			set { objectId = value; }
		}

		/// <summary>
		/// Object's Name (if object privilege)
		/// </summary>
		public string ObjectName {
			get { return objectName; }
			set { objectName = value; }
		}

		/// <summary>
		/// Object Owner's Name (if object privilege)
		/// </summary>
		public string ObjectOwner {
			get { return objectOwner; }
			set { objectOwner = value; }
		}

		/// <summary>
		/// Object's Type (if object privilege)
		/// </summary>
		public SqlObjectType ObjectType {
			get { return objectType; }
			set { objectType = value; }
		}

		/// <summary>
		/// Object's Type Name (if object privilege)
		/// </summary>
		public string ObjectTypeName {
			get { return objectTypeName; }
			set { objectTypeName = value; }
		}

		/// <summary>
		/// Bitmask of privilege type(s)
		/// </summary>
		public SqlPrivilegeType PrivilegeType {
			get { return privilegeType; }
			set { privilegeType = value; }
		}

		/// <summary>
		/// Privilege Type's Name
		/// </summary>
		public string PrivilegeTypeName {
			get { return privilegeTypeName; }
			set { privilegeTypeName = value; }
		}


		#endregion


	}
}
