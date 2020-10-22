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
    /// Summary description for CreateDatabase.
    /// </summary>
    public partial class CreateDatabase : System.Web.UI.Page
    {
        
        public CreateDatabase()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
        }

        protected void CreateNewDatabaseButton_Click(object sender, System.EventArgs e)
        {
            // If database name is empty or invalid, quit immediately
            if (!IsValid)
                return;

			SqlServer server = SqlServer.CurrentServer;

            // Create the database

            ErrorCreatingLabel.Visible = false;

            bool success = true;

            server.Connect();

            // Check that database doesn't exist
            if (server.Databases[DatabaseNameTextBox.Text] != null) 
            {
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "A database with this name already exists.";
                server.Disconnect();
                return;
            }

            try
            {
                SqlDatabase newDatabase = server.Databases.Add(DatabaseNameTextBox.Text);
            }
            catch (Exception ex)
            {
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "There was an error creating the database.<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");
                success = false;
            }

            server.Disconnect();

            if (success)
                Response.Redirect("Tables.aspx?database=" + Server.UrlEncode(DatabaseNameTextBox.Text));
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
    }
}
