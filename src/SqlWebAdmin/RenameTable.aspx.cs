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
    /// Summary description for RenameTable.
    /// </summary>
    public partial class RenameTable : System.Web.UI.Page
    {


        public RenameTable()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ErrorCreatingLabel.Visible = false;

            if (!IsPostBack)
                TableNameTextBox.Text = Request["table"];
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


        protected void RenameButton_Click(object sender, System.EventArgs e) {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            server.Connect();

            SqlTable table = database.Tables[Request["table"]];
            if (table == null) {
                server.Disconnect();

                // Table doesn't exist - break out and go to error page
                Response.Redirect(String.Format("error.aspx?error={0}", 1002));
                return;
            }

            // Rename the table
            try {
                table.Name = TableNameTextBox.Text;

                // If successful, disconnect
                server.Disconnect();

                // Redirect to info page
                Response.Redirect(String.Format("tables.aspx?database={0}", Server.UrlEncode(Request["database"])));
            }
            catch (Exception ex) {
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "There was an error renaming the table:<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");

                server.Disconnect();
            }
        }

        protected void CancelButton_Click(object sender, System.EventArgs e) {
            // Redirect to info page
            Response.Redirect(String.Format("tables.aspx?database={0}", Server.UrlEncode(Request["database"])));
        }
    }
}
