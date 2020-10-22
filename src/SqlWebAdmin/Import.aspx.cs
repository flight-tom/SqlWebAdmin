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
using System.IO;
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
    /// Summary description for ImportExport.
    /// </summary>
    public partial class Import : System.Web.UI.Page
    {




        protected void Page_Load(object sender, System.EventArgs e)
        {
            ImportErrorLabel.Visible = false;
            ImportSuccessLabel.Visible = false;
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    
        }
        #endregion


        protected void ImportButton_Click(object sender, System.EventArgs e) {
			SqlServer server = SqlServer.CurrentServer;
			
            // Grab file from post data
            HttpPostedFile file = FileUploadInput.PostedFile;

            int length = file.ContentLength;

            byte[] buff = new byte[length];
            file.InputStream.Read(buff, 0, length);

            // Convert from byte array to string
            StringBuilder qsb = new StringBuilder();
            for (int i = 0; i < length; i++)
                qsb.Append(Convert.ToChar(buff[i]));

            string q = qsb.ToString();

            if (q.Trim().Length == 0) {
                ImportErrorLabel.Visible = true;
                ImportErrorLabel.Text = "Imported file contains no data.";
                return;
            }

            try {
                // No need for connect/disconnect since Query() uses ADO.NET, not DMO
                server.Query(q);
                ImportSuccessLabel.Visible = true;
            }
            catch (SqlException ex) {
                ImportErrorLabel.Visible = true;
                ImportErrorLabel.Text = "There was an error importing the database. The status of the import is unknown.<br><br>" +
                    Server.HtmlEncode(ex.Message).Replace("\n", "<br>");
            }
        }
    }
}
