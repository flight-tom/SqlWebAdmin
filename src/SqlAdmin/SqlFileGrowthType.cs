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
    /// Represents the file growth type for a data file or a transaction log file of a database.
    /// </summary>
	public enum SqlFileGrowthType {
        /// <summary>
        /// Indicates that the file should grow in megabytes.
        /// </summary>
        MB = 0,

        /// <summary>
        /// Indicates that the file should grow by a certain percentage.
        /// </summary>
        Percent = 1
	}
}
