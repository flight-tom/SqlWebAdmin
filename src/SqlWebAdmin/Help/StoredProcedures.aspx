<%@ Page language="c#" Inherits="SqlWebAdmin.Help.StoredProcedures" CodeFile="StoredProcedures.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="STORED PROCEDURES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

The <b>Stored Procedures</b> page, available from the left-side navigation manu when editing a database, displays a list of stored procedures in the selected database.  When creating a new database, this page initially displays no procedures. You may create a new stored procedure by clicking the "Create new stored procedure" link at the top of the page.  
<br><br>
The list of stored procedures includes the following information:
<br><br>
<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Name</td>
		<td>The name of the stored procedure</td>
	</tr>
	<tr class=tableItems>
        <td>Owner</td>
		<td>The SQL Server role or SQL Server user that owns the stored procedure</td>
	</tr>
	<tr class=tableItems>
        <td>Type</td>
		<td>The type of the stored procedure (User | System)</td>
	</tr>
	<tr class=tableItems>
        <td>Create Date</td>
		<td>The date and time when the stored procedure was created</td>
	</tr>
</table>
<br>
You may choose to show only User stored procedures or both User and System stored procedures using the Filter dropdown at the top of this page.  You can also edit or delete a stored procedure from this page by clicking the appropriate links.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>