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
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Web;
using System.Collections.Generic;

namespace SqlAdmin {
    /// <summary>
    /// Represents a SQL database.
    /// </summary>
	public class SqlDatabase {

        internal NativeMethods.IDatabase dmoDatabase = null;
        internal SqlServer server = null;
        private string name;
        private int size;


        internal SqlDatabase(string name, int size) {
            this.name = name;
            this.size = size;
        }


        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        public string Name {
            get {
                return name;
            }
        }

        /// <summary>
        /// The server on which this database resides.
        /// </summary>
        public SqlServer Server {
            get {
                return server;
            }
        }

        /// <summary>
        /// The size of the database in megabytes. A size of -1 indicates that the user has insufficient permissions to see the size of the database.
        /// </summary>
        public int Size {
            get {
                return size;
            }
        }
		
		/// <summary>
		/// Gets a collection of SqlUser objects that represent the individual users of this database.
		/// </summary>
		public SqlUserCollection Users {
			get {
				SqlUserCollection sqlUserCollection = new SqlUserCollection( this);
				sqlUserCollection.Refresh();
				return sqlUserCollection;
			}
		}

		/// <summary>
		/// Gets a collection of SqlDatabaseRole objects that represent individual roles of this database.
		/// </summary>
		public SqlDatabaseRoleCollection DatabaseRoles {
			get { 
				SqlDatabaseRoleCollection sqlDatabaseRoleCollection = new SqlDatabaseRoleCollection(this);
				sqlDatabaseRoleCollection.Refresh();
				return sqlDatabaseRoleCollection;
			}
		}

        /// <summary>
        /// Gets a collection of SqlStoredProcedure objects that represent the individual stored procedures in this database.
        /// </summary>
        public SqlStoredProcedureCollection StoredProcedures {
            get {
                SqlStoredProcedureCollection storedProcedureCollection = new SqlStoredProcedureCollection(this);
                storedProcedureCollection.Refresh();
                return storedProcedureCollection;
            }
        }

        /// <summary>
        /// Gets a collection of SqlTable objects that represent the individual tables in this database.
        /// </summary>
        public SqlTableCollection Tables {
            get {
                SqlTableCollection tableCollection = new SqlTableCollection(this);
                tableCollection.Refresh();
                return tableCollection;
            }
        }

        /// <summary>
        /// List all possible sql dbtype
        /// </summary>
        public static Dictionary<string, System.Data.DbType> SqlDbTypeDictionary
        {
            get
            {
                Dictionary<string, System.Data.DbType> dic = new Dictionary<string, System.Data.DbType>();
                dic.Add("bigint", DbType.Int64);
                dic.Add("binary", DbType.Binary);
                dic.Add("char", DbType.String);
                dic.Add("datetime", DbType.DateTime);
                dic.Add("decimal", DbType.Decimal);
                dic.Add("float", DbType.Double);
                dic.Add("image", DbType.Object);
                dic.Add("int", DbType.Int32);
                dic.Add("money", DbType.Decimal);
                dic.Add("nchar", DbType.String);
                dic.Add("ntext", DbType.String);
                dic.Add("numeric", DbType.Decimal);
                dic.Add("nvarchar", DbType.String);
                dic.Add("real", DbType.Single);
                dic.Add("smalldatetime", DbType.DateTime);
                dic.Add("smallint", DbType.Int16);
                dic.Add("smallmoney", DbType.Decimal);
                dic.Add("sql_variant", DbType.Object);
                dic.Add("text", DbType.String);
                dic.Add("timestamp", DbType.Object);
                dic.Add("tinyint", DbType.Byte);
                dic.Add("uniqueidentifier", DbType.Object);
                dic.Add("varbinary", DbType.Object);
                dic.Add("varchar", DbType.String);
                dic.Add("xml", DbType.Object);
                return dic;
            }
        }

