<%@ Page language="c#" Inherits="SqlWebAdmin.Help.RenameTable" CodeFile="RenameTable.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="RENAMING TABLES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

To rename a table, click the "rename" link on the <b>Tables</b> page.   When prompted, type the new name for the table and click the "Rename" button.  You may click "Cancel" to abort this operation instead.
<br><br>
Caution:  Think carefully before you rename a table.  If existing queries, views, user-defined functions, stored procedures, or programs refer to that table, the name modification will make these objects invalid.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
