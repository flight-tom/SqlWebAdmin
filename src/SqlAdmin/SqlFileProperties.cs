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
    /// Represents the properties of a data file or a transaction log file of a database.
    /// </summary>
	public class SqlFileProperties {
        private SqlFileGrowthType fileGrowthType;
        private int fileGrowth;
        private int maximumSize;


        /// <summary>
        /// Initializes a new instance of the SqlFileProperties class.
        /// </summary>
        /// <param name="fileGrowthType">
        /// A SqlFileGrowthType value representing the growth type of the file.
        /// </param>
        /// <param name="fileGrowth">
        /// The amount in which the file grows, either in percent or megabytes, depending on the value of fileGrowthType.
        /// </param>
        /// <param name="maximumSize">
        /// The maximum size of the database in megabytes.
        /// </param>
		public SqlFileProperties(SqlFileGrowthType fileGrowthType, int fileGrowth, int maximumSize) {
            this.fileGrowthType          = fileGrowthType;
            this.fileGrowth              = fileGrowth;
            this.maximumSize             = maximumSize;
        }


        /// <summary>
        /// A SqlFileGrowthType value representing the type of growth of this file.
        /// </summary>
        public SqlFileGrowthType FileGrowthType {
            get {
                return fileGrowthType;
            }
            set {
                fileGrowthType = value;
            }
        }

        /// <summary>
        /// The amount in which the file grows, either in percent of megabytes, depending on the value of FileGrowthType.
        /// A value of 0 indicates that the file does not automatically grow.
        /// </summary>
        public int FileGrowth {
            get {
                return fileGrowth;
            }
            set {
                fileGrowth = value;
            }
        }

        /// <summary>
        /// The maximum size of the database in megabytes.
        /// A value of -1 indicates unrestricted growth.
        /// </summary>
        public int MaximumSize {
            get {
                return maximumSize;
            }
            set {
                maximumSize = value;
            }
        }
	}
}
