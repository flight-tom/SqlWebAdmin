<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Security" CodeFile="Security.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<Toolbar:HelpHeader Topic="SECURITY" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>The 
Web Data Administrator uses SQL authentication or integrated Windows 
authentication&nbsp;in order to establish a connection to the database server. 
If you are connecting to Microsoft SQL Server using SQL authentication, it 
should be running in "Mixed Mode" (see the SQL Server documentation for more 
information).
<br>
<br>
Note: The SQL authentication security credentials are passed from the web 
browser to the Web Data Administrator using a normal plain-text form POST over 
HTTP. When using the Web Data Administrator over an unsecure network (the 
Internet, for example) it is recommended you enable secure socket layer (SSL) 
for this application.
<br>
<br>
All operations in the Web Data Administrator are performed on behalf of the 
logged in user account. If the database server disallows certain priviledges to 
that account, an error will be returned and displayed. While account 
priviledges cannot be administered through the Web Data Administrator, it will 
respect any security restrictions enforced by the backend database server.
<br>
<br>
<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter>
