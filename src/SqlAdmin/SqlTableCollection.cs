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
    /// A collection of SqlTable objects that represent the tables in a SQL database.
    /// </summary>
    public class SqlTableCollection : ICollection {
        private ArrayList tables;
        private SqlDatabase database;


        internal SqlTableCollection(SqlDatabase database) {
            this.database = database;
        }


        /// <summary>
        /// Gets the number of tables in the SqlTableCollection.
        /// </summary>
        public int Count {
            get {
                if (tables != null)
                    return tables.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the columns in the SqlTableCollection can be modified.
        /// </summary>
        public bool IsReadOnly {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the SqlTableCollection is synchronized (thread-safe).
        /// </summary>
        public bool IsSynchronized {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the object that can be used to synchronize access to the SqlTableCollection.
        /// </summary>
        public object SyncRoot {
            get {
                return this;
            }
        }

        /// <summary>
        /// Gets a SqlTable object from the SqlTableCollection collection at the specified index.
        /// </summary>
        public SqlTable this[int index] {
            get {
                if (tables != null)
                    return (SqlTable)(tables[index]);
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets a SqlTable object from the SqlTableCollection collection that has the specified name (case-insensitive).
        /// </summary>
        public SqlTable this[string name] {
            get {
                if (tables != null) {
                    for (int i = 0; i < tables.Count; i++) {
                        if (name.ToLower() == ((SqlTable)tables[i]).Name.ToLower())
                            return (SqlTable)(tables[i]);
                    }
                }

                // If there is no table list, or the name does not exist, return null
                return null;
            }
        }


        /// <summary>
        /// Adds a new table to the database with specified columns.
        /// </summary>
        /// <param name="name">
        /// The name of the table to create.
        /// </param>
        /// <param name="columnInfos">
        /// An array of at least one SqlColumnInformation object with the column information filled out.
        /// </param>
        /// <returns>
        /// If the operation succeeded, the return value is the table created.
        /// </returns>
        public SqlTable Add(string name, SqlColumnInformation[] columnInfos) {
            if (name == null || name.Length == 0)
                throw new ArgumentException(SR.GetString("SqlTableCollection_MustHaveValidName"));

            if (this[name] != null)
                throw new ArgumentException(String.Format(SR.GetString("SqlTableCollection_NameAlreadyExists"), name));

            if (columnInfos == null || columnInfos.Length == 0)
                throw new ArgumentException(SR.GetString("SqlTableCollection_AtLeastOneColumn"));

            // Create new table
            NativeMethods.ITable dmoTable = (NativeMethods.ITable)new NativeMethods.Table();
            dmoTable.SetName(name);


            // No need to clear out keys since this is a new table
            // Create new primary key with list of columns
            NativeMethods.IKey key = (NativeMethods.IKey)new NativeMethods.Key();
            key.SetType(NativeMethods.SQLDMO_KEY_TYPE.SQLDMOKey_Primary);


            // Add columns to table
            for (int i = 0; i < columnInfos.Length; i++) {
                NativeMethods.IColumn dmoColumn = (NativeMethods.IColumn)new NativeMethods.Column();

                dmoColumn.SetName(columnInfos[i].Name);
				dmoColumn.SetDatatype(columnInfos[i].DataType);
				dmoColumn.SetLength(columnInfos[i].Size);
				dmoColumn.SetAllowNulls(columnInfos[i].Nulls);
				dmoColumn.SetNumericPrecision(columnInfos[i].Precision);
				dmoColumn.SetNumericScale(columnInfos[i].Scale);
				dmoColumn.SetIdentity(columnInfos[i].Identity);
				dmoColumn.SetIdentitySeed(columnInfos[i].IdentitySeed);
				dmoColumn.SetIdentityIncrement(columnInfos[i].IdentityIncrement);
				dmoColumn.SetIsRowGuidCol(columnInfos[i].IsRowGuid);

                // According to SQL Server Books Online, a name for this default will be generated automatically
                dmoColumn.GetDRIDefault().SetText(columnInfos[i].DefaultValue);

                // Add the column on the DMO side
                dmoTable.GetColumns().Add(dmoColumn);

                // If this column is in the primary key, add it to the primary key column list
                if (columnInfos[i].Key)
                    key.GetKeyColumns().Add(columnInfos[i].Name);
            }


            // If there is anything in the primary key, add it
            if (key.GetKeyColumns().GetCount() > 0) {
                dmoTable.GetKeys().Add(key);
            }


            // Add table to database
            database.dmoDatabase.GetTables().Add(dmoTable);


            database.Server.Databases.Refresh();
            this.Refresh();

            return this[name];
        }

        /// <summary>
        /// Copies the items from the SqlTableCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
        /// Returns an System.Collections.IEnumerator interface that contains all SqlTable objects in the SqlTableCollection.
        /// </summary>
        /// <returns>
        /// A System.Collections.IEnumerator interface that contains all SqlTable objects in the SqlTableCollection.
        /// </returns>
        public IEnumerator GetEnumerator() {
            if (tables == null) {
                tables = new ArrayList();
            }

            return tables.GetEnumerator(0, Count);
        }

        /// <summary>
        /// Updates the SqlTableCollection with any changes made since the last call to Refresh.
        /// Refresh is automatically called once when the SqlDatabase.Tables collection is read.
        /// </summary>
        public void Refresh() {
            // Force internal refresh of tables
            database.dmoDatabase.GetTables().Refresh(false);

            // Clear out old list
            tables = new ArrayList();

            for (int i = 0; i < database.dmoDatabase.GetTables().GetCount(); i++) {
                NativeMethods.ITable dmoTable = database.dmoDatabase.GetTables().Item(i + 1, "");

                SqlTable table;

                if (dmoTable.GetSystemObject())
                    table = new SqlTable(dmoTable.GetName(), dmoTable.GetOwner(), SqlObjectType.System, DateTime.Parse(dmoTable.GetCreateDate()));
                else
                    table = new SqlTable(dmoTable.GetName(), dmoTable.GetOwner(), SqlObjectType.User, DateTime.Parse(dmoTable.GetCreateDate()));

                tables.Add(table);

                table.dmoTable = dmoTable;
                table.database = this.database;
            }
        }
    }
}
