<%@ Page language="c#" Inherits="SqlWebAdmin.Help.EditColumn" CodeFile="EditColumn.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="EDITING COLUMNS" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

The <b>Edit Column</b> page lists a set of properties for a column within a table.  You may set each property when creating or altering a column.  Note that a column can only be edited if no data exists in the table.
<br><br>
<div style="padding:0,0,0,20">
<b>Primary Key</b><br>
Determines whether the column is the primary key field for the selected table.
<br><br>
<b>Column Name</b><br>
The name of the column.
<br><br>
<b>Data Type</b><br>
The data type for the column.
<br><br>
<b>Length</b><br>
The length in bytes of the data type.
<br><br>
<b>Allow Null</b><br>
Determines whether the column allows null values.
<br><br>
<b>Default Value</b><br>
The default for this column whenever a row with a null value for this column is inserted into the table.  To create a default constraint for the column, enter the default value directly as text.  Note: varchar, text, and character values should be surrounded in single quotes (for example, 'my default').  Surrounding parentheses are optional.
<br><br>
<b>Precision</b><br>
The maximum number of digits for values of this column.
<br><br>
<b>Scale</b><br>
The maximum number of digits that can appear to the right of the decimal point for values of this column.
<br><br>
<b>Identity</b><br>
Determines whether the column is used by SQL Server as an identifier column.  A table can have only one column defined as an Identity, and that column must be defined using the decimal, int, numeric, smallint, bigint, or tinyint data type.
<br><br>
<b>Identity Seed</b><br>
The seed value of an identity column.  This option applies only to columns whose Identity option is checked.
<br><br>
<b>Identity Increment</b><br>
The increment value (that is added to the identity value of the previous row) of an identity column.  This option applies only to columns whose Identity option is checked.
<br><br>
<b>Is RowGuid</b><br>
Determines whether the column is used by SQL Server as a ROWGUID column.  You can check this value only for a column that is an identity column.
</div>
<br>
<font color="red"><b>Warning:</b> There is a potential for column data loss when updating an existing column that has been created or modified outside of the Web Data Adminstrator tool. Properties such as foreign keys and indexes are not preserved when editing an existing column. </font>
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
