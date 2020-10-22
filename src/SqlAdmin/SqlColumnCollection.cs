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
    /// A collection of SqlColumn objects that represent the columns in a SQL table.
    /// </summary>
	public class SqlColumnCollection {
        private ArrayList columns;
        private SqlTable table;


        internal SqlColumnCollection(SqlTable table) {
            this.table = table;
        }


        /// <summary>
        /// Gets the number of columns in the SqlColumnCollection.
        /// </summary>
        public int Count {
            get {
                if (columns != null)
                    return columns.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the columns in the SqlColumnCollection can be modified.
        /// </summary>
        public bool IsReadOnly {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the SqlColumnCollection is synchronized (thread-safe).
        /// </summary>
        public bool IsSynchronized {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the object that can be used to synchronize access to the SqlColumnCollection.
        /// </summary>
        public object SyncRoot {
            get {
                return this;
            }
        }

        /// <summary>
        /// Gets a SqlColumn object from the SqlColumnCollection collection at the specified index.
        /// </summary>
        public SqlColumn this[int index] {
            get {
				if (columns != null) {
					if (index >= Count)
						return null;

					return (SqlColumn)(columns[index]);
				}
				else
					return null;
            }
        }

        /// <summary>
        /// Gets a SqlColumn object from the SqlColumnCollection collection that has the specified name (case-insensitive).
        /// </summary>
        public SqlColumn this[string name] {
            get {
                if (columns != null) {
                    for (int i = 0; i < columns.Count; i++) {
                        if (name.ToLower() == ((SqlColumn)columns[i]).cachedName.ToLower())
                            return (SqlColumn)(columns[i]);
                    }
                }

                // If there is no column list, or the name does not exist, return null
                return null;
            }
        }


        /// <summary>
        /// Adds a new column to the table with specified column information.
        /// </summary>
        /// <param name="columnInfo">
        /// The column information for the column to add.
        /// </param>
        /// <returns>
        /// If the operation succeeded, the return value is the column created.
        /// </returns>
        public SqlColumn Add(SqlColumnInformation columnInfo) {
            // Do some basic error checking - leave the rest up to DMO
            if (columnInfo.Name == null || columnInfo.Name.Length == 0)
                throw new ArgumentException(SR.GetString("SqlColumnCollection_MustHaveValidName"));

            if (columnInfo.DataType == null || columnInfo.DataType.Length == 0)
                throw new ArgumentException(SR.GetString("SqlColumnCollection_MustHaveValidDataType"));

            if (this[columnInfo.Name] != null)
                throw new ArgumentException(String.Format(SR.GetString("SqlColumnCollection_NameAlreadyExists"), columnInfo.Name));


            // Create new DMO column
            NativeMethods.IColumn dmoColumn = (NativeMethods.IColumn)new NativeMethods.Column();


            dmoColumn.SetName(columnInfo.Name);
            dmoColumn.SetDatatype(columnInfo.DataType);
            dmoColumn.SetLength(columnInfo.Size);
            dmoColumn.SetAllowNulls(columnInfo.Nulls);
            dmoColumn.SetNumericPrecision(columnInfo.Precision);
            dmoColumn.SetNumericScale(columnInfo.Scale);
            dmoColumn.SetIdentity(columnInfo.Identity);
            dmoColumn.SetIdentitySeed(columnInfo.IdentitySeed);
            dmoColumn.SetIdentityIncrement(columnInfo.IdentityIncrement);
            dmoColumn.SetIsRowGuidCol(columnInfo.IsRowGuid);
            dmoColumn.GetDRIDefault().SetText(columnInfo.DefaultValue);


            // Physically add the column
            table.dmoTable.BeginAlter();
            table.dmoTable.GetColumns().Add(dmoColumn);
            table.dmoTable.DoAlter();

            // If this column is to be included in the primary key, do some stuff
            if (columnInfo.Key) {
                // Find out if there is a primary key...
                NativeMethods.IKey primaryKey = null;
                NativeMethods.IKeys keys = table.dmoTable.GetKeys();
                for (int i = 0; i < keys.GetCount(); i++) {
                    if (keys.Item(i + 1).GetType() == NativeMethods.SQLDMO_KEY_TYPE.SQLDMOKey_Primary) {
                        primaryKey = keys.Item(i + 1);
                        break;
                    }
                }

                if (primaryKey != null) {
                    // If there is a primary key, just add the column to the list of columns
                }
                else {
                    // If there is no primary key, create new primary key and add thie column as the only column
                    primaryKey = (NativeMethods.IKey)new NativeMethods.Key();
                    primaryKey.SetType(NativeMethods.SQLDMO_KEY_TYPE.SQLDMOKey_Primary);
                    primaryKey.GetKeyColumns().Add(columnInfo.Name);
                    table.dmoTable.GetKeys().Add(primaryKey);
                }
            }


            // Read the data back out
            columnInfo = new SqlColumnInformation(dmoColumn.GetInPrimaryKey(), dmoColumn.GetIdentity(), dmoColumn.GetName(), dmoColumn.GetDatatype(), dmoColumn.GetLength(), dmoColumn.GetNumericScale(), dmoColumn.GetNumericPrecision(), dmoColumn.GetAllowNulls(), dmoColumn.GetDRIDefault().GetText(), dmoColumn.GetIdentitySeed(), dmoColumn.GetIdentityIncrement(), dmoColumn.GetIsRowGuidCol());
			SqlColumn column = new SqlColumn(columnInfo);

            // Set internal properties
			column.dmoColumn = dmoColumn;
			column.table = this.table;

            // Add to private list
            columns.Add(column);

            return column;
        }

        /// <summary>
        /// Copies the items from the SqlColumnCollection to the specified System.Array object, starting at the specified index in the System.Array object.
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
        /// Returns an System.Collections.IEnumerator interface that contains all SqlColumn objects in the SqlColumnCollection.
        /// </summary>
        /// <returns>
        /// A System.Collections.IEnumerator interface that contains all SqlColumn objects in the SqlColumnCollection.
        /// </returns>
        public IEnumerator GetEnumerator() {
            if (columns == null) {
                columns = new ArrayList();
            }

            return columns.GetEnumerator(0, Count);
        }

        /// <summary>
        /// Updates the SqlColumnCollection with any changes made since the last call to Refresh.
        /// Refresh is automatically called once when the SqlTable.Columns collection is read.
        /// </summary>
        public void Refresh() {
            // Force internal refresh of tables
            table.dmoTable.GetColumns().Refresh(false);

            // Clear out old list
            columns = new ArrayList();

            for (int i = 0; i < table.dmoTable.GetColumns().GetCount(); i++) {
                NativeMethods.IColumn dmoColumn = table.dmoTable.GetColumns().Item(i + 1);
             
				SqlColumnInformation columnInfo = new SqlColumnInformation(dmoColumn.GetInPrimaryKey(), dmoColumn.GetIdentity(), dmoColumn.GetName(), dmoColumn.GetDatatype(), dmoColumn.GetLength(), dmoColumn.GetNumericScale(), dmoColumn.GetNumericPrecision(), dmoColumn.GetAllowNulls(), dmoColumn.GetDRIDefault().GetText(), dmoColumn.GetIdentitySeed(), dmoColumn.GetIdentityIncrement(), dmoColumn.GetIsRowGuidCol());
				SqlColumn column = new SqlColumn(columnInfo);

                columns.Add(column);

                column.dmoColumn = dmoColumn;
                column.table = this.table;
            }
        }
    }
}
