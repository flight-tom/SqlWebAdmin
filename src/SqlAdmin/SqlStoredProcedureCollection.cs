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
    /// A collection of SqlStoredProcedure objects that represent the stored procedures in a SQL table.
    /// </summary>
    public class SqlStoredProcedureCollection : ICollection {
        private ArrayList storedProcedures;
        private SqlDatabase database;


        internal SqlStoredProcedureCollection(SqlDatabase database) {
            this.database = database;
        }


        /// <summary>
        /// Gets the number of stored procedures in the SqlStoredProcedureCollection.
        /// </summary>
        public int Count {
            get {
                if (storedProcedures != null)
                    return storedProcedures.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the stored procedures in the SqlStoredProcedureCollection can be modified.
        /// </summary>
        public bool IsReadOnly {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the SqlStoredProcedureCollection is synchronized (thread-safe).
        /// </summary>
        public bool IsSynchronized {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the object that can be used to synchronize access to the SqlStoredProcedureCollection.
        /// </summary>
        public object SyncRoot {
            get {
                return this;
            }
        }

        /// <summary>
        /// Gets a SqlStoredProcedure object from the SqlStoredProcedureCollection collection at the specified index.
        /// </summary>
        public SqlStoredProcedure this[int index] {
            get {
                if (storedProcedures != null)
                    return (SqlStoredProcedure)(storedProcedures[index]);
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets a SqlStoredProcedure object from the SqlStoredProcedureCollection collection that has the specified name (case-insensitive).
        /// </summary>
        public SqlStoredProcedure this[string name] {
            get {
                if (storedProcedures != null) {
                    for (int i = 0; i < storedProcedures.Count; i++) {
                        if (name.ToLower() == ((SqlStoredProcedure)storedProcedures[i]).Name.ToLower())
                            return (SqlStoredProcedure)(storedProcedures[i]);
                    }
                }

                // If there is no stored procedure list, or the name does not exist, return null
                return null;
            }
        }


        /// <summary>
        /// Adds a new stored procedure to the table with specified name and text.
        /// </summary>
        /// <param name="name">
        /// The name of the stored procedure to add.
        /// </param>
        /// <param name="text">
        /// The text of the stored procedure to add.
        /// The text must contain a valid SQL stored procedure creation statement.
        /// </param>
        /// <returns>
        /// If the operation succeeded, the return value is the stored procedure created.
        /// </returns>
        /// <remarks>
        /// The name in the Text parameter must match the Name parameter.
        /// </remarks>
        public SqlStoredProcedure Add(string name, string text) {
            if (name == null || name.Length == 0)
                throw new ArgumentException(SR.GetString("SqlStoredProcedureCollection_MustHaveValidName"));

            if (this[name] != null)
                throw new ArgumentException(String.Format(SR.GetString("SqlStoredProcedureCollection_NameAlreadyExists"), name));

            // Physically add database
            NativeMethods.IStoredProcedure dmoStoredProcedure = (NativeMethods.IStoredProcedure)new NativeMethods.StoredProcedure();
            dmoStoredProcedure.SetName(name);
            dmoStoredProcedure.SetText(text);
            database.dmoDatabase.GetStoredProcedures().Add(dmoStoredProcedure);

            SqlStoredProcedure sproc = new SqlStoredProcedure(dmoStoredProcedure.GetName(), dmoStoredProcedure.GetOwner(), dmoStoredProcedure.GetSystemObject() ? SqlObjectType.System : SqlObjectType.User, DateTime.Parse(dmoStoredProcedure.GetCreateDate()));
            // Set internal properties
            sproc.dmoStoredProcedure = dmoStoredProcedure;
            sproc.database = this.database;

            // Add to private list
            storedProcedures.Add(sproc);

            return sproc;
        }

        /// <summary>
        /// Copies the items from the SqlStoredProcedureCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
        /// Returns an System.Collections.IEnumerator interface that contains all SqlStoredProcedure objects in the SqlStoredProcedureCollection.
        /// </summary>
        /// <returns>
        /// A System.Collections.IEnumerator interface that contains all SqlStoredProcedure objects in the SqlStoredProcedureCollection.
        /// </returns>
        public IEnumerator GetEnumerator() {
            if (storedProcedures == null) {
                storedProcedures = new ArrayList();
            }

            return storedProcedures.GetEnumerator(0, Count);
        }

        /// <summary>
        /// Updates the SqlStoredProcedureCollection with any changes made since the last call to Refresh.
        /// Refresh is automatically called once when the SqlTable.StoredProcedures collection is read.
        /// </summary>
        public void Refresh() {
            // Force internal refresh of tables
            database.dmoDatabase.GetStoredProcedures().Refresh(false);

            // Clear out old list
            storedProcedures = new ArrayList();

            for (int i = 0; i < database.dmoDatabase.GetStoredProcedures().GetCount(); i++) {
                NativeMethods.IStoredProcedure dmoSproc = database.dmoDatabase.GetStoredProcedures().Item(i + 1, "");

                SqlStoredProcedure sproc;

                if (dmoSproc.GetSystemObject())
                    sproc = new SqlStoredProcedure(dmoSproc.GetName(), dmoSproc.GetOwner(), SqlObjectType.System, DateTime.Parse(dmoSproc.GetCreateDate()));
                else
                    sproc = new SqlStoredProcedure(dmoSproc.GetName(), dmoSproc.GetOwner(), SqlObjectType.User, DateTime.Parse(dmoSproc.GetCreateDate()));

                storedProcedures.Add(sproc);

                sproc.dmoStoredProcedure = dmoSproc;
                sproc.database = this.database;
            }
        }
    }
}
