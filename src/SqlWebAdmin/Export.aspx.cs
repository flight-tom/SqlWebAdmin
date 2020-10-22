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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SqlAdmin;

namespace SqlWebAdmin
{
    public partial class export : System.Web.UI.Page
    {



        protected void Page_Load(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			
            server.Connect();
            SqlDatabaseCollection databases = server.Databases;
            server.Disconnect();

            // Clear out list and populate with database names
            if (!IsPostBack) {
                ExportDatabaseList.Items.Clear();

                for (int i = 0; i < databases.Count; i++) {
                    ExportDatabaseList.Items.Add(new ListItem(databases[i].Name));
                }
            }
        }

        private bool IsValidChar(char c) {
            int i = Convert.ToInt32(c);
            int charA = Convert.ToInt32('A');
            int chara = Convert.ToInt32('a');
            int char0 = Convert.ToInt32('0');
            if ((i >= charA && i <= charA + 26) ||
                (i >= chara && i <= chara + 26) ||
                (i >= char0 && i <= char0 + 10))
                return true;
            else
                return false;
        }

        protected void ExportButton_Click(object sender, System.EventArgs e) {
            // Do the export - this will just pop open a Save As dialog box
            string databaseName         = ExportDatabaseList.SelectedItem.Text;
            bool scriptDatabase         = ScriptDatabaseCheckBox.Checked;
            bool scriptDrop             = ScriptDropCheckBox.Checked;
            bool scriptTableSchema      = ScriptTableSchemeCheckBox.Checked;
            bool scriptTableData        = ScriptTableDataCheckBox.Checked;
            bool scriptStoredProcedures = ScriptStoredProceduresCheckBox.Checked;
            bool scriptComments         = ScriptCommentsCheckBox.Checked;


			SqlServer server = SqlServer.CurrentServer;
			
            server.Connect();

            SqlDatabase database = server.Databases[databaseName];
            if (database == null) {
                server.Disconnect();

                // Database doesn't exist - break out and go to error page
                Response.Redirect(String.Format("error.aspx?error={0}", 1000));
                return;
            }

            SqlTableCollection tables = database.Tables;
            SqlStoredProcedureCollection sprocs = database.StoredProcedures;


            StringBuilder scriptResult = new StringBuilder();
            scriptResult.Append(String.Format("/* Generated by Web Data Administrator on {0} */\r\n\r\n", DateTime.Now.ToString()));
            scriptResult.Append("/* Options selected: ");
            if (scriptDatabase)         scriptResult.Append("database ");
            if (scriptDrop)             scriptResult.Append("drop-commands ");
            if (scriptTableSchema)      scriptResult.Append("table-schema ");
            if (scriptTableData)        scriptResult.Append("table-data ");
            if (scriptStoredProcedures) scriptResult.Append("stored-procedures ");
            if (scriptComments)         scriptResult.Append("comments ");
            scriptResult.Append(" */\r\n\r\n");


            // Script flow:
            // DROP and CREATE database
            // use [database]
            // GO
            // DROP sprocs
            // DROP tables
            // CREATE tables without constraints
            // Add table data
            // Add table constraints
            // CREATE sprocs


            // Drop and create database
            if (scriptDatabase)
                scriptResult.Append(database.Script(
                    SqlScriptType.Create |
                    (scriptDrop ? SqlScriptType.Drop : 0) |
                    (scriptComments ? SqlScriptType.Comments : 0)));


            // Use database
            scriptResult.Append(String.Format("\r\nuse [{0}]\r\nGO\r\n\r\n", databaseName));


            // Drop stored procedures
            if (scriptStoredProcedures && scriptDrop) {
                for (int i = 0; i < sprocs.Count; i++) {
                    if (sprocs[i].StoredProcedureType == SqlObjectType.User) {
                        scriptResult.Append(sprocs[i].Script(SqlScriptType.Drop | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }
            }


            // Drop tables (this includes schemas and data)
            if (scriptTableSchema && scriptDrop) {
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Drop | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }
            }


            // Create table schemas
            if (scriptTableSchema) {
                // First create tables with no constraints
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Create | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }
            }


            // Create table data
            if (scriptTableData) {
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptData(scriptComments ? SqlScriptType.Comments : 0));
                    }
                }
            }


            if (scriptTableSchema) {
                // Add defaults, primary key, and checks
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Defaults | SqlScriptType.PrimaryKey | SqlScriptType.Checks | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }

                // Add foreign keys
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.ForeignKeys | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }

                // Add unique keys
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.UniqueKeys | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }

                // Add indexes
                for (int i = 0; i < tables.Count; i++) {
                    if (tables[i].TableType == SqlObjectType.User) {
                        scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Indexes | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }
            }


            // Create stored procedures
            if (scriptStoredProcedures) {
                for (int i = 0; i < sprocs.Count; i++) {
                    if (sprocs[i].StoredProcedureType == SqlObjectType.User) {
                        scriptResult.Append(sprocs[i].Script(SqlScriptType.Create | (scriptComments ? SqlScriptType.Comments : 0)));
                    }
                }
            }


            server.Disconnect();


            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();

            // Set the filename to consist of only valid filename chars: [A-Za-z0-9]
            string filename = "";
            for (int i = 0; i < databaseName.Length; i++) {
                if (IsValidChar(databaseName[i]))
                    filename += databaseName[i];
            }

            // This header (RFC 1806) lets us set the suggested filename
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + "_export.sql");
            Response.Write(scriptResult.ToString());

            Response.End();
        }


        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    
        }
        #endregion
    }
}
