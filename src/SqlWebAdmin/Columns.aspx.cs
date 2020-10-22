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
    public partial class edittable : System.Web.UI.Page
    {



        public edittable()
        {
            Page.Init += new System.EventHandler(Page_Init);
           
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

            SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlTable table = database.Tables[Request["table"]];

            // Set link for add new column
            AddNewColumnHyperLink.NavigateUrl = String.Format("editcolumn.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), Server.UrlEncode(Request["table"]));


            if (table != null) {
                // The table exists and we do normal column editing

                ColumnsDataGrid.Visible = true;
                NoColumnsLabel.Visible = false;

                if (!IsPostBack) {
                    // Update table properties

                    // Get columns list
                    SqlColumnCollection columns = table.Columns;

                    DataSet ds = new DataSet();
                    ds.Tables.Add();
                    ds.Tables[0].Columns.Add("key", typeof(bool));
                    ds.Tables[0].Columns.Add("id", typeof(bool));
                    ds.Tables[0].Columns.Add("name", typeof(string));
                    ds.Tables[0].Columns.Add("datatype", typeof(string));
                    ds.Tables[0].Columns.Add("size", typeof(int));
                    ds.Tables[0].Columns.Add("precision", typeof(int));
                    ds.Tables[0].Columns.Add("scale", typeof(int));
                    ds.Tables[0].Columns.Add("nulls", typeof(bool));
                    ds.Tables[0].Columns.Add("default", typeof(string));

                    ds.Tables[0].Columns.Add("encodedname", typeof(string));

                    for (int i = 0; i < columns.Count; i++) {
                        SqlColumnInformation columnInfo = columns[i].ColumnInformation;
                        ds.Tables[0].Rows.Add(new object[] {columnInfo.Key, columnInfo.Identity, Server.HtmlEncode(columnInfo.Name), Server.HtmlEncode(columnInfo.DataType), columnInfo.Size, columnInfo.Precision, columnInfo.Scale, columnInfo.Nulls, Server.HtmlEncode(columnInfo.DefaultValue), Server.UrlEncode(columnInfo.Name)});
                    }
                    ColumnsDataGrid.DataSource = ds;
                    ColumnsDataGrid.DataBind();
                }

                // If the table has data in it, disable edit column
				if (table.Rows > 0) {
					ColumnsDataGrid.Columns[2].Visible = true;
					ColumnsDataGrid.Columns[3].Visible = false;
					ColumnsDataGrid.Columns[8].Visible = false;
				}
				else {
					ColumnsDataGrid.Columns[2].Visible = false;
					ColumnsDataGrid.Columns[3].Visible = true;
					ColumnsDataGrid.Columns[8].Visible = true;
				}

                // If the table has only one column, do not allow delete
                if (table.Columns.Count == 1)
                    ColumnsDataGrid.Columns[9].Visible = false;
                else
                    ColumnsDataGrid.Columns[9].Visible = true;
            }
            else {
                // The table does not exist, implying that it is new

                ColumnsDataGrid.Visible = false;
                NoColumnsLabel.Visible = true;
            }

            server.Disconnect();
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
