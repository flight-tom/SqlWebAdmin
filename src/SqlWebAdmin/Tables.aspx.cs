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
    /// Summary description for Tables.
    /// </summary>
    public partial class Tables : System.Web.UI.Page
    {

        public Tables()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            FilterTablesButton_Click(null, null);
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

        private void FilterTablesButton_Click(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlObjectType objectTypeFilter;
            switch (TableTypeDropDownList.SelectedIndex)
            {
                case 0:
                    objectTypeFilter = SqlObjectType.User;
                    break;
                case 1:
                    objectTypeFilter = SqlObjectType.User | SqlObjectType.System;
                    break;
                default:
                    throw new Exception("Invalid TableType selected");
            }

            // Get table list
            AddNewTableHyperLink.NavigateUrl = String.Format("createtable.aspx?database={0}", Server.UrlEncode(Request["database"]));

            SqlTableCollection tables = database.Tables;

            // Create DataSet from result
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("name");
            ds.Tables[0].Columns.Add("encodedname");
            ds.Tables[0].Columns.Add("owner");
            ds.Tables[0].Columns.Add("type");
            ds.Tables[0].Columns.Add("createdate");
            ds.Tables[0].Columns.Add("rows");
            for (int i = 0; i < tables.Count; i++) {
                SqlTable table = tables[i];

                // Only add objects that we want (system or user)
                if ((table.TableType & objectTypeFilter) > 0)
                    ds.Tables[0].Rows.Add(new object[] {Server.HtmlEncode(table.Name), Server.UrlEncode(table.Name), Server.HtmlEncode(table.Owner), Server.HtmlEncode(table.TableType.ToString()), Server.HtmlEncode(table.CreateDate.ToString()), table.Rows});
            }

            // Show message if there are no tables, otherwise show datagrid
            if (ds.Tables[0].Rows.Count == 0) {
                TablesDataGrid.Visible = false;
                TableTypeErrorLabel.Visible = true;
            }
            else {
                TableTypeErrorLabel.Visible = false;
                TablesDataGrid.Visible = true;

                TablesDataGrid.DataSource = ds;
                TablesDataGrid.DataBind();
            }

            server.Disconnect();
        }
    }
}
