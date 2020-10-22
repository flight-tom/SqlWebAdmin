<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewTableData.aspx.cs" Inherits="viewTableData" %>

<%@ Register TagPrefix="Location" TagName="Database" Src="Toolbars/DatabaseLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Server" Src="Toolbars/ServerLocation.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Server" Src="Toolbars/ServerToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Database" Src="Toolbars/DatabaseToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Web Data Administrator - Tables</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <link rel="stylesheet" type="text/css" href="admin.css" />
</head>
<body>
    <form id="FORM1" method="post" runat="server">
    <div>
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
                                <Toolbar:HelpLogout runat="server" ID="HelpLogout" HelpTopic="tables"></Toolbar:HelpLogout>
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
                    <img src="images/logo_bottom.gif" width="172" height="26" alt="" border="0" />
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
                                <Location:Server runat="Server" ID="ServerLocation"></Location:Server>
                                <Location:Database runat="Server" ID="DatabaseLocation"></Location:Database>
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
                <td bgcolor="#6699ff" valign="top" align="middle" width="172" height="100%">
                    <Toolbar:Server runat="server" ID="ServerToolbar"></Toolbar:Server>
                    <Toolbar:Database Selected="Tables" runat="server" ID="DatabaseToolbar"></Toolbar:Database>
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
                                <!-- SECTION HEADER: START -->
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="databaseListHeader">
                                            <asp:Label ID="curTable" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <!-- SECTION HEADER: END -->
                                    <!-- SECTION: START -->
                                    <tr>
                                        <!--BEGIN ONE LINE-->
                                        <td height="3" valign="middle" background="images/blue_dotted_line.gif">
                                            <img src="images/blue_dotted_line.gif" width="150" height="3" alt="" border="0">
                                        </td>
                                        <!--END ONE LINE-->
                                    </tr>
                                    <tr>
                                        <!--BEGIN ONE LINE-->
                                        <td height="4" valign="middle">
                                            <img src="images/spacer.gif" width="1" height="4" alt="" border="0">
                                        </td>
                                        <!--END ONE LINE-->
                                    </tr>
                                    <tr>
                                        <td bgcolor="white" class="databaseListItem">
                                            <asp:GridView ID="GridView_ViewTableData" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView_ViewTableData_RowCommand">
                                                <RowStyle ForeColor="#000066" />
                                                <Columns>
                                                    <asp:ButtonField Text="Edit" HeaderText="Edit" ShowHeader="True" />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            <asp:Label ID="MessageLabel" runat="server" EnableViewState="False" Font-Bold="true"
                                                Font-Size="10"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>       <div>

         <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
    <div>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
            BackgroundCssClass="modalBackground" DropShadow="True" PopupDragHandleControlID="programmaticPopupDragHandle"
            RepositionMode="RepositionOnWindowScroll">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
            width: 350px; padding: 10px">
            <asp:Panel runat="Server" ID="programmaticPopupDragHandle" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black; text-align: center;">
                Edit Data</asp:Panel>
            <div id="dbFields" runat="server"></div>
            <div id="btnFields">
            
                <asp:Button ID="btnUpdate" runat="server" Text="Update(under development)"  Enabled="false" onclick="btnUpdate_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
            </div>
            <br />
        </asp:Panel>        
        
    </div>


        </div>
                                        </td>
                                    </tr>
                                    <!-- Section END -->
                                    <!-- Section Footer START -->
                                </table>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                <br />
                                <!-- Section Footer END -->
                                <!-- Page content END -->
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <!-- THIRD ROW: BOTTOM SECTION -->
        </table>
 
    </div>
   

    </form>
</body>
</html>
