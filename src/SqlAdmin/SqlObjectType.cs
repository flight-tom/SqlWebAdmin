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

namespace SqlAdmin {
    /// <summary>
    /// Represents the type of an object, either a User object or a System object.
    /// </summary>
	public enum SqlObjectType {
        /// <summary>
        /// Indicates that the value is not set.
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// Indicates that the object was created by a user.
        /// </summary>
        User = 1,

        /// <summary>
        /// Indicates that the object is a system object.
        /// </summary>
        System = 2,

				/// <summary>
				/// Indicates that the object is a database.
				/// </summary>
				Database = 135168,
				
				/// <summary>
				/// Indicates that the object is a stored procedure
				/// </summary>
				StoredProcedure = 16,

				/// <summary>
				/// Indicates that the object is a System object. In this case a System Table
				/// </summary>
				SystemTable = 	System,

				/// <summary>
				/// Indicates that the object is a user table.
				/// </summary>
				UserTable = 8,
				
				/// <summary>
				/// Indicates that the object is a view.
				/// </summary>
				View = 4,
				
	}
}
