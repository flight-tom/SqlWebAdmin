<%@ Page language="c#" Inherits="SqlWebAdmin.DeleteColumn" CodeFile="DeleteColumn.aspx.cs" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<%@ Register TagPrefix="Location" TagName="Server" Src="Toolbars/ServerLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Database" Src="Toolbars/DatabaseLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Table" Src="Toolbars/TableLocation.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Server" Src="Toolbars/ServerToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Database" Src="Toolbars/DatabaseToolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Web Data Administrator - Delete Column</title>
        <link rel="shortcut icon" href="favicon.ico">
        <link rel="stylesheet" type="text/css" href="admin.css">
    </HEAD>
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
        <FORM method="post" runat="server">
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
                                    <Toolbar:HelpLogout Runat="server" id="HelpLogout" HelpTopic="deletecolumn"></Toolbar:HelpLogout>
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
                                    <Location:Database Runat="Server" id="DatabaseLocation"></Location:Database>
                                    <Location:Table Runat="Server" id="TableLocation"></Location:Table>
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
                        <Toolbar:Server Runat="server" id="ServerToolbar">
                        </Toolbar:Server>
                        <Toolbar:Database Runat="server" ID="DatabaseToolbar">
                        </Toolbar:Database>
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
                                                CONFIRM DELETE
                                            </td>
                                        </tr>
                                        <!-- SECTION HEADER: END -->
                                        <!-- SECTION: START -->
                                        <tr>
                                            <!--BEGIN ONE LINE-->
                                            <td height="3" valign="middle" background="images/blue_dotted_line.gif"><img src="images/blue_dotted_line.gif" width="150" height="3" alt="" border="0"></td>
                                            <!--END ONE LINE-->
                                        </tr>
                                        <tr>
                                            <!--BEGIN ONE LINE-->
                                            <td height="4" valign="middle"><img src="images/spacer.gif" width="1" height="4" alt="" border="0"></td>
                                            <!--END ONE LINE-->
                                        </tr>
                                        <tr>
                                            <td bgcolor="white" class="databaseListItem">
                                                Are you sure you want to delete column
                                                <asp:Label id="ColumnNameLabel" runat="server" Font-Bold="True"></asp:Label>
                                                from table
                                                <asp:Label id="TableNameLabel" runat="server" Font-Bold="True"></asp:Label>?
                                                <br>
                                                <br>
                                                <asp:Button id="YesButton" runat="server" CSSClass="button" onMouseOver="this.style.color='#808080';" onMouseOut="this.style.color='#000000';" Text="  Yes  " onclick="YesButton_Click"></asp:Button>
                                                &nbsp;
                                                <asp:Button id="NoButton" runat="server" CSSClass="button" onMouseOver="this.style.color='#808080';" onMouseOut="this.style.color='#000000';" Text="  No  " onclick="NoButton_Click"></asp:Button>
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
