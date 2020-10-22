<%@ Reference Page="~/Databases.aspx" %>
<%@ Page language="c#" Inherits="SqlWebAdmin.export" CodeFile="Export.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<%@ Register TagPrefix="Location" TagName="Server" Src="Toolbars/ServerLocation.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Server" Src="Toolbars/ServerToolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Web Data Administrator - Export</title>
		<link rel="shortcut icon" href="favicon.ico">
			<link rel="stylesheet" type="text/css" href="admin.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<FORM id="WebForm1" method="post" runat="server">
			<TABLE width="100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
				<!-- FIRST ROW: HEADER -->
				<tr>
					<td colspan="3" valign="bottom" align="left" width="100%" height="36" bgcolor="#c0c0c0">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<!--BEGIN ONE LINE-->
								<td valign="bottom" width="308"><img src="images/logo_top.gif" width="308" height="36" alt="" border="0"></td>
								<!--END ONE LINE-->
								<td valign="bottom" align="right" width="100%">
									<Toolbar:HelpLogout Runat="server" id="HelpLogout" HelpTopic="export"></Toolbar:HelpLogout>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- FIRST ROW: HEADER -->
				<!-- SECOND ROW: CRUMBS -->
				<tr>
					<!--BEGIN ONE LINE-->
					<td align="left" bgcolor="#99ccff" background="images/blue_back.gif" width="172" height="26"><img src="images/logo_bottom.gif" width="172" height="26" alt="" border="0"></td>
					<!--END ONE LINE-->
					<td align="left" bgColor="#99ccff" background="images/blue_back.gif" width="100%" height="26">
						<table width="100%" height="26" cellSpacing="0" cellPadding="0" border="0" style="TABLE-LAYOUT:fixed">
							<tr>
								<td width="12">
									&nbsp;
								</td>
								<td valign="center" align="left" width="100%" height="26">
									<Location:Server Runat="Server" id="ServerLocation"></Location:Server>
								</td>
							</tr>
						</table>
					</td>
					<!--BEGIN ONE LINE-->
					<td align="left" bgcolor="#99ccff" width="12" height="26"><img src="images/blue_back_right.gif" width="12" height="26" alt="" border="0"></td>
					<!--END ONE LINE-->
				</tr>
				<!-- SECOND ROW: CRUMBS -->
				<!-- THIRD ROW: BOTTOM SECTION -->
				<tr>
					<!-- START NAVIGATION SECTION -->
					<td bgcolor="#6699ff" valign="top" align="middle" width="172" height="100%">
						<Toolbar:Server Selected="Export" Runat="server" id="ServerToolbar"></Toolbar:Server>
					</td>
					<!-- END NAVIGATION SECTION -->
					<!-- START CONTENT SECTION -->
					<td valign="top" align="left">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%">
							<tr>
								<!--BEGIN ONE LINE-->
								<td valign="bottom" colSpan="2" height="8" width="100%"><img src="images/spacer.gif" width="1" height="8" alt="" border="0"></td>
								<!--END ONE LINE-->
							</tr>
							<tr>
								<!--BEGIN ONE LINE-->
								<td align="left" width="12"><img src="images/spacer.gif" width="12" height="1" alt="" border="0"></td>
								<!--END ONE LINE-->
								<td align="left" class="databaseListItem" width="100%">
									<!-- PAGE CONTENT: START -->
									<!-- SECTION HEADER: START -->
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="databaseListHeader">
												EXPORT DATABASE
											</td>
										</tr>
										<!-- SECTION HEADER: END -->
										<!-- SECTION: START -->
										<tr>
											<!--BEGIN ONE LINE-->
											<td height="3" valign="center" background="images/blue_dotted_line.gif"><img src="images/blue_dotted_line.gif" width="150" height="3" alt="" border="0"></td>
											<!--END ONE LINE-->
										</tr>
										<tr>
											<!--BEGIN ONE LINE-->
											<td height="4" valign="center"><img src="images/spacer.gif" width="1" height="4" alt="" border="0"></td>
											<!--END ONE LINE-->
										</tr>
										<tr>
											<td bgcolor="white" class="databaseListItem">
												Select the database to export:
												<br>
												<br>
												<asp:DropDownList Runat="server" ID="ExportDatabaseList"></asp:DropDownList>
												<br>
												<br>
												Objects to export:
												<br>
												<br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptDatabaseCheckBox" Text="Database" Checked="True"></asp:CheckBox><br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptTableSchemeCheckBox" Text="Table schemas" Checked="True"></asp:CheckBox><br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptTableDataCheckBox" Text="Table data" Checked="True"></asp:CheckBox><br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptStoredProceduresCheckBox" Text="Stored procedures" Checked="True"></asp:CheckBox><br>
												<br>
												Options:
												<br>
												<br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptDropCheckBox" Text="DROP commands" Checked="True"></asp:CheckBox><br>
												&nbsp;&nbsp;&nbsp;<asp:CheckBox Runat="server" ID="ScriptCommentsCheckBox" Text="Include descriptive comments" Checked="True"></asp:CheckBox><br>
												<br>
												<asp:Button Runat="server" ID="ExportButton" CSSClass="button" onMouseOver="this.style.color='#808080';" onMouseOut="this.style.color='#000000';" Text="Export" onclick="ExportButton_Click"></asp:Button>
												<br>
												<br>
												This operation can take a few minutes, do not click on the button more than 
												once.
												<br>
												<br>
												Note: If you are exporting a database created or modified outside of the Web 
												Data Administrator, it may not correctly preserve all database objects 
												(triggers, views, and relationships for example).
											</td>
										</tr>
										<!-- Section END -->
										<!-- Section Footer START -->
									</table>
									<br>
									<!-- Section Footer END -->
									<!-- Page content END -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- THIRD ROW: BOTTOM SECTION -->
			</TABLE>
		</FORM>
	</body>
</HTML>