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
    /// Summary description for EditStoredProcedure.
    /// </summary>
    public partial class EditStoredProcedure : System.Web.UI.Page
    {

        public EditStoredProcedure()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            string sprocName = Request["sproc"];

            if (!IsPostBack)
            {
                // Check to see if SProc is new or it already exists

                server.Connect();
                
                SqlStoredProcedure sproc = database.StoredProcedures[sprocName];

                if (sproc == null)
                {
                    // SProc is new, create template
                    SProcNameLabel.Text = Server.HtmlEncode(sprocName);
                    SProcOwnerLabel.Text = "";
                    SProcCreateDateLabel.Text = "";

                    SProcTextTextbox.Text = String.Format("CREATE PROCEDURE [dbo].[{0}] AS", sprocName);
                }
                else
                {
                    // SProc already exists, load it from database
                    SProcNameLabel.Text = Server.HtmlEncode(sproc.Name);
                    SProcOwnerLabel.Text = Server.HtmlEncode(sproc.Owner);
                    SProcCreateDateLabel.Text = Server.HtmlEncode(Convert.ToString(sproc.CreateDate));

                    SProcTextTextbox.Text = sproc.Text;
                }

                server.Disconnect();
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

        protected void SaveButton_Click(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            string sprocName = Request["sproc"];

            bool success = true;

            Exception ex = null;

            try
            {
                // Check to see if SProc is new or it already exists
                SqlStoredProcedureCollection sprocs = database.StoredProcedures;
                SqlStoredProcedure sproc = sprocs[sprocName];

                if (sproc == null)
                {
                    // SProc is new, so create entirely new SProc (don't care about return value)
                    sprocs.Add(sprocName, SProcTextTextbox.Text);
                }
                else
                {
                    // SProc already exists, just update its text
                    sproc.Text = SProcTextTextbox.Text;
                }
            }
            catch (Exception ex2)
            {
                ex = ex2;
                success = false;
            }

            server.Disconnect();

            if (success)
            {
                // Redirect back to SProc page
                Response.Redirect("StoredProcedures.aspx?database=" + Server.UrlEncode(Request["database"]));
            }
            else
            {
                // show error
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "There was an error saving the stored procedure.<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");
            }
        }

        protected void CancelButton_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("StoredProcedures.aspx?database=" + Server.UrlEncode(Request["database"]));
        }
    }
}
