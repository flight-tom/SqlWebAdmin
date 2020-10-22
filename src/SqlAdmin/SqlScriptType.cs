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
    /// Specifies the SQL statements to be included in the script.
    /// </summary>
    [Flags]
	public enum SqlScriptType {
        /// <summary>
        /// The script should include an object creation statement.
        /// </summary>
        Create      = 0x0001,

        /// <summary>
        /// The script should include an object drop statement.
        /// </summary>
        Drop        = 0x0002,

        /// <summary>
        /// The script should include comments.
        /// </summary>
        Comments    = 0x0004,

        /// <summary>
        /// The script should include defaults.
        /// This only applies to table schema.
        /// </summary>
        Defaults    = 0x0008,

        /// <summary>
        /// The script should include the primary key.
        /// This only applies to table schema.
        /// </summary>
        PrimaryKey  = 0x0010,

        /// <summary>
        /// The script should include checks.
        /// This only applies to table schema.
        /// </summary>
        Checks      = 0x0020,

        /// <summary>
        /// The script should include foreign keys.
        /// This only applies to table schema.
        /// </summary>
        ForeignKeys = 0x0040,

        /// <summary>
        /// The script should include unique keys.
        /// This only applies to table schema.
        /// </summary>
        UniqueKeys  = 0x0080,

        /// <summary>
        /// The script should include indexes.
        /// This only applies to table schema.
        /// </summary>
        Indexes     = 0x0100,

    }
}
