<%@ Control Language="c#" Inherits="SqlWebAdmin.Toolbars.HelpLogoutToolbar" CodeFile="HelpLogoutToolbar.ascx.cs" %>
                        <table cellSpacing="0" cellPadding="0" border="0">
                            <tr>
                                <td valign="bottom" align="left" width="16" height="36" style="PADDING-BOTTOM:5px">
                                    <asp:HyperLink id="HelpImageHyperLink" runat="server" Target="_blank"><img src="images/help.gif" name="Help" width="16" height="16" alt="Help" border="0" style="CURSOR:hand"></asp:HyperLink>
                                </td>
                                <td valign="bottom" align="left" width="8" height="36">
                                    &nbsp;
                                </td>
                                <td valign="bottom" align="left" width="16" height="36" style="PADDING-BOTTOM:5px">
                                    <asp:HyperLink id="LogoutImageHyperLink" runat="server"><img src="images/logout.gif" name="Logout" width="16" height="16" alt="Logout" border="0" style="CURSOR:hand"></asp:HyperLink>
                                </td>
                                <td valign="bottom" align="left" width="8" height="36">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>