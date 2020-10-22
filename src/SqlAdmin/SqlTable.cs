//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2009  Microsoft Corporation & Haiyan Du.  All rights reserved.
//
//=====================================================================
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SqlAdmin {
    /// <summary>
    /// Represents a SQL table.
    /// </summary>
	public class SqlTable {
        internal NativeMethods.ITable dmoTable = null;
        internal SqlDatabase database = null;

        private string name;
        private string owner;
        private SqlObjectType tableType;
        private DateTime createDate;


		internal SqlTable(string name, string owner, SqlObjectType tableType, DateTime createDate) {
            this.name = name;
            this.owner = owner;
            this.tableType = tableType;
            this.createDate = createDate;
           
		}
        /// <summary>
        /// return Current Database Table
        /// </summary>
        public static SqlTable CurrentTable
        {
            get {
                SqlServer server = SqlServer.CurrentServer;
                server.Connect();
                SqlDatabase database = SqlDatabase.CurrentDatabase(server);
                if (HttpContext.Current.Request["table"] != null)
                {
                    SqlTable curTable = database.Tables[HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Request["table"])];
                    return curTable;
                }
                else
                {
                    return null;
                }
                server.Disconnect();
            
            }
        }

        /// <summary>
        /// Insert ID Column if table doesn't have primary key fields
        /// </summary>
        public void AddIDColumn()
        {
            if (PrimaryKeys == null || PrimaryKeys.Length < 1)
            {
                SqlColumnInformation scInfo = new SqlColumnInformation();
                scInfo.Key = true;
                scInfo.Identity = true;
                scInfo.IdentityIncrement = 1;
                scInfo.IdentitySeed = 1;
                scInfo.Name = "AutoGenID";
                scInfo.DataType = "int";
                scInfo.Nulls = false;
            
                Columns.Add(scInfo);               
   
            }
        }

        /// <summary>
        /// Gets a collection of SqlColumn objects that represent the individual columns in this table.
        /// </summary>
        public SqlColumnCollection Columns {
            get {
                SqlColumnCollection columnsCollection = new SqlColumnCollection(this);
                columnsCollection.Refresh();
                return columnsCollection;
            }
        }

        /// <summary>
        /// The date and time when this table was created.
        /// </summary>
        public DateTime CreateDate {
            get {
                return createDate;
            }
        }

        /// <summary>
        /// The SqlDatabase to which this table belongs.
        /// </summary>
        public SqlDatabase Database {
            get {
                return database;
            }
        }

        /// <summary>
        /// The name of the table.
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                // Rename both the DMO table and the internal name
                dmoTable.SetName(value);
                name = value;
            }
        }

        /// <summary>
        /// The owner of the table.
        /// </summary>
        public string Owner {
            get {
                return owner;
            }
        }

        /// <summary>
        /// The number of rows used in this table.
        /// </summary>
        public int Rows {
            get {
                return dmoTable.GetRows();
            }
        }

        /// <summary>
        /// A SqlObjectType value indicating whether this is a User table or a System table.
        /// </summary>
        public SqlObjectType TableType {
            get {
                return tableType;
            }
        }
       ///// <summary>
       ///// return current http URL Request of table name
       ///// </summary>
       ///// <returns></returns>
       // public static string CurrentTable()
       // {
       //     if (HttpContext.Current.Request["table"] != null)
       //     {
       //         string curTable = HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Request["table"]);
       //         return curTable;
       //     }
       //     else
       //         return "";
           
       // }
        /// <summary>
        /// Permanently removes this table from the database.
        /// </summary>
        public void Remove() {
            // Permanently delete this table
            dmoTable.Remove();
        }

        /// <summary>
        /// Get Table Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableData()
        {
            // Grab data from table
            DataTable[] tables = Database.Query(string.Format("select * from [{0}].[{1}]",owner,name));
            return tables[0];
        }

        /// <summary>
        /// Generates a Transact-SQL command batch that can be used to re-create the data in the SQL table.
        /// </summary>
        /// <param name="scriptType">
        /// A SqlScriptType indicating what to include in the script.
        /// </param>
        /// <returns>
        /// A string containing a Transact-SQL command batch that can be used to re-create the data in the SQL table.
        /// </returns>
        /// <remarks>
        /// The valid SqlScriptType values are: Comments.
        /// </remarks>
        public string ScriptData(SqlScriptType scriptType) {

            // Grab data from table
            DataTable[] tables = Database.Query("select * from [" + name + "]");

            DataTable table = tables[0];

            StringBuilder sb = new StringBuilder();

            if ((scriptType & SqlScriptType.Comments) == SqlScriptType.Comments)
                sb.Append(String.Format(SR.GetString("SqlTable_ExportComment") + "\r\n", name));

            // If necessary, turn on identity insert
            bool hasIdentity = false;

            string[] columnNamesArray = new string[this.Columns.Count];

            for (int i = 0; i < this.Columns.Count; i++) {
                columnNamesArray[i] = "[" + this.Columns[i].ColumnInformation.Name + "]";

                if (this.Columns[i].ColumnInformation.Identity) {
                    hasIdentity = true;
                }
            }

            string columnNames = String.Join(", ", columnNamesArray);

            if (hasIdentity)
                sb.Append("SET identity_insert [" + this.Name + "] on\r\n\r\n");

            // Go through each row
            for (int i = 0; i < table.Rows.Count; i++) {
                object[] cols = table.Rows[i].ItemArray;
                sb.Append(String.Format("INSERT [{0}] ({1}) VALUES (", name, columnNames));

                // And through each column within the row
                for (int j = 0; j < cols.Length; j++) {
                    if (j > 0)
                        sb.Append(", ");

                    System.Type dataType = table.Columns[j].DataType;

                    // If null, print null, otherwise output data based on type
                    if (table.Rows[i].IsNull(j)) {
                        // Database Null is just NULL
                        sb.Append("NULL");
                    }
                    else if (dataType == typeof(System.Int32) ||
                             dataType == typeof(System.Int16) ||
                             dataType == typeof(System.Decimal) ||
                             dataType == typeof(System.Single)) {
                        // Numeric datatypes we just emit as-is
                        sb.Append(cols[j]);
                    }
                    else if (dataType == typeof(System.DateTime) ||
                             dataType == typeof(System.String)) {
                        // Strings and date/time's get quoted

                        // Escape single quotes in strings (replace with two single quotes)
                        sb.Append(String.Format("'{0}'", cols[j].ToString().Replace("'", "''")));
                    }
                    else if (dataType == typeof(System.Boolean)) {
                        // Booleans are false=0 and true=1
                        if ((System.Boolean)cols[j])
                            sb.Append("1");
                        else
                            sb.Append("0");
                    }
                    else if (dataType == typeof(System.Byte[])) {
                        // Byte arrays are in the form 0x0123456789ABCDEF
                        System.Byte[] array = (System.Byte[])cols[j];
                        sb.Append("0x");
                        for (int a = 0; a < array.Length; a++)
                            sb.Append(array[a].ToString("X"));
                    }
                    else {
                        // Default is to call ToString() and quote it

                        // Escape single quotes in strings (replace with two single quotes)
                        sb.Append(String.Format("'{0}'", cols[j].ToString().Replace("'", "''")));
                    }
                }

                sb.Append(")\r\n");

                // Stick in a GO statement to make batches smaller
                //if ((i + 1) % 10 == 0)
                //    sb.Append("GO\r\n");
            }

            //sb.Append("GO\r\n\r\n");

            // If we turned on identity insert, turn it off now
            if (hasIdentity)
                sb.Append("SET identity_insert [" + this.Name + "] off\r\nGO\r\n");

            return sb.ToString();
        }

        /// <summary>
        /// Generates a Transact-SQL command batch that can be used to re-create the SQL table.
        /// </summary>
        /// <param name="scriptType">
        /// A SqlScriptType indicating what to include in the script.
        /// </param>
        /// <returns>
        /// A string containing a Transact-SQL command batch that can be used to re-create the SQL table.
        /// </returns>
        /// <remarks>
        /// The valid SqlScriptType values are: Create, Drop, Comments, Defaults, PrimaryKey, ForeignKeys, UniqueKeys, Checks, Indexes.
        /// </remarks>
        public string ScriptSchema(SqlScriptType scriptType) {
            int dmoScriptType = 0;

            if ((scriptType & SqlScriptType.Create) == SqlScriptType.Create)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default | NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_NoDRI;

            if ((scriptType & SqlScriptType.Defaults) == SqlScriptType.Defaults)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRI_Defaults | NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRIWithNoCheck;

            if ((scriptType & SqlScriptType.PrimaryKey) == SqlScriptType.PrimaryKey)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRI_PrimaryKey | NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRIWithNoCheck;

            if ((scriptType & SqlScriptType.Checks) == SqlScriptType.Checks)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRI_Checks | NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRIWithNoCheck;

            if ((scriptType & SqlScriptType.ForeignKeys) == SqlScriptType.ForeignKeys)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRI_ForeignKeys;

            if ((scriptType & SqlScriptType.UniqueKeys) == SqlScriptType.UniqueKeys)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRI_UniqueKeys;

            if ((scriptType & SqlScriptType.Indexes) == SqlScriptType.Indexes)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_DRIIndexes;

            if ((scriptType & SqlScriptType.Drop) == SqlScriptType.Drop)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Drops;

            if ((scriptType & SqlScriptType.Comments) == SqlScriptType.Comments)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_IncludeHeaders;


            return dmoTable.Script(dmoScriptType, null, null, 0);
        }

        /// <summary>
        /// Get Select Command for SqlDataSource control
        /// </summary>
        /// <returns></returns>
        public string GetSelectCommandTag()
        {
            string strCommand = string.Format("select * from {0}", name);
            return strCommand;
        }
        /// <summary>
        /// Get Current Table Insert Script
        /// </summary>   
        /// <returns></returns>
        public string GetInsertCommandTag()
        {
            string dbfields = "";
            string valueFields = "";
            foreach (SqlColumn c in Columns)
            {
                if (!c.ColumnInformation.Identity)
                {
                    dbfields += "[" + c.ColumnInformation.Name + "],";
                    valueFields += "@" + c.ColumnInformation.Name + ",";
                }
            }
            dbfields = dbfields.Substring(0, dbfields.Length - 1);
            valueFields = valueFields.Substring(0, valueFields.Length - 1);
            string strCommand = string.Format("insert into [{0}]({1}) values({2})",name, dbfields, valueFields);
            return strCommand;
        }
        /// <summary>
        /// Get Delete Command string for SqlDataSource Control
        /// </summary>
        /// <returns></returns>
        public string GetDeleteCommandTag()
        {
            string strCommand = string.Format("Delete from [{0}] where ", name);
            if (PrimaryKeys != null && PrimaryKeys.Length > 0)
            {
                foreach (SqlColumn c in PrimaryKeys)
                {
                    strCommand += string.Format("{0}=@{0} and ", c.ColumnInformation.Name);
                }
            }
            else
            {
                foreach (SqlColumn c in Columns)
                {
                    strCommand += string.Format("{0}=@{0} and ", c.ColumnInformation.Name);
                }
            }
            strCommand = strCommand.Substring(0, strCommand.Length - 5);
            return strCommand;
        }
        /// <summary>
        /// Get UpdateCommand for SqlDataSorce control
        /// </summary>
        /// <returns></returns>
        public string GetUpdateCommandTag()
        {
            string strCommand = string.Format("Update [{0}].[{1}] set ",owner,name);
            foreach (SqlColumn c in Columns)
            {
                strCommand += string.Format("[{0}]=@{0},", c.ColumnInformation.Name);
            }
            strCommand=strCommand.Substring(0, strCommand.Length - 1); //remove last ,
            strCommand += " Where ";
            if (PrimaryKeys != null && PrimaryKeys.Length>0)
            {
                foreach (SqlColumn c in PrimaryKeys)
                {
                    strCommand += string.Format("[{0}]=@{0} and ", c.ColumnInformation.Name);
                }
            }
            else
            {
                foreach (SqlColumn c in Columns)
                {
                    strCommand += string.Format("[{0}]=@{0} and ", c.ColumnInformation.Name);
                }
            }
            strCommand = strCommand.Substring(0, strCommand.Length - 5); //remove last and
            return strCommand;

        }
        /// <summary>
        /// Primary Keys column in Sql table
        /// </summary>
        public SqlColumn[] PrimaryKeys
        { get {
            List<SqlColumn> lst = new List<SqlColumn>();
            foreach (SqlColumn c in Columns)
            {
                if (c.ColumnInformation.Key)
                {
                    lst.Add(c);
                }
            }
            
            return lst.ToArray();
        
        } }

        /// <summary>
        /// Get delete parameters for deleteParameters in SqlDataSource control
        /// </summary>
        /// <returns></returns>
        public Parameter[] GetDeleteParameters()
        {
            List<Parameter> lst = new List<Parameter>();
            if (PrimaryKeys != null && PrimaryKeys.Length > 0)
            {
                foreach (SqlColumn c in PrimaryKeys)
                {
                    Parameter p = new Parameter(c.ColumnInformation.Name, c.ColumnInformation.ColumnDbType);
                    lst.Add(p);
                }
                     
            }
            else
            {
                foreach (SqlColumn c in Columns)
                {
                    if (!c.ColumnInformation.Identity)
                    {
                        Parameter p = new Parameter(c.ColumnInformation.Name, c.ColumnInformation.ColumnDbType);
                        lst.Add(p);
                    }
                }
            }
            return lst.ToArray();
        }
        /// <summary>
        /// return Insert parameters for InsertParameters in SqlDataSource control
        /// </summary>
        /// <returns></returns>
        public Parameter[] GetInsertParameters()
        {
            List<Parameter> lst = new List<Parameter>();
            foreach (SqlColumn c in Columns)
            {
                if (!c.ColumnInformation.Identity)
                {
                    Parameter p = new Parameter(c.ColumnInformation.Name, c.ColumnInformation.ColumnDbType);
                    lst.Add(p);
                }
            }
            return lst.ToArray();
        }
        /// <summary>
        /// return Update parameters for UpdateParameters in SqlDataSource control
        /// </summary>
        /// <returns></returns>
        public Parameter[] GetUpdateParameters()
        {
            List<Parameter> lst = new List<Parameter>();
            foreach (SqlColumn c in Columns)
            {
                Parameter p = new Parameter(c.ColumnInformation.Name, c.ColumnInformation.ColumnDbType);
                lst.Add(p);
            }

            return lst.ToArray();
        }

        /// <summary>
        /// List of BoundField for DataGridView control, and other data asp.net server control.
        /// </summary>
        /// <returns></returns>
        public BoundField[] GetBoundFields()
        {
            List<BoundField> lst = new List<BoundField>();
            foreach (SqlColumn c in Columns)
            {  
                BoundField bFld = null;
            bFld = new BoundField();
            bFld.DataField = c.ColumnInformation.Name;
            bFld.HeaderText =c.ColumnInformation.Name;
            if (c.ColumnInformation.Identity)
            {
                bFld.ReadOnly = true;
                bFld.InsertVisible = false;
            }
            lst.Add(bFld);
            }
            return lst.ToArray();

        }
    }
}
