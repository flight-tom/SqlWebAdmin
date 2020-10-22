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
    /// Summary description for StoredProcedures.
    /// </summary>
    public partial class StoredProcedures : System.Web.UI.Page
    {

        public StoredProcedures()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            FilterSProcsButton_Click(null, null);
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

        protected void FilterSProcsButton_Click(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            string databaseName = database.Name;

            SqlObjectType objectTypeFilter;
            switch (SProcTypeDropDownList.SelectedIndex)
            {
                case 0:
                    objectTypeFilter = SqlObjectType.User;
                    break;
                case 1:
                    objectTypeFilter = SqlObjectType.User | SqlObjectType.System;
                    break;
                default:
                    throw new Exception("Invalid SProcType selected");
            }

            // Get stored procedure list
            AddNewSProcHyperLink.NavigateUrl = String.Format("createstoredprocedure.aspx?database={0}", Server.UrlEncode(Request["database"]));

            SqlStoredProcedureCollection sprocs = database.StoredProcedures;
            
			server.Disconnect();

            // Create DataSet from result
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("name");
            ds.Tables[0].Columns.Add("encodedname");
            ds.Tables[0].Columns.Add("owner");
            ds.Tables[0].Columns.Add("type");
            ds.Tables[0].Columns.Add("createdate");
            for (int i = 0; i < sprocs.Count; i++) {
                SqlStoredProcedure sproc = sprocs[i];

                // Only add objects that we want (system or user)
                if ((sproc.StoredProcedureType & objectTypeFilter) > 0)
                    ds.Tables[0].Rows.Add(new object[] {Server.HtmlEncode(sproc.Name), Server.UrlEncode(sproc.Name), Server.HtmlEncode(sproc.Owner), Server.HtmlEncode(sproc.StoredProcedureType.ToString()), Server.HtmlEncode(sproc.CreateDate.ToString())});
            }

            // Show message if there are no tables, otherwise show datagrid
            if (ds.Tables[0].Rows.Count == 0) {
                SProcsDataGrid.Visible = false;
                SProcTypeErrorLabel.Visible = true;
            }
            else {
                SProcTypeErrorLabel.Visible = false;
                SProcsDataGrid.Visible = true;

                SProcsDataGrid.DataSource = ds;
                SProcsDataGrid.DataBind();
            }
        }
    }
}
