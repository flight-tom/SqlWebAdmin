<%@ Page language="c#" Inherits="SqlWebAdmin.Help.DeleteColumn" CodeFile="DeleteColumn.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="DELETING COLUMNS" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

When you choose to delete a column from the <b>Columns</b> page, you are asked to confirm whether to proceed with the delete operation.  Click "Yes" to complete the deletion and "No" to cancel the deletion.  Once a column is deleted, it cannot be undone.
<br><br>
Note: you cannot delete a column if it is the only column in the table.  In this case, use "Delete Table" instead.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>