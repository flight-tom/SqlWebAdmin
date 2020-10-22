<%@ Page language="c#" Inherits="SqlWebAdmin.Help.ServerRoles" CodeFile="ServerRoles.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="SERVER ROLES" runat="server"/>

<a href="#Overview">Overview</a><br>
<a href="#Editing">Editing a SQL Server Role</a><br>

<a name="Overview"/>
<h3>Overview</h3>
<P>The security mechanism in Microsoft® SQL Server™ includes several predefined 
roles with implied permissions that cannot be granted to other user accounts. If 
you have users who require these permissions, you must add their accounts to 
these predefined roles. The two types of predefined roles are fixed
server and fixed database.
</P>
<a name="Editing"/>
<h3>Editing a SQL Server Role</h3>
<p>
SQL Server roles have predefined permissions that can not be changed.
You may add or remove logins from a role by clicking on <b>Add or Edit Logins</b>.

</p>
<Toolbar:HelpFooter runat="server"/>