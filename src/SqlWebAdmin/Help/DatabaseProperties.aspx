<%@ Page language="c#" Inherits="SqlWebAdmin.Help.DatabaseProperties" CodeFile="DatabaseProperties.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="DATABASE PROPERTIES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

The properties of a database are displayed on the <b>Properties</b> page, available from the left-side navigation menu.  Several read-only properties are displayed:
<br><br>

<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Name</td>
		<td>The name of the database</td>
	</tr>
    <tr class=tableItems>
        <td>Status</td>
		<td>The status of the database</td>
	</tr>
    <tr class=tableItems>
        <td>Owner</td>
		<td>The SQL Server role or SQL Server user that owns the database</td>
	</tr>
    <tr class=tableItems>
        <td>Date created</td>
		<td>The date and time when the database was created</td>
	</tr>
    <tr class=tableItems>
        <td>Size</td>
		<td>The size (in megabytes) of the database file</td>
	</tr>
    <tr class=tableItems>
        <td>Space available</td>
		<td>The space available in the database file</td>
	</tr>
    <tr class=tableItems>
        <td>Number of users</td>
		<td>The number of users in the database</td>
	</tr>
</table>
<br>
You can also specify the expansion space allocated for the backend database file and transaction log associated with the selected database.  The file name, location, and filegroup are chosen for you by the Web Data Administrator.  The "Automatically grow file" option specifies that data files automatically increase in size by the amount indicated in the following options. 
<br><br>

<div style="padding:0,0,0,20">
<b>In megabytes </b><br>
Specify the number of megabytes by which to grow the data files.
<br><br>
<b>By percent</b><br>
Specify the percentage by which you want the data files to grow automatically.
<br><br>
<b>Unrestricted file growth</b><br> 
Specify that the data file growth will be unrestricted.
<br><br>
<b>Restrict file growth (MB)</b><br> 
Specify the size in megabytes to which a restricted data file can grow. 
</div>
<br>
When "Automatically grow file" is not selected, the database file or transaction log will not grow automatically and will remain a fixed sized (see read-only properties above).
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
