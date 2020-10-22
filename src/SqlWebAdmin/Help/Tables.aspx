<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Tables" CodeFile="Tables.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="TABLES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

Choosing to edit a database from the <b>Databases</b> page directs you to the <b>Tables</b> page, which displays a list of tables in the selected database.  When creating a new database, this page initially displays no tables. You may create a new table by clicking the "Create new table" link at the top of the page.  
<br><br>
The list of tables includes the following information:
<br><br>
<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Name</td>
		<td>The name of the table</td>
	</tr>
	<tr class=tableItems>
        <td>Owner</td>
		<td>The SQL Server role or SQL Server user that owns the table</td>
	</tr>
	<tr class=tableItems>
        <td>Type</td>
		<td>The type of the table (User | System)</td>
	</tr>
	<tr class=tableItems>
        <td>Create Date</td>
		<td>The date and time when the table was created</td>
	</tr>
	<tr class=tableItems>
        <td>Rows</td>
		<td>The number of data rows in the table</td>
	</tr>
</table>
<br>
You may choose to show only User tables or both User and System tables using the Filter dropdown at the top of this page.  You can also edit, query, or delete a table from this page by clicking the appropriate links.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
