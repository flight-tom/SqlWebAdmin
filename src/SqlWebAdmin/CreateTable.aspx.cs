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
    /// Summary description for CreateTable.
    /// </summary>
    public partial class CreateTable : System.Web.UI.Page
    {
    
        public CreateTable()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ErrorCreatingLabel.Visible = false;
        }

        protected void CreateNewTableButton_Click(object sender, System.EventArgs e)
        {
            if (TableNameTextBox.Text.Length == 0) 
            {
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "The new table name cannot be blank";
                return;
            }

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            ErrorCreatingLabel.Visible = false;

            SqlTable table = server.Databases[database.Name].Tables[TableNameTextBox.Text];

            // Ensure that the table doesn't exist yet
            if (table == null) 
            {
                // Now we have to do a quick check and see if it's a valid name for a table
                // The only reliable way to do this is to try to create the table and see what happens

                // In order to find out whether the table name is valid, we create a temporary dummy table
                // and see what happens.
                SqlTable dummyTable = null;

                try 
                {
                    dummyTable = database.Tables.Add(TableNameTextBox.Text, new SqlColumnInformation[] {new SqlColumnInformation("Column1")});
                }
                catch (Exception ex) 
                {
                    // Disconnect and show error
                    if (dummyTable != null)
                        dummyTable.Remove();

                    server.Disconnect();
                    ErrorCreatingLabel.Visible = true;
                    ErrorCreatingLabel.Text = "There was an error creating the table:<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");
                    return;
                }

                // Delete the dummy table
                dummyTable.Remove();


                server.Disconnect();
                Response.Redirect(String.Format("editcolumn.aspx?database={0}&table={1}", Server.UrlEncode(database.Name), Server.UrlEncode(TableNameTextBox.Text)));
            }
            else 
            {
                server.Disconnect();
                ErrorCreatingLabel.Visible = true;
                ErrorCreatingLabel.Text = "A table with this name already exists.";
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
