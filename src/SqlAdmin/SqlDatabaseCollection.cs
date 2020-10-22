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

namespace SqlAdmin {
    /// <summary>
    /// A collection of SqlDatabase objects that represent the databases in a SQL server.
    /// </summary>
    public class SqlDatabaseCollection : ICollection {

        private ArrayList databases;
        private SqlServer server;


        internal SqlDatabaseCollection(SqlServer server)
        {
            this.server = server;
        }


        /// <summary>
        /// Gets the number of databases in the SqlDatabaseCollection.
        /// </summary>
        public int Count {
            get {
                if (databases != null)
                    return databases.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the columns in the SqlDatabaseCollection can be modified.
        /// </summary>
        public bool IsReadOnly {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the SqlDatabaseCollection is synchronized (thread-safe).
        /// </summary>
        public bool IsSynchronized {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the object that can be used to synchronize access to the SqlDatabaseCollection.
        /// </summary>
        public object SyncRoot {
            get {
                return this;
            }
        }

        /// <summary>
        /// Gets a SqlDatabase object from the SqlDatabaseCollection collection at the specified index.
        /// </summary>
        public SqlDatabase this[int index] {
            get {
                if (databases != null)
                    return (SqlDatabase)(databases[index]);
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets a SqlDatabase object from the SqlDatabaseCollection collection that has the specified name (case-insensitive).
        /// </summary>
        public SqlDatabase this[string name] {
            get {
                if (databases != null) {
                    for (int i = 0; i < databases.Count; i++) {
                        if (name.ToLower() == ((SqlDatabase)databases[i]).Name.ToLower())
                            return (SqlDatabase)(databases[i]);
                    }
                }

                // If there is no database list, or the name does not exist, return null
                return null;
            }
        }


        /// <summary>
        /// Adds a new database to the server using default properties.
        /// </summary>
        /// <param name="name">
        /// The name of the database to create.
        /// </param>
        /// <returns>
        /// If the operation succeeded, the return value is the database created.
        /// </returns>
        public SqlDatabase Add(string name) {
            if (name == null || name.Length == 0)
                throw new ArgumentException(SR.GetString("SqlDatabaseCollection_MustHaveValidName"));

            if (this[name] != null)
                throw new ArgumentException(String.Format(SR.GetString("SqlDatabaseCollection_NameAlreadyExists"), name));

            // Physically add database
            NativeMethods.IDatabase dmoDatabase = (NativeMethods.IDatabase)new NativeMethods.Database();
            dmoDatabase.SetName(name);
            server.dmoServer.GetDatabases().Add(dmoDatabase);

            SqlDatabase database = new SqlDatabase(dmoDatabase.GetName(), dmoDatabase.GetSize());
            // Set internal properties
            database.dmoDatabase = dmoDatabase;
            database.server = this.server;

            // Add to private list
            databases.Add(database);

            return database;
        }

        /// <summary>
        /// Copies the items from the SqlDatabaseCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
        /// Returns an System.Collections.IEnumerator interface that contains all SqlDatabase objects in the SqlDatabaseCollection.
        /// </summary>
        /// <returns>
        /// A System.Collections.IEnumerator interface that contains all SqlDatabase objects in the SqlDatabaseCollection.
        /// </returns>
        public IEnumerator GetEnumerator() {
            if (databases == null) {
                databases = new ArrayList();
            }

            return databases.GetEnumerator(0, Count);
        }

        /// <summary>
        /// Updates the SqlDatabaseCollection with any changes made since the last call to Refresh.
        /// Refresh is automatically called once when the SqlServer.Databases collection is read.
        /// </summary>
        public void Refresh() {
            // Force internal refresh of tables
            server.dmoServer.GetDatabases().Refresh(false);

            // Clear out old list
            databases = new ArrayList();

            // List all databases and add them one by one
            for (int i = 0; i < server.dmoServer.GetDatabases().GetCount(); i++) {
                NativeMethods.IDatabase database = server.dmoServer.GetDatabases().Item(i + 1, "");

                string name = database.GetName();

                // To find out permissions we have to try to "use" the database
                try {
                    server.Query("use [" + name + "]");
                }
                catch {
                    // If an exception is thrown, go to the next database
                    continue;
                }

                // If we get here, we at least have permissions to look at the database's name

                // A size of -1 indicates "unknown" (due to security)
                int size = -1;
                try {
                    size = database.GetSize();
                }
                catch {
                }

                SqlDatabase db = new SqlDatabase(name, size);

                // Tell the database which DMO database it represents
                db.dmoDatabase = database;
                db.server = this.server;

                databases.Add(db);
            }
        }
    }
}
