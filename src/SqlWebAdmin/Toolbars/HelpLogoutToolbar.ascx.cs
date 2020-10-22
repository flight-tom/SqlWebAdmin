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

    /// <summary>
    ///     Summary description for HelpLogoutToolbar.
    /// </summary>
    public partial  class HelpLogoutToolbar : System.Web.UI.UserControl
    {

        private string helpTopic = "";

        public string HelpTopic 
        {
            get 
            {
                return helpTopic;
            }
            set 
            {
                helpTopic = value;
            }
        }


        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            HelpImageHyperLink.NavigateUrl      = "../Help/" + helpTopic + ".aspx";
            LogoutImageHyperLink.NavigateUrl    = "../Logout.aspx";
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
