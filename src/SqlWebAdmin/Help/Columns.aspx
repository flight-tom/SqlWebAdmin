<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Columns" CodeFile="Columns.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="COLUMNS" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

Choosing to edit a table from the <b>Tables</b> page directs you to the <b>Columns</b> page, which displays a list of columns in the selected table.  You may create a new column by clicking the "Create new column" link at the top of the page.  
<br><br>
The list of columns displays the following information:
<br><br>
<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Key</td>
		<td>Indicates that the column is the primary key in the table</td>
	</tr>
	<tr class=tableItems>
        <td>ID</td>
		<td>Indicates that the column is an auto-incrementing identifier</td>
	</tr>
	<tr class=tableItems>
        <td>Name</td>
		<td>The name of the column</td>
	</tr>
	<tr class=tableItems>
        <td>Data Type</td>
		<td>The data type for the column</td>
	</tr>
	<tr class=tableItems>
        <td>Size</td>
		<td>The size (in bytes) of the column</td>
	</tr>
	<tr class=tableItems>
        <td>Nulls</td>
		<td>Indicates that the column allows null values</td>
	</tr>
	<tr class=tableItems>
        <td>Default</td>
		<td>The default value for the column</td>
	</tr>
</table>
<br>
You can also edit or delete a column from this page by clicking the appropriate links.  Note that columns are only editable if the table itself contains no data.  That is, you can redesign an existing table only if it is empty.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
