namespace SqlWebAdmin.Toolbars
{
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
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

	using SqlAdmin;

    /// <summary>
    ///     Summary description for DatabaseLocation.
    /// </summary>
    public partial  class DatabaseLocation : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
					SqlServer server = SqlServer.CurrentServer;
					server.Connect();

          string databaseName = SqlDatabase.CurrentDatabase(server).Name;

					server.Disconnect();

          DatabaseNameHyperLink.NavigateUrl = "../Tables.aspx?database=" + Server.UrlEncode(databaseName);
          DatabaseNameHyperLink.Text = Server.HtmlEncode(databaseName);
        
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
        
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}
