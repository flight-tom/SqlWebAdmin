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
    /// Summary description for EditColumn.
    /// </summary>
    public partial class EditColumn : System.Web.UI.Page
    {




        public EditColumn()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }


        protected void Page_Load(object sender, System.EventArgs e)
        {

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            if (!IsPostBack) {
                DataLossWarningLabel.Visible = false;

                // If column isn't specified in request, that means we're adding a new column, not editing an existing one
                if (Request["column"] == null || Request["column"].Length == 0) {
                    // Set update button text to "Add" instead of "Update"
                    UpdateButton.Text = "Add";

                    // Create new unique column name
                    string columnName = "";

                    SqlTable table = database.Tables[Request["table"]];
                    if (table == null) {
                        // If table doesn't exist (e.g. new table), set default column name
                        columnName = "Column1";
                    }
                    else {
                        // Come up with non-existent name ColumnXX
                        int i = 1;
                        do {
                            columnName = "Column" + i;
                            i++;
                        } while (table.Columns[columnName] != null);
                    }


                    // Initialize column editor with default values
                    PrimaryKeyCheckbox.Checked          = false;
                    ColumnNameTextbox.Text              = columnName;
                    DataTypeDropdownlist.SelectedIndex  = DataTypeDropdownlist.Items.IndexOf(new ListItem("char"));
                    LengthTextbox.Text                  = "10";
                    AllowNullCheckbox.Checked           = true;
                    DefaultValueTextbox.Text            = "";
                    PrecisionTextbox.Text               = "0";
                    ScaleTextbox.Text                   = "0";
                    IdentityCheckBox.Checked            = false;
                    IdentitySeedTextbox.Text            = "1";
                    IdentityIncrementTextbox.Text       = "1";
                    IsRowGuidCheckBox.Checked           = false;
                }
                else {
                    // Set update button text to "Update" instead of "Add"
                    UpdateButton.Text = "Update";

                    // Load column from table
                    SqlTable table = database.Tables[Request["table"]];
                    if (table == null) {
                        server.Disconnect();

                        // Table doesn't exist - break out and go to error page
                        Response.Redirect(String.Format("error.aspx?error={0}", 1002));
                        return;
                    }


                    // Select column from table
                    SqlColumn column = table.Columns[Request["column"]];
                    if (column == null) {
                        server.Disconnect();

                        // Column doesn't exist - break out and go to error page
                        Response.Redirect(String.Format("error.aspx?error={0}", 1003));
                        return;
                    }

                    SqlColumnInformation columnInfo = column.ColumnInformation;

                    // Initialize column editor
                    PrimaryKeyCheckbox.Checked          = columnInfo.Key;
                    ColumnNameTextbox.Text              = columnInfo.Name;
                    DataTypeDropdownlist.SelectedIndex  = DataTypeDropdownlist.Items.IndexOf(new ListItem(columnInfo.DataType));
                    LengthTextbox.Text                  = Convert.ToString(columnInfo.Size);
                    AllowNullCheckbox.Checked           = columnInfo.Nulls;
                    DefaultValueTextbox.Text            = columnInfo.DefaultValue;
                    PrecisionTextbox.Text               = Convert.ToString(columnInfo.Precision);
                    ScaleTextbox.Text                   = Convert.ToString(columnInfo.Scale);
                    IdentityCheckBox.Checked            = columnInfo.Identity;
                    IdentitySeedTextbox.Text            = Convert.ToString(columnInfo.IdentitySeed);
                    IdentityIncrementTextbox.Text       = Convert.ToString(columnInfo.IdentityIncrement);
                    IsRowGuidCheckBox.Checked           = columnInfo.IsRowGuid;

                    // Since we are editing an existing column, the table will be recreated,
                    // so we must warn about data loss
                    DataLossWarningLabel.Visible = true;
                }
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

        protected void UpdateButton_Click(object sender, System.EventArgs e) {
            if (!IsValid)
                return;

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            // Parse user input and stick it into ColumnInfo
            SqlColumnInformation columnInfo = new SqlColumnInformation();
            columnInfo.Key                  = PrimaryKeyCheckbox.Checked;
            columnInfo.Name                 = ColumnNameTextbox.Text;
            columnInfo.DataType             = DataTypeDropdownlist.SelectedItem.Text;

            try {
                columnInfo.Size                 = Convert.ToInt32(LengthTextbox.Text);
            }
            catch {
                // Show error and quit
                ErrorUpdatingColumnLabel.Visible = true;
                ErrorUpdatingColumnLabel.Text = "Invalid input: Size must be an integer";
                return;
            }

            columnInfo.Nulls                = AllowNullCheckbox.Checked;
            columnInfo.DefaultValue         = DefaultValueTextbox.Text;

            try {
                columnInfo.Precision            = Convert.ToInt32(PrecisionTextbox.Text);
            }
            catch {
                // Show error and quit
                ErrorUpdatingColumnLabel.Visible = true;
                ErrorUpdatingColumnLabel.Text = "Invalid input: Precision must be an integer";
                return;
            }

            try {
                columnInfo.Scale                = Convert.ToInt32(ScaleTextbox.Text);
            }
            catch {
                // Show error and quit
                ErrorUpdatingColumnLabel.Visible = true;
                ErrorUpdatingColumnLabel.Text = "Invalid input: Scale must be an integer";
                return;
            }

            columnInfo.Identity             = IdentityCheckBox.Checked;

            try {
                columnInfo.IdentitySeed         = Convert.ToInt32(IdentitySeedTextbox.Text);
            }
            catch {
                // Show error and quit
                ErrorUpdatingColumnLabel.Visible = true;
                ErrorUpdatingColumnLabel.Text = "Invalid input: Identity seed must be an integer";
                return;
            }

            try {
                columnInfo.IdentityIncrement    = Convert.ToInt32(IdentityIncrementTextbox.Text);
            }
            catch {
                // Show error and quit
                ErrorUpdatingColumnLabel.Visible = true;
                ErrorUpdatingColumnLabel.Text = "Invalid input: Identity increment must be an integer";
                return;
            }

            columnInfo.IsRowGuid            = IsRowGuidCheckBox.Checked;

            SqlTable table = database.Tables[Request["table"]];

            // First check if the table exists or not
            // If it doesn't exist, that means we are adding the first column of a new table
            // If it does exist, then either we are adding a new column to an existing table
            //   or we are editing an existing column in an existing table

            if (table == null) {
                // Table does not exist - create a new table and add the new column
                try {
                    SqlColumnInformation[] columnInfos = new SqlColumnInformation[1] { columnInfo };
                    table = database.Tables.Add(Request["table"], columnInfos);
                }
                catch (Exception ex) {
                    // If the table was somehow created, get rid of it
                    table = database.Tables[Request["table"]];
                    if (table != null)
                        table.Remove();

                    // Show error and quit
                    ErrorUpdatingColumnLabel.Visible = true;
                    ErrorUpdatingColumnLabel.Text = "The following error occured while trying to apply the changes.<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");

                    server.Disconnect();
                    return;
                }
            }
            else {
                // Table does exist, do further check

                // If original name is blank that means it is a new column
                string originalColumnName = Request["column"];

                if (originalColumnName == null || originalColumnName.Length == 0) {
                    try {
                        table.Columns.Add(columnInfo);
                    }
                    catch (Exception ex) {
                        // Show error and quit
                        ErrorUpdatingColumnLabel.Visible = true;
                        ErrorUpdatingColumnLabel.Text = "The following error occured while trying to apply the changes:<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");

                        server.Disconnect();
                        return;
                    }
                }
                else {
                    // If we get here that means we are editing an existing column

                    // Simply set the column info - internally the table gets recreated
                    try {
                        table.Columns[originalColumnName].ColumnInformation = columnInfo;
                    }
                    catch (Exception ex) {
                        // Show error and quit
                        ErrorUpdatingColumnLabel.Visible = true;
                        ErrorUpdatingColumnLabel.Text = "The following error occured while trying to apply the changes.<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>");

                        server.Disconnect();
                        return;
                    }
                }
            }

            server.Disconnect();

            // If we get here then that means a column was successfully added/edited
            Response.Redirect(String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), Server.UrlEncode(Request["table"])));
        }

        protected void CancelButton_Click(object sender, System.EventArgs e) {
            // Just redirect back to columns list
            Response.Redirect(String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), Server.UrlEncode(Request["table"])));
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

