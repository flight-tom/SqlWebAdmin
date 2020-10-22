<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Export" CodeFile="Export.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="EXPORTING DATABASES" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>

You can export an entire database so that it may be imported into another server later.  The <b>Export Database</b> page prompts you to select the name of the database you wish to export, followed by a list of options specifying which objects to export.  The objects that may be exported are:
<br><br>

<div style="padding:0,0,0,20">
<b>Database</b>
<br>
Check this option when you are creating a complete backup of the database and need to save the name and file properties of the database.  Note that if you later import this into a different server, you made need to change the path to the database file in the .sql file to match the target server's file system.
<br><br>
<b>Table Schemas</b>
<br>
Check this option to export the table and column structure of the database.  This can be imported into the same or a different database later.
<br><br>
<b>Table data</b>
<br>
Check this option to export the actual data rows contained in the database tables.
<br><br>
<b>Stored Procedures</b>
<br>
Check this option to export the stored procedures in the database.
</div>

<br>

You may also choose a few options that determine how the .sql export file is generated.  Drop commands are used to explicitly delete pre-existing objects by the same name before attempting to create new objects during Import.  Including descriptive comments makes the .sql file more readable, although slightly larger.
<br><br>
Click the "Export" button to export the selected objects to a file.  Be sure to use the .sql extension when saving this file (place the filename in double quotes, for example "myDBExport.sql").
<br><br>

<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>