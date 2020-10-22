namespace SqlWebAdmin
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
    ///     Summary description for ServerHeader.
    /// </summary>
    public partial  class ServerToolbar : System.Web.UI.UserControl
    {
        
        private string selected = "";

        public string Selected 
        {
            get 
            {
                return selected;
            }
            set 
            {
                selected = value.ToLower();
            }
        }

        public ServerToolbar()
        {
            this.Init += new System.EventHandler(Page_Init);
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Initialize links
			DatabasesHyperLink.NavigateUrl	 = "../databases.aspx";
			ImportHyperLink.NavigateUrl		 = "../import.aspx";
			ExportHyperLink.NavigateUrl		 = "../export.aspx";
			SecurityHyperLink.NavigateUrl	 = "../security.aspx";
						
            
			switch(selected) 
			{
				case "databases" :
					DatabasesTd.Attributes["class"] = "selectedLink";
					DatabasesHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "import" :
					ImportTd.Attributes["class"] = "selectedLink";
					ImportHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "export" :
					ExportTd.Attributes["class"] = "selectedLink";
					ExportHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "security" :
					SecurityTd.Attributes["class"] = "selectedLink";
					SecurityHyperLink.Attributes.Remove("onMouseOver");
					break;
										
			}

			Page.RegisterClientScriptBlock("Global_Script", "<script language=javascript src=Global.js></script>");
		}

        protected void Page_Init(object sender, EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
        }

        #region Web Form Designer generated code
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

				}
        #endregion
    }
}
