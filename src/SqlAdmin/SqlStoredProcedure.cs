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
    /// Represents a SQL stored procedure.
    /// </summary>
	public class SqlStoredProcedure {

        internal NativeMethods.IStoredProcedure dmoStoredProcedure = null;
        internal SqlDatabase database = null;

        private string name;
        private string owner;
        private SqlObjectType storedProcedureType;
        private DateTime createDate;


        internal SqlStoredProcedure(string name, string owner, SqlObjectType storedProcedureType, DateTime createDate) {
            this.name                = name;
            this.owner               = owner;
            this.storedProcedureType = storedProcedureType;
            this.createDate          = createDate;
        }


        /// <summary>
        /// The date and time when this stored procedure was created.
        /// </summary>
        public DateTime CreateDate {
            get {
                return createDate;
            }
        }

        /// <summary>
        /// The SqlDatabase to which this stored procedure belongs.
        /// </summary>
        public SqlDatabase Database {
            get {
                return database;
            }
        }

        /// <summary>
        /// The name of this stored procedure.
        /// </summary>
        public string Name {
            get {
                return name;
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
        /// A SqlObjectType value indicating whether this is a User stored procedure or a System stored procedure.
        /// </summary>
        public SqlObjectType StoredProcedureType {
            get {
                return storedProcedureType;
            }
        }

        /// <summary>
        /// The text of this stored procedure.
        /// The text must contain a valid SQL stored procedure creation statement.
        /// </summary>
        public string Text {
            get {
                return dmoStoredProcedure.GetText();
            }
            set {
                dmoStoredProcedure.Alter(value);
            }
        }


        /// <summary>
        /// Permanently removes this stored procedure from the database.
        /// </summary>
        public void Remove() {
            // Permanently delete this stored procedure
            dmoStoredProcedure.Remove();
        }

        /// <summary>
        /// Generates a Transact-SQL command batch that can be used to re-create the SQL stored procedure.
        /// </summary>
        /// <param name="scriptType">
        /// A SqlScriptType indicating what to include in the script.
        /// </param>
        /// <returns>
        /// A string containing a Transact-SQL command batch that can be used to re-create the SQL stored procedure.
        /// </returns>
        /// <remarks>
        /// The valid SqlScriptType values are: Create, Drop, Comments.
        /// </remarks>
        public string Script(SqlScriptType scriptType) {
            int dmoScriptType = 0;

            if ((scriptType & SqlScriptType.Create) == SqlScriptType.Create)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default;

            if ((scriptType & SqlScriptType.Drop) == SqlScriptType.Drop)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Drops;

            if ((scriptType & SqlScriptType.Comments) == SqlScriptType.Comments)
                dmoScriptType |= NativeMethods.SQLDMO_SCRIPT_TYPE.SQLDMOScript_IncludeHeaders;


            return dmoStoredProcedure.Script(dmoScriptType, null, 0);
        }
    }
}
