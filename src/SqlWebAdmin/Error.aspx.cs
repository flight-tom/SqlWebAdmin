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

namespace SqlWebAdmin
{
    /// <summary>
    /// Summary description for Error.
    /// </summary>
    public partial class Error : System.Web.UI.Page
    {


        private string ErrorLookup(int id) {
            switch (id) {
                case 1000:
                    return "Database does not exist";
                case 1001:
                    return "Stored procedure does not exist";
                case 1002:
                    return "Table does not exist";
                case 1003:
                    return "Column does not exist";
                default:
                    return "Unknown";
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // There are two kinds of errors - custom errors with numbers, and uncaught exceptions
            if (Request["error"] != null) {
				ErrorLabel.Text = String.Format("Error {0}: {1}", Server.HtmlEncode(Request["error"]), ErrorLookup(Convert.ToInt32(Request["error"])));
            }
            else {
                ErrorLabel.Text = "";

                Exception x = (Exception)Application["Error"];

                while (x != null) {
                    ErrorLabel.Text += x.Message.Replace("\n", "<br>") + "<br><br>" + x.StackTrace.Replace("\n", "<br>") + "<br><hr><br>";
                    x = x.InnerException;
                }

                Application.Remove("Error");
            }
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
    }
}
