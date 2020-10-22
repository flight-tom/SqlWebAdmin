<%@ Page Language="c#" Inherits="SqlWebAdmin.Login" CodeFile="Default.aspx.cs" %>

<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Web Data Administrator - Login</title>
    <link rel="shortcut icon" href="favicon.ico">
    <link rel="stylesheet" type="text/css" href="admin.css">
</head>

<script language="javascript" src="Global.js"></script>

<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="WebForm1" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="0" cellpadding="0" border="0">
        <!-- FIRST ROW: HEADER -->
        <tr>
            <td colspan="3" valign="bottom" align="left" width="100%" height="36" bgcolor="#c0c0c0">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <!--BEGIN ONE LINE-->
                        <td valign="bottom" width="308">
                            <img src="images/logo_top.gif" width="308" height="36" alt="" border="0">
                        </td>
                        <!--END ONE LINE-->
                        <td valign="bottom" align="right" width="100%">
                            <Toolbar:HelpLogout runat="server" ID="HelpLogout" HelpTopic="login"></Toolbar:HelpLogout>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- FIRST ROW: HEADER -->
        <!-- SECOND ROW: CRUMBS -->
        <tr>
            <!--BEGIN ONE LINE-->
            <td align="left" bgcolor="#99ccff" background="images/blue_back.gif" width="172"
                height="26">
                <img src="images/logo_bottom.gif" width="172" height="26" alt="" border="0">
            </td>
            <!--END ONE LINE-->
            <td align="left" bgcolor="#99ccff" background="images/blue_back.gif" width="100%"
                height="26">
                <table width="100%" height="26" cellspacing="0" cellpadding="0" border="0" style="table-layout: fixed">
                    <tr>
                        <td width="12">
                            &nbsp;
                        </td>
                        <td valign="middle" align="left" width="100%" height="26">
                        </td>
                    </tr>
                </table>
            </td>
            <!--BEGIN ONE LINE-->
            <td align="left" bgcolor="#99ccff" width="12" height="26">
                <img src="images/blue_back_right.gif" width="12" height="26" alt="" border="0">
            </td>
            <!--END ONE LINE-->
        </tr>
        <!-- SECOND ROW: CRUMBS -->
        <!-- THIRD ROW: BOTTOM SECTION -->
        <tr>
            <!-- START NAVIGATION SECTION -->
            <td bgcolor="#6699ff" valign="top" align="center" width="172" height="100%">
            </td>
            <!-- END NAVIGATION SECTION -->
            <!-- START CONTENT SECTION -->
            <td valign="top" align="left">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <!--BEGIN ONE LINE-->
                        <td valign="bottom" colspan="2" height="8" width="100%">
                            <img src="images/spacer.gif" width="1" height="8" alt="" border="0">
                        </td>
                        <!--END ONE LINE-->
                    </tr>
                    <tr>
                        <!--BEGIN ONE LINE-->
                        <td align="left" width="12">
                            <img src="images/spacer.gif" width="12" height="1" alt="" border="0">
                        </td>
                        <!--END ONE LINE-->
                        <td align="left" class="databaseListItem" width="100%">
                            <!-- PAGE CONTENT: START -->
                            <asp:Label ID="LogoutInfoLabel" runat="server" Visible="False">You are now logged out.</asp:Label>
                            <asp:Label ID="LoginInfoLabel" runat="server" Visible="False" Font-Size="10 pt" Font-Bold="true">Welcome to the Web Data Administrator.</asp:Label>
                            <br>
                            <br>
                            <asp:Label ID="lblCredMsg" runat="server" Font-Size="8 pt">Please enter your SQL Server credentials:</asp:Label>
                            <br>
                            <br>
                            <table border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td class="databaseListItem">
                                        Username
                                    </td>
                                    <td class="databaseListItem" width="50">
                                        &nbsp;
                                    </td>
                                    <td class="databaseListItem">
                                        <asp:TextBox ID="UsernameTextBox" runat="server" Columns="35"></asp:TextBox>
                                    </td>
                                    <td class="databaseListItem">
                                        <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage=" Must specify a user name"
                                            ControlToValidate="UsernameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="databaseListItem">
                                        Password
                                    </td>
                                    <td class="databaseListItem" width="50">
                                        &nbsp;
                                    </td>
                                    <td class="databaseListItem">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" Columns="35" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td class="databaseListItem">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="databaseListItem">
                                        Server
                                    </td>
                                    <td class="databaseListItem" width="50">
                                        &nbsp;
                                    </td>
                                    <td class="databaseListItem">
                                        <asp:TextBox ID="ServerTextBox" runat="server" Columns="35"></asp:TextBox>
                                    </td>
                                    <td class="databaseListItem">
                                        <asp:RequiredFieldValidator ID="ServerRequiredFieldValidator" runat="server" ErrorMessage=" Must specify a server name"
                                            ControlToValidate="ServerTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td class="databaseListItem">
                                        <asp:Label ID="lblAuth" runat="server">Authentication<br>Method</asp:Label>
                                    </td>
                                    <td class="databaseListItem" width="50">
                                    </td>
                                    <td class="databaseListItem" nowrap>
                                        <asp:RadioButtonList ID="AuthRadioButtonList" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="AuthRadioButtonList_SelectedIndexChanged">
                                            <asp:ListItem Value="windows" Selected="True">Windows Integrated</asp:ListItem>
                                            <asp:ListItem Value="sql">SQL Login</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="databaseListItem">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="databaseListItem" colspan="3" align="right">
                                        <asp:Button ID="LoginButton" CssClass="button" onMouseOver="this.style.color='#808080';"
                                            onMouseOut="this.style.color='#000000';" runat="server" Text="Login" OnClick="LoginButton_Click">
                                        </asp:Button>
                                    </td>
                                    <td class="databaseListItem">
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <asp:Label ID="ErrorLabel" runat="server" Visible="False" ForeColor="red"></asp:Label>
                            <!-- PAGE CONTENT: END -->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- THIRD ROW: BOTTOM SECTION -->
    </table>
    </form>
</body>
</html>
