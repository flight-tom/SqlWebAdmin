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
using System.Data.SqlClient;
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
    /// <summary>
    /// Summary description for query.
    /// </summary>
    public partial class query : System.Web.UI.Page
    {




        public query()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ResultsPanel.Visible = false;
            ErrorLabel.Visible = false;
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

        protected void SaveButton_Click(object sender, System.EventArgs e) {
            // Dump out special header and the file content and end the response
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();

            // This header (RFC 1806) lets us set the suggested filename
            Response.AddHeader("Content-Disposition", "attachment; filename=query.sql");
            Response.Write(QueryTextbox.Text);
            Response.End();
        }

        protected void LoadButton_Click(object sender, System.EventArgs e) {
            // Grab file from post data
            HttpPostedFile file = FileUploadInput.PostedFile;

            int length = file.ContentLength;

            byte[] buff = new byte[length];
            file.InputStream.Read(buff, 0, length);

            // Convert from byte array to string
            StringBuilder qsb = new StringBuilder();
            for (int i = 0; i < length; i++)
                qsb.Append(Convert.ToChar(buff[i]));

            QueryTextbox.Text = qsb.ToString();
        }

        protected void ExecuteButton_Click(object sender, System.EventArgs e)
        {
            if (QueryTextbox.Text.Trim().Length == 0) {
                ResultsPanel.Visible = false;
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "You must enter a non-empty query";
                return;
            }

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

			DataTable[] tables = null;

			try
            {
                tables = database.Query(QueryTextbox.Text);
            }
            catch (SqlException ex)
            {
                // Print error message
                ResultsPanel.Visible = false;
                ErrorLabel.Visible = true;
                ErrorLabel.Text =
                    "The following error occured while executing the query:<br>\n" +
                    String.Format("Server: Msg {0}, Level {1}, State {2}, Line {3}<br>\n", new object[] {ex.Number, ex.Class, ex.State, ex.LineNumber}) +
                    Server.HtmlEncode(ex.Message).Replace("\n", "<br>") + "<br>\n";
            }

            server.Disconnect();


            // Print output tables, if they exist
            if (tables != null)
            {
                // Add header text "Results:"
                Label label = new Label();
                label.Text = "<br><br>";
                ResultsPanel.Controls.Add(label);

                // Loop through all the tables in the DataSet
                for (int i = 0; i < tables.Length; i++)
                {
                    // Only print divider after first table
                    if (i > 0) {
                        // Create new label for grid divider
                        label = new Label();
                        label.Text = "<br><br><hr><br><br>";
                        ResultsPanel.Controls.Add(label);
                    }

                    DataGrid dataGrid = new DataGrid();
                    dataGrid.HeaderStyle.CssClass = "tableHeader";
                    dataGrid.ItemStyle.CssClass = "tableItems";
                    dataGrid.ItemStyle.Wrap = false;
                    dataGrid.Width=Unit.Percentage(100);
                    dataGrid.EnableViewState = false;

                    dataGrid.PreRender += new EventHandler(DataGrid_PreRender);

                    dataGrid.DataSource = tables[i];
                    dataGrid.DataBind();

                    ResultsPanel.Controls.Add(dataGrid);
                }

                ResultsPanel.Visible = true;
                ErrorLabel.Visible = false;
            }
        }

        private void DataGrid_PreRender(object sender, EventArgs e) {
            // Set the wrapping style of all the cells based on the checkbox, and HTML encode all the cell contents

            DataGrid d = (DataGrid)sender;

            foreach (DataGridItem item in d.Items) {
                foreach (TableCell t in item.Cells) {
                    t.Wrap = WrapCheckBox.Checked;
                    t.Text = Server.HtmlEncode(t.Text);
                }
            }
        }
    }
}
