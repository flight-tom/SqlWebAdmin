<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Databases" CodeFile="Databases.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="DATABASES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

The <b>Databases</b> page displays the list of available databases (and their sizes, in megabytes) for the currently logged in user.  If the user does not have permission to view or edit a database, it will not be displayed.  From this screen you can create, edit, query, or delete a database by clicking the links on this page.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>