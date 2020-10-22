<%@ Register TagPrefix="Toolbar" TagName="HelpFooter" Src="HelpFooter.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpHeader" Src="HelpHeader.ascx" %>
<%@ Page language="c#" Inherits="SqlWebAdmin.Help.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<P>
	<Toolbar:HelpHeader Topic="LOGGING IN" runat="server" ID="Helpheader1" NAME="Helpheader1"></Toolbar:HelpHeader>Before 
	you can use the Web Data Administrator, you will need to login to the server 
	you wish to administer. Web Data Administrator supports integrated Windows 
	authentication or SQL authentication. Web Data Administrator must be configured 
	to deny anonymous access if you want to use integrated Windows authentication. 
	Also, in order to use SQL Authentication, the SQL Server must be running in 
	"Mixed Mode" (see the SQL Server documentation for more information).
</P>
<p>
 Because Web Data Administrator runs on two different types of web servers that are different
 in capabilities and architecture the way you logon is also different. Below are the differences 
 between the two web servers.
</p>
<p>
<b>IIS Web Server</b>
<br>
<u>Windows Authentication</u><br>
Username: Populated for you.<br>
Password: Populated for you.<br>
Server:   You enter this data. Default is (local)<br>
<br>
<u>SQL Server Authentication</u>
Username: A valid SQL login.<br>
Password: Password for SQL login for username specified in Username field.<br>
Server:   You enter this data. Default is (local)<br>
<br><br>
<b>Cassini Web Server</b>
Cassini Web Server is an open source web server developed using the Microsoft® .NET® Framework. You can find more information
on Cassini Web Server <a href="http://asp.net/Default.aspx?tabindex=7&tabid=41" target="_blank">here</a>. Using the Cassini Web Server to host
the Web Data Adminstrator application give you an added feature of being able to use a Windows account other than the one you
are currently logged in as. Warning: You will have to provide your credentials manually when using the Cassini Web Server which
means they are passed in clear text back to the server (see next section for fix). <span style="color:red;">Verify that you can
even request from other computer</span>
<br><br>
<u>Windows Authentication</u><br>
Username: You must fill out this section. (Example: domain|computer\login)<br>
Password: You must fill out this section. (Example: password)<br>
Server:   You enter this data. Default is (local)<br>
<br>
<u>SQL Server Authentication</u><br>
Username: A valid SQL login.<br>
Password: Password for SQL login for username specified in Username field.<br>
Server:   You enter this data. Default is (local)
</p>
<P>If you are using SQL authentication, you are prompted for your user name, 
	password, and the server with which to connect. If you are using Windows 
	authentication, Web Data Administrator automatically obtains your username 
	credentials, so you only need to specify a server name.</P>
<P>Note: The SQL authentication security credentials are passed from the web 
	browser to the Web Data Administrator using a normal plain-text form POST over 
	HTTP. When using the Web Data Administrator over an unsecure network (the 
	Internet, for example) it is recommended you enable secure socket layer (SSL) 
	for this application.
	<br>
	<br>
	After you successfully log in, the Web Data Administrator displays a list of 
	databases viewable by your user account. From this screen you can create a new 
	database or edit, query, and delete an existing one. You may also import or 
	export a database to/from this server.
	<br>
	<br>
	<Toolbar:HelpFooter runat="server" ID="Helpfooter1" NAME="Helpfooter1"></Toolbar:HelpFooter></P>
