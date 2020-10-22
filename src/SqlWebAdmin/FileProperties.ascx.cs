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

    using SqlAdmin;

    /// <summary>
    ///     Summary description for FileProperties.
    /// </summary>
    public partial  class FileProperties : System.Web.UI.UserControl
    {


        public SqlAdmin.SqlFileProperties Properties
        {
            get
            {
                int growth = 0;
                int maximumFileSize = 0;

                try {
                    growth = Convert.ToInt32(GrowthTextBox.Text);
                }
                catch {
                    throw new Exception("Growth must be an integer");
                }

                try {
                    maximumFileSize = Convert.ToInt32(MaximumFileSizeTextBox.Text);
                }
                catch {
                    throw new Exception("Maximum file size must be an integer");
                }

                return new SqlFileProperties(
                    (GrowthTypeDropDownList.SelectedIndex == 0) ? SqlFileGrowthType.MB : SqlFileGrowthType.Percent,
                    AutomaticallyGrowFileCheckBox.Checked ? growth : 0,
                    UnrestrictedGrowthRadioButton.Checked ? -1 : maximumFileSize);
            }
            set 
            {
                SqlFileProperties props = value;
                if (props.FileGrowth == 0)
                    AutomaticallyGrowFileCheckBox.Checked = false;
                else
                    AutomaticallyGrowFileCheckBox.Checked = true;

                if (props.FileGrowthType == SqlFileGrowthType.MB)
                    GrowthTypeDropDownList.SelectedIndex = 0;
                else
                    GrowthTypeDropDownList.SelectedIndex = 1;

                GrowthTextBox.Text = props.FileGrowth.ToString();
                if (props.MaximumSize == -1) {
                    UnrestrictedGrowthRadioButton.Checked = true;
                    RestrictGrowthRadioButton.Checked = false;
                }
                else {
                    UnrestrictedGrowthRadioButton.Checked = false;
                    RestrictGrowthRadioButton.Checked = true;
                }

                MaximumFileSizeTextBox.Text = props.MaximumSize.ToString();
            }
        }


        public FileProperties()
        {
            this.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
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
