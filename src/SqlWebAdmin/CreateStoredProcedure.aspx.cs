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
    /// Summary description for CreateStoredProcedure.
    /// </summary>
    public partial class CreateStoredProcedure : System.Web.UI.Page
    {

        public CreateStoredProcedure()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ErrorCreatingLabel.Visible = false;
        }

        protected void CreateNewSProcButton_Click(object sender, System.EventArgs e)
        {
            if (SProcNameTextBox.Text.Length == 0) 
            {
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "The new stored procedure name cannot be blank";
                return;
            }

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            ErrorCreatingLabel.Visible = false;

            SqlStoredProcedure sproc = database.StoredProcedures[SProcNameTextBox.Text];

            // Ensure that SProc doesn't exist yet
            if (sproc == null) 
            {
                // Now we have to do a quick check and see if it's a valid name for a stored procedure
                // The only reliable way to do this is to try to create the stored procedure and see what happens

                // In order to find out whether the table name is valid, we create a temporary dummy table
                // and see what happens.
                SqlStoredProcedure dummySproc = null;

                try 
                {
                    dummySproc = database.StoredProcedures.Add(SProcNameTextBox.Text, "CREATE PROCEDURE [" + SProcNameTextBox.Text + "] AS\r\nGO");
                }
                catch (Exception ex) 
                {
                    // Disconnect and show error
                    if (dummySproc != null)
                        dummySproc.Remove();

                    server.Disconnect();
                    ErrorCreatingLabel.Visible = true;
                    ErrorCreatingLabel.Text = "There was an error creating the stored procedure:<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");
                    return;
                }

                // Delete the dummy stored procedure
                dummySproc.Remove();

                server.Disconnect();

                Response.Redirect(String.Format("EditStoredProcedure.aspx?database={0}&sproc={1}", Server.UrlEncode(database.Name), Server.UrlEncode(SProcNameTextBox.Text)));
            }
            else 
            {
                server.Disconnect();
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "A stored procedure with this name already exists.";
            }
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