        /// <summary>
        /// Gets the properties of the database.
        /// These properties include database status, owner, create date, file properties, and more.
        /// </summary>
        /// <returns>
        /// The properties of the database.
        /// </returns>
        public SqlDatabaseProperties GetDatabaseProperties() {

            string databaseStatus;

            switch (dmoDatabase.GetStatus()) {
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_EmergencyMode:
                    databaseStatus = SR.GetString("SqlDatabase_Status_EmergencyMode");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Inaccessible:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Inaccessible");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Loading:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Loading");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Normal:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Normal");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Offline:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Offline");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Recovering:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Recovering");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Standby:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Standby");
                    break;
                case NativeMethods.SQLDMO_DBSTATUS_TYPE.SQLDMODBStat_Suspect:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Suspect");
                    break;
                default:
                    databaseStatus = SR.GetString("SqlDatabase_Status_Unknown");
                    break;
            }


            NativeMethods.IDBFile dataFile = dmoDatabase.GetFileGroups().Item(1).GetDBFiles().Item(1);
            NativeMethods.ILogFile logFile = dmoDatabase.GetTransactionLog().GetLogFiles().Item(1);

            SqlFileProperties dataFileProps = new SqlFileProperties((dataFile.GetFileGrowthType() == NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_MB) ? SqlFileGrowthType.MB : SqlFileGrowthType.Percent, dataFile.GetFileGrowth(), dataFile.GetMaximumSize());
            SqlFileProperties logFileProps = new SqlFileProperties((logFile.GetFileGrowthType() == NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_MB) ? SqlFileGrowthType.MB : SqlFileGrowthType.Percent, logFile.GetFileGrowth(), logFile.GetMaximumSize());

            SqlDatabaseProperties props = new SqlDatabaseProperties(dmoDatabase.GetName(), databaseStatus, dmoDatabase.GetOwner(), DateTime.Parse(dmoDatabase.GetCreateDate()), dmoDatabase.GetSize(), dmoDatabase.GetSpaceAvailable() / 1024F, dmoDatabase.GetUsers().GetCount(), dataFileProps, logFileProps);

            return props;
        }

        /// <summary>
        /// Runs a batch of SQL queries on the server using this database.
        /// </summary>
        /// <param name="query">
        /// A string containing a batch of SQL queries.
        /// </param>
        /// <returns>
        /// An array of DataTable objects containing grids for each result set (if any)
        /// </returns>
        public DataTable[] Query(string query) {
            return Server.Query(query, name);
        }

        /// <summary>
        /// Permanently removes this database from the server.
        /// </summary>
        public void Remove() {
            // Permanently delete this database
            dmoDatabase.Remove();
        }

        /// <summary>
        /// Generates a Transact-SQL command batch that can be used to re-create the SQL database.
        /// </summary>
        /// <param name="scriptType">
        /// A SqlScriptType indicating what to include in the script.
        /// </param>
        /// <returns>
        /// A string containing a Transact-SQL command batch that can be used to re-create the SQL database.
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
	
            return dmoDatabase.Script(dmoScriptType, null, 0);
        }

        /// <summary>
        /// Sets data file and transaction log file properties for this database.
        /// </summary>
        /// <param name="props">
        /// A list of properties to set.
        /// </param>
        /// <remarks>
        /// Only the data file and transaction log file properties are used.
        /// You cannot set the owner, create date, etc. properties of the database.
        /// </remarks>
        public void SetDatabaseProperties(SqlDatabaseProperties props) {

            NativeMethods.IDBFile dataFile = dmoDatabase.GetFileGroups().Item(1).GetDBFiles().Item(1);
            NativeMethods.ILogFile logFile = dmoDatabase.GetTransactionLog().GetLogFiles().Item(1);

            dataFile.SetFileGrowthType((props.DataFile.FileGrowthType == SqlFileGrowthType.MB) ?  NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_MB : NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_Percent);
            dataFile.SetFileGrowth(props.DataFile.FileGrowth);
            dataFile.SetMaximumSize(props.DataFile.MaximumSize);

            logFile.SetFileGrowthType((props.LogFile.FileGrowthType == SqlFileGrowthType.MB) ?  NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_MB : NativeMethods.SQLDMO_GROWTH_TYPE.SQLDMOGrowth_Percent);
            logFile.SetFileGrowth(props.LogFile.FileGrowth);
            logFile.SetMaximumSize(props.LogFile.MaximumSize);
        }

		/// <summary>
		/// Connects to the CurrentServer and returns the currently selected database.  
		/// Redirects to an errorpage if the currentDatabase is invalid or null.
		/// </summary>
		public static SqlDatabase CurrentDatabase(SqlServer server) 
		{
				SqlDatabase database = server.Databases[HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Request["database"])];

				if (database == null) 
				{
					server.Disconnect();

					// Database doesn't exist - break out and go to error page
					HttpContext.Current.Response.Redirect(String.Format("error.aspx?error={0}", 1000));
				}
				return database;
		}
    }
}
