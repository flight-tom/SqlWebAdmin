<%@ Page language="c#" Inherits="SqlWebAdmin.Help.ServerLogins" CodeFile="ServerLogins.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="SERVER LOGINS" runat="server"/>

<a href="#Overview">Overview</a><br>
<a href="#Adding">Adding a SQL Server Login</a><br>
<a href="#Editing">Editing a SQL Server Login</a><br>
<a href="#Removing">Removing a SQL Server Login</a><br>
<br><br>
<a name="Overview"/>
<h3>Overview</h3>
<p>
SQL Server logins provide a means for authenticating connections made to the SQL Server database. 
A login may include database users to allow access to a particular database.
</p>
<a name="Adding"/>
<h3>Adding a SQL Server Login</h3>
<p>
To add a new login click the <b>Create new Login</b> link located towards the upper right hand of 
the screen. The following table describes the fields that are necessary in order to create a new login:
</p>
<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Authentication Method</td>
		<td>Determines whether you want to use Windows Integrated or SQL based authentication.</td>
	</tr>
	<tr class=tableItems>
        <td>Login Name</td>
		<td>
			Name of the SQL login you wish to create.  This should be the same as the Windows login 
			you wish to use if Windows Integrated is selected as the Authentication Method 
			<nobr>(eg: [domainname]\[username])</nobr>.
		</td>
	</tr>
	<tr class=tableItems>
        <td>Password</td>
		<td>
			The password associated with this login. This property is applicable only when SQL based 
			authentication is selected. 
		</td>
	</tr>
</table>
<p>
After clicking <b>Create Login</b> you will be sent to the edit screen for that login so that you may
edit additional properties. Please see <a href="#Editing">Editing a SQL Server Login</a> for more information.
</p>
<a name="Editing"/>
<h3>Editing a SQL Server Login</h3>
<p>After a login has been created, it may be necessary to change the password, 
default database, or default language. For example, a user may forget her 
password, want to change the password for security reasons, need to use a 
different database on a regular basis, or need to see messages in a different 
language.  When you are done making changes click <b>Save Changes</b> to commit the changes
to the system.
</p>
<p>
NOTE: This tool does not currently support the ability to update passwords.
</p>
<p>
You may edit multiple properties which are divided into the following sections: 
<b>General</b>, <b>Server Roles</b>, and <b>Database Access</b>.
</p>
<b>General</b><br>
<p>
This section allows you to manage general properties.
</p>
<table cellSpacing=1 cellPadding=4 width="100%" border=0>
    <tr class=tableHeader>
        <td>Property</td>
		<td>Description</td>
	</tr>
    <tr class=tableItems>
        <td>Security Access</td>
		<td>
			This option is only applicable when a login uses Windows Authentication. Select
			<b>Grant</b> if you wish to grant login access to a Windows NT 4.0 or Windows 2000 
			account.  Select <b>Deny</b> if you wish to deny login access to a Windows NT 4.0 
			or Windows 2000 account.
		</td>
	</tr>
	<tr class=tableItems>
        <td nowrap>Default Database</td>
		<td>
			The default database for this login.			
		</td>
	</tr>
	<tr class=tableItems>
        <td now>Default Language</td>
		<td>
			The default language for this login.
		</td>
	</tr>
</table>
<br>
<b>Server Roles</b>
<p>
This section allows you to view, add, or remove roles for this login.
</p>
<b>Database Access</b>
<p>
This section allows you to specifiy which databases this login has access to.  When
a login has access to a database a database user is created for that database.  See  
<a href="DatabaseUsers.aspx">Database Users</a> for more information.
</p>
<a name="Removing"/>
<h3>Removing a SQL Server Login</h3>
<p>
You can not remove SQL Server Logins with this tool.  Please use the SQL Server Enterprise Manager to
perform this operation.  
</p>
<Toolbar:HelpFooter runat="server"/>
