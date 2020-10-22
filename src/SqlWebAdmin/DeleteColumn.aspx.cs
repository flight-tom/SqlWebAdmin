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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SqlAdmin;

namespace SqlWebAdmin
{
    /// <summary>
    /// Summary description for DeleteColumn.
    /// </summary>
    public partial class DeleteColumn : System.Web.UI.Page
    {


        public DeleteColumn()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
			// Note: While no security is checked at this point, it is impossible
			// for the delete operation to execute without authentication.
            TableNameLabel.Text = Server.HtmlEncode(Request["table"]);
            ColumnNameLabel.Text = Server.HtmlEncode(Request["column"]);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    
        }
        #endregion

        protected void YesButton_Click(object sender, System.EventArgs e) {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlTable table = database.Tables[Request["table"]];
            if (table == null) {
                server.Disconnect();

                // Table doesn't exist - break out and go to error page
                Response.Redirect(String.Format("error.aspx?error={0}", 1002));
                return;
            }

            if (table.Columns.Count == 1) {
                server.Disconnect();
                throw new Exception("Cannot delete last column from table. A table must contain at least one column.");
            }

            // Select column from table
            SqlColumn column = table.Columns[Request["column"]];
            if (column == null) {
                server.Disconnect();

                // Column doesn't exist - break out and go to error page
                Response.Redirect(String.Format("error.aspx?error={0}", 1003));
                return;
            }

            // Delete the sproc
            column.Remove();

            server.Disconnect();

            // Redirect to info page
            Response.Redirect(String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), Server.UrlEncode(Request["table"])));
        }

        protected void NoButton_Click(object sender, System.EventArgs e) {
            // Redirect to info page
            Response.Redirect(String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), Server.UrlEncode(Request["table"])));
        }
    }
}
