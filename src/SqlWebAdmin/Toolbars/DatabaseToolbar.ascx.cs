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
	///     Summary description for DatabaseHeader.
	/// </summary>
	public partial  class DatabaseToolbar : System.Web.UI.UserControl
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

		/// <summary>
		public DatabaseToolbar()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			SqlServer server = SqlServer.CurrentServer;
			server.Connect();

			string databaseName = SqlDatabase.CurrentDatabase(server).Name;

			server.Disconnect();

			// Initialize links
			QueryHyperLink.NavigateUrl              = "../QueryDatabase.aspx?database=" + databaseName;
			TablesHyperLink.NavigateUrl             = "../Tables.aspx?database=" + databaseName;
			PropertiesHyperLink.NavigateUrl         = "../DatabaseProperties.aspx?database=" + databaseName;
			StoredProceduresHyperLink.NavigateUrl   = "../StoredProcedures.aspx?database=" + databaseName;
			UsersHyperLink.NavigateUrl				= "../DatabaseUsers.aspx?database=" + databaseName;
			RolesHyperLink.NavigateUrl				= "../DatabaseRoles.aspx?database=" + databaseName;

			switch(selected) 
			{
				case "tables" :
					TablesTd.Attributes["class"] = "selectedLink";
					TablesHyperLink.Attributes.Remove("onMouseOver");

					break;
				case "query" :
					QueryTd.Attributes["class"] = "selectedLink";
					QueryHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "properties" :
					PropertiesTd.Attributes["class"] = "selectedLink";
					PropertiesHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "storedprocedures" :
					StoredProceduresTd.Attributes["class"] = "selectedLink";
					StoredProceduresHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "users" :
					UsersTd.Attributes["class"] = "selectedLink";
					UsersHyperLink.Attributes.Remove("onMouseOver");
					break;
				case "roles" :
					RolesTd.Attributes["class"] = "selectedLink";
					RolesHyperLink.Attributes.Remove("onMouseOver");
					break;


			}
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
