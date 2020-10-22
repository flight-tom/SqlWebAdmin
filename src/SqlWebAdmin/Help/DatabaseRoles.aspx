<%@ Page language="c#" Inherits="SqlWebAdmin.Help.DatabaseRoles" CodeFile="DatabaseRoles.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="DATABASE ROLES" runat="server"/>

<a href="#Overview">Overview</a><br>
<a href="#Editing">Editing a Database Role</a><br>

<a name="Overview"/>
<h3>Overview</h3>
<p>
Roles are a powerful tool that allow you to collect users into a single unit 
against which you can apply permissions. Permissions granted to, denied to, or 
revoked from a role also apply to any members of the role. You can establish a 
role that represents a job performed by a class of workers in your organization 
and grant the appropriate permissions to that role. As workers rotate into the 
job, you simply add them as a member of the role; as they rotate out of the job, 
remove them from the role. You do not have to repeatedly grant, deny, and revoke 
permissions to or from each person as they accept or leave the job. The 
permissions are applied automatically when the users become members of the role.
</p>
<a name="Editing"/>
<h3>Editing a Database Role</h3>
<p>
You may add or remove database users to or from a database role.  System database roles consist 
of read only properties that you may not change.  User defined database roles can not be created
using this tool. 
</p>

<Toolbar:HelpFooter runat="server"/>
