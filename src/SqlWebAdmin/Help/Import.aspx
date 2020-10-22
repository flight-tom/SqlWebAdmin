<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Import" CodeFile="Import.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="IMPORTING DATABASES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

The <b>Import Database</b> page allows you to re-create objects on the server using a previously generated export file.  Enter the path to a .sql export file in the textbox and click the "Import" button to proceed.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>