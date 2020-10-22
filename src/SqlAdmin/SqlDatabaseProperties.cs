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
    /// Represents the properties of the database such as status, owner, size, and file information.
    /// </summary>
	public class SqlDatabaseProperties {
        private string name;
        private string status;
        private string owner;
        private DateTime dateCreated;
        private float size;
        private float spaceAvailable;
        private int numberOfUsers;
        private SqlFileProperties dataFile;
        private SqlFileProperties logFile;


        internal SqlDatabaseProperties(string name, string status, string owner, DateTime dateCreated, float size, float spaceAvailable, int numberOfUsers, SqlFileProperties dataFile, SqlFileProperties logFile) {
            this.name            = name;
            this.status          = status;
            this.owner           = owner;
            this.dateCreated     = dateCreated;
            this.size            = size;
            this.spaceAvailable  = spaceAvailable;
            this.numberOfUsers   = numberOfUsers;
            this.dataFile        = dataFile;
            this.logFile         = logFile;
		}

        /// <summary>
        /// Initializes a new instance of the SqlDatabaseProperties class.
        /// </summary>
        /// <param name="dataFile">
        /// A SqlFileProperties object representing the data file for this database.
        /// </param>
        /// <param name="logFile">
        /// A SqlFileProperties object representing the transaction log file for this database.
        /// </param>
        public SqlDatabaseProperties(SqlFileProperties dataFile, SqlFileProperties logFile) {
            this.dataFile        = dataFile;
            this.logFile         = logFile;
        }


        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Name {
            get {
                return name;
            }
        }

        /// <summary>
        /// The status of the database, such as "Normal" or "Offline".
        /// </summary>
        public string Status {
            get {
                return status;
            }
        }

        /// <summary>
        /// The owner of the database.
        /// </summary>
        public string Owner {
            get {
                return owner;
            }
        }

        /// <summary>
        /// The date and time at which the database was created.
        /// </summary>
        public DateTime DateCreated {
            get {
                return dateCreated;
            }
        }

        /// <summary>
        /// The size of the database in megabytes.
        /// </summary>
        public float Size {
            get {
                return size;
            }
        }

        /// <summary>
        /// The available space of the database in megabytes.
        /// </summary>
        public float SpaceAvailable {
            get {
                return spaceAvailable;
            }
        }

        /// <summary>
        /// The number of users using the database.
        /// </summary>
        public int NumberOfUsers {
            get {
                return numberOfUsers;
            }
        }

        /// <summary>
        /// A SqlFileProperties object representing the data file for this database.
        /// </summary>
        public SqlFileProperties DataFile {
            get {
                return dataFile;
            }
        }

        /// <summary>
        /// A SqlFileProperties object representing the transaction log file for this database.
        /// </summary>
        public SqlFileProperties LogFile {
            get {
                return logFile;
            }
        }
    }
}
