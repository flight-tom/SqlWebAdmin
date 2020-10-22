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
    /// Summary description for DatabaseProperties.
    /// </summary>
    public partial class DatabaseProperties : System.Web.UI.Page
    {




    
        public DatabaseProperties()
        {
            Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlDatabaseProperties props = database.GetDatabaseProperties();

            server.Disconnect();

            NamePropertyLabel.Text = Server.HtmlEncode(props.Name);
            StatusPropertyLabel.Text = Server.HtmlEncode(props.Status);
            OwnerPropertyLabel.Text = Server.HtmlEncode(props.Owner);
            DateCreatedPropertyLabel.Text = Server.HtmlEncode(Convert.ToString(props.DateCreated));
            SizePropertyLabel.Text = props.Size.ToString("f2");
            SpaceAvailablePropertyLabel.Text = props.SpaceAvailable.ToString("f2");
            NumberOfUsersPropertyLabel.Text = Convert.ToString(props.NumberOfUsers);

            // On first load of the page, force data gathering...
            if (!IsPostBack)
                CancelButton_Click(null, null);
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

        protected void CancelButton_Click(object sender, System.EventArgs e)
        {
            ErrorLabel.Visible = false;

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlDatabaseProperties props = database.GetDatabaseProperties();

            server.Disconnect();

            DataFileProperties.Properties = props.DataFile;
            LogFileProperties.Properties = props.LogFile;
        }

        protected void ApplyButton_Click(object sender, System.EventArgs e)
        {
            ErrorLabel.Visible = false;

			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            // Grab data from the form
            SqlDatabaseProperties props = null;

            SqlFileProperties dataFileProperties = null;
            SqlFileProperties logFileProperties = null;

            try {
                dataFileProperties = DataFileProperties.Properties;
            }
            catch (Exception ex) {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Error reading data file properties: " + Server.HtmlEncode(ex.Message).Replace("\n", "<br>") + "<br><br>";
                return;
            }

            try {
                logFileProperties = LogFileProperties.Properties;
            }
            catch (Exception ex) {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Error reading log file properties: " + Server.HtmlEncode(ex.Message).Replace("\n", "<br>") + "<br><br>";
                return;
            }

            props = new SqlDatabaseProperties(dataFileProperties, logFileProperties);
			SqlDatabaseProperties origProps = database.GetDatabaseProperties();

            // First validate input ourselves
            ArrayList errorList = new ArrayList();

            if (props.DataFile.FileGrowth < 0)
                errorList.Add("Data file growth must be positive");

            if (props.DataFile.MaximumSize < -1)
                errorList.Add("Data file maximum size must be positive");

            if (props.LogFile.FileGrowth < 0)
                errorList.Add("Log file growth must be positive");

            if (props.LogFile.MaximumSize < -1)
                errorList.Add("Log file maximum size must be positive");

			if (props.DataFile.MaximumSize != -1 && origProps.Size > props.DataFile.MaximumSize) 
				errorList.Add("Maximum file growth must be greater than or equal to the current database size");

            if (errorList.Count > 0) {
                ErrorLabel.Visible = true;

                ErrorLabel.Text = "The following error(s) occured:<br><ul>";
                for (int i = 0; i < errorList.Count; i++)
                    ErrorLabel.Text += String.Format("<li>{0}</li>", (string)errorList[i]);
                ErrorLabel.Text += "</ul>";

                return;
            }

            // Try to set properties
            try {
                database.SetDatabaseProperties(props);
            }
            catch (Exception ex) {
                // Show error message and quit
                server.Disconnect();

                ErrorLabel.Text = "The following error occured:<br>" + Server.HtmlEncode(ex.Message).Replace("\n", "<br>") + "<br><br>";
                return;
            }


            // Only reload data if there were no errors
            // Get database properties and fill in their info
            props = database.GetDatabaseProperties();

            DataFileProperties.Properties = props.DataFile;
            LogFileProperties.Properties = props.LogFile;

            server.Disconnect();
        }
    }
}
