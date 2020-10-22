<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Error" CodeFile="Error.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="ERRORS" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

There a several types of errors that can be reported from the Web Data Administrator.
<br><br>
<b>Validation Errors</b>
<br><br>
These errors occur when the Web Data Administrator attempts to assert some condition that fails.  Some examples are:
<ul>
<li> Failure to enter data in a field that is required, like omitting the name when creating a new database
<li> Failure to enter the correct data type in a particular field, like setting the length of a varchar column to a non-integer number
<li> Attempting to access an object that no longer exists, like a table that has been deleted from outside the Web Data Administrator tool.
</ul>

<b>SQL-DMO Errors</b>
<br><br>
These errors are reported by the SQL-DMO library when the Web Data Administrator attempts to perform an operation on the connected database server for which it has given invalid parameters or has insufficient permission to complete.  For example:
<br><br>
<pre>
There was an error saving the stored procedure.
[Microsoft][ODBC SQL Server Driver][SQL Server]Line 2: Incorrect syntax near 'select'. 
</pre>

<b>Unhandled Errors</b>
<br><br>
Unhandled errors are unanticipated by the Web Data Administrator, and are displayed as stack trace information indicating the exception and location in source code where the error occured.

<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
