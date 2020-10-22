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
    /// Represents a SQL column.
    /// </summary>
    public class SqlColumn {
        internal NativeMethods.IColumn dmoColumn = null;
        internal SqlTable table = null;
		private SqlColumnInformation columnInfo;
		internal string cachedName;


        internal SqlColumn(SqlColumnInformation columnInfo) {
			this.columnInfo = columnInfo;
			cachedName = columnInfo.Name;
        }


        /// <summary>
        /// Gets or sets the column information.
        /// </summary>
        /// <remarks>
        /// When setting the column information, the table will be internally recreated, and certain table properties such as foreign keys and indexes will be lost.
        /// The primary key, however, will remain intact.
        /// </remarks>
		public SqlColumnInformation ColumnInformation {
			get {
				return columnInfo;
			}
			set {
				// We can only edit a column if the table is empty

				// TODO: Let users modify name/size/nulls/etc. on any column

				if (Table.Rows != 0)
					throw new InvalidOperationException(SR.GetString("SqlTable_MustBeEmpty"));

				// Cache our name
				string thisName = this.ColumnInformation.Name;

                string originalTableName = Table.Name;

                // Make unique table name
                string tmpTableName = "Tmp_" + Table.Name;
                while (Table.Database.Tables[tmpTableName] != null) {
                    tmpTableName += "_";
                }

                // Copy all old columns
				Table.Columns.Refresh();

				int count = Table.Columns.Count;

				SqlColumnInformation[] oldColumns = new SqlColumnInformation[count];
				for (int i = 0; i < count; i++) {
					if (Table.Columns[i].ColumnInformation.Name == thisName)
						oldColumns[i] = value;
					else
						oldColumns[i] = Table.Columns[i].ColumnInformation.Clone();
				}

				SqlTable tmpTable = null;


                // Rename this table to the temporary name
                Table.Name = tmpTableName;

				try {
					// Create new table with old columns
					Table.Database.Tables.Refresh();
					tmpTable = Table.Database.Tables.Add(originalTableName, oldColumns);
				}
				catch {
                    // If exception was thrown, delete temporary table and rename original table back to original name
                    if (Table.Database.Tables[originalTableName] != null)
                        Table.Database.Tables[originalTableName].Remove();
                    Table.Database.Tables[tmpTableName].Name = originalTableName;

                    // Rethrow the exception since we don't know what happened
                    throw;
				}


				// If operation succeeded on new table, delete original (renamed) table
                Table.Database.Tables[tmpTableName].Remove();

				Table.dmoTable = tmpTable.dmoTable;
				Table.Columns.Refresh();

				// Refresh column list
				tmpTable.Columns.Refresh();
				tmpTable.Database.Tables.Refresh();
			}
		}

        /// <summary>
        /// The SqlTable to which this column belongs.
        /// </summary>
        public SqlTable Table {
            get {
                return table;
            }
        }


        /// <summary>
        /// Permanently removes this column from the table.
        /// </summary>
        /// <remarks>
        /// If there are dependencies on this column other than a primary key or a default, the operation may fail.
        /// </remarks>
        public void Remove() {
            // Remove the primary key if this column is in it
            bool inPrimaryKey = this.ColumnInformation.Key;
            ArrayList keyColumns = new ArrayList();

            if (inPrimaryKey) {
                NativeMethods.IKeys keys = Table.dmoTable.GetKeys();
                for (int i = 0; i < keys.GetCount(); i++) {
                    // Find the primary key
                    if (keys.Item(i + 1).GetType() == NativeMethods.SQLDMO_KEY_TYPE.SQLDMOKey_Primary) {
                        // First we have to keep a list of columns so we can undo the operation
                        NativeMethods.INames columnNames = keys.Item(i + 1).GetKeyColumns();
                        for (int j = 0; j < columnNames.GetCount(); j++) {
                            keyColumns.Add(columnNames.Item(j + 1));
                        }

                        // Remove the primary key completely
                        // NOTE: This is what SQL Server Enterprise Manager does
                        keys.Remove(i + 1);
                        break;
                    }
                }
            }

            // Remove default
            string defaultValue = this.dmoColumn.GetDRIDefault().GetText();
            this.dmoColumn.GetDRIDefault().Remove();

            // Permanently delete this column
            try {
                dmoColumn.Remove();
            }
            catch {
                // Undo operations and rethrow the exception

                // Set default back
                this.dmoColumn.GetDRIDefault().SetText(defaultValue);

                // If necessary, create primary key and add original columns to it
                if (inPrimaryKey) {
                    NativeMethods.IKey primaryKey = (NativeMethods.IKey)new NativeMethods.Key();
                    primaryKey.SetType(NativeMethods.SQLDMO_KEY_TYPE.SQLDMOKey_Primary);
                    NativeMethods.INames columnNames = primaryKey.GetKeyColumns();
                    for (int i = 0; i < keyColumns.Count; i++) {
                        columnNames.Add(columnInfo.Name);
                    }
                    table.dmoTable.GetKeys().Add(primaryKey);
                }

                throw;
            }
        }
    }
}
