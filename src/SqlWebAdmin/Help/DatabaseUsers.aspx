<%@ Page language="c#" Inherits="SqlWebAdmin.Help.DatabaseUsers" CodeFile="DatabaseUsers.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<Toolbar:HelpHeader Topic="DATABASE USERS" runat="server"/>

<a href="#Overview">Overview</a><br>
<a href="#Adding">Adding a Database User</a><br>
<a href="#Editing">Editing a Database User</a><br>
<a href="#Removing">Removing a Database User</a><br>

<a name="Overview"/>
<h3>Overview</h3>
<P>A user identifier (ID) identifies a user within a database. All permissions 
and ownership of objects in the database are controlled by the user account. 
User accounts are specific to a database; the <B>xyz</B> user account in the 
<B>sales</B> database is different from the <B>xyz</B> user account in the 
<B>inventory</B> database, even though both accounts have the same ID. User IDs 
are defined by members of the <B>db_owner</B> fixed database role.</P>
<P>A login ID by itself does not give a user permissions to access objects in 
any databases. A login ID must be associated with a user ID in each database 
before anyone connecting with that login ID can access objects in the databases. 
If a login ID has not been explicitly associated with any user ID in a database, 
it is associated with the <B>guest</B> user ID. If a database has no 
<B>guest</B> user account, a login cannot access the database unless it has been 
associated with a valid user account.</P>
<P>When a user ID is defined, it is associated with a login ID. For example, a 
member of the <B>db_owner</B> role can associate the Microsoft® Windows® 2000 
login <B>NETDOMAIN\Joe</B> with user ID <B>abc</B> in the <B>sales</B> database 
and user ID <B>def</B> in the <B>employee</B> database. The default is for the 
login ID and user ID to be the same.
</p>

<a name="Adding"/>
<h3>Adding a Database User</h3>
<p>
To add a new database user click the <b>Create New User</b> link located towards the upper right hand of 
the screen.  You will then be prompted to select the SQL Server login that the new user will be
associated to.  You may also define the user name if you wish it to differ from the SQL Server login name.
</p>

<a name="Editing"/>
<h3>Editing a Database User</h3>
<p>
You may add or remove database roles to or from a database user.  You may also use SQL Enterprise Manager to 
determine granular permissions for a specific user.
</p>

<a name="Removing"/>
<h3>Removing a Database User</h3>
<p>
On the database users view, click <b>Delete</b> to remove a database user.  
</p>
<Toolbar:HelpFooter runat="server"/>
