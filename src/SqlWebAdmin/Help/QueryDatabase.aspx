<%@ Page language="c#" Inherits="SqlWebAdmin.Help.QueryDatabase" CodeFile="QueryDatabase.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="QUERYING DATABASES AND TABLES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

To query a database or table, select the "query" link on either the <b>Databases</b> or <b>Tables</b> page.  The Query page displays a large text area in which to enter your query (using TSQL syntax).  To execute your query, press the "Execute" button.  When selecting data, results are displayed in grid-format at the bottom of the page (multiple selects display multiple grids).  You can choose whether to wrap grid cell contents in results using the checkbox on this page.
<br><br>
<b>Saving a query</b>
<br><br>
Click the "Save query" button to save the text of the query to a file.  Be sure to use the .sql extension when saving this file (place the filename in double quotes, for example "myQuery.sql").
<br><br>
<b>Loading a query</b>
<br><br>
You may reload a previously saved query by typing the path to the .sql file in the "Load Query" textbox (or Browse for the file instead) and clicking the "Load query" button.
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>