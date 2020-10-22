<%@ Page language="c#" Inherits="SqlWebAdmin.Tables" CodeFile="Tables.aspx.cs" %>
<%@ Register TagPrefix="Location" TagName="Database" Src="Toolbars/DatabaseLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Server" Src="Toolbars/ServerLocation.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Server" Src="Toolbars/ServerToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Database" Src="Toolbars/DatabaseToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Web Data Administrator - Tables</title>
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
									<Toolbar:HelpLogout Runat="server" id="HelpLogout" HelpTopic="tables"></Toolbar:HelpLogout>
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
								<td valign="middle" align="left" width="100%" height="26">
									<Location:Server Runat="Server" id="ServerLocation"></Location:Server>
									<Location:Database Runat="Server" id="DatabaseLocation"></Location:Database>
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
						<Toolbar:Server Runat="server" id="ServerToolbar"></Toolbar:Server>
						<Toolbar:Database Selected="Tables" Runat="server" ID="DatabaseToolbar"></Toolbar:Database>
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
												TABLES
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
												<table width="100%" cellspacing="0" cellpadding="0" border="0">
													<tr>
														<td>
															<asp:dropdownlist id="TableTypeDropDownList" runat="server">
																<asp:ListItem Value="User Tables Only">Show User Tables Only</asp:ListItem>
																<asp:ListItem Value="User and System Tables">Show User and System Tables</asp:ListItem>
															</asp:dropdownlist>
															<asp:Button id="FilterTablesButton" runat="server" Text="Filter" CSSClass="button" onMouseOver="this.style.color='#808080';"
																onMouseOut="this.style.color='#000000';"></asp:Button>
														</td>
														<td align="right">
															<asp:HyperLink Runat="server" CssClass="createLink" ID="AddNewTableHyperLink">
																<img src="images/new.gif" width="16" height="16" alt="" border="0">
																<span style="position:relative; top: -3px;">Create new table</span>
															</asp:HyperLink>
														</td>
													</tr>
												</table>
												<br>
												<asp:datagrid id="TablesDataGrid" runat="server" GridLines="None" Border="0" AutoGenerateColumns="False"
													Width="100%" CellPadding="4" CellSpacing="1">
													<HeaderStyle CssClass="tableHeader"></HeaderStyle>
													<ItemStyle CssClass="tableItems"></ItemStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Name">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False" ></ItemStyle>
															<ItemTemplate>
																<a href='<%# String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																	<img src="images/table_ico.gif" border="0" align="absmiddle"></a>
																<asp:HyperLink id="Hyperlink1" runat="server" text='<%# "&amp;nbsp;" + DataBinder.Eval(Container.DataItem, "name") %>' cssclass="databaseListBlack" NavigateUrl='<%# String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Owner">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="Hyperlink2" runat="server" text='<%# "&amp;nbsp;" + DataBinder.Eval(Container.DataItem, "Owner") %>' cssclass="databaseListBlack" NavigateUrl='<%# String.Format("EditDatabaseUser.aspx?database={0}&user={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "owner")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<%--                                                        
                                                        <asp:BoundColumn DataField="owner" HeaderText="Owner" DataFormatString="{0}">
                                                            <HeaderStyle Wrap="False">
                                                            </HeaderStyle>
                                                            <ItemStyle Wrap="False">
                                                            </ItemStyle>
                                                        </asp:BoundColumn>
                                                        --%>
														<asp:TemplateColumn HeaderText="Type">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container.DataItem, "type") %>
																&nbsp;
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="createdate" HeaderText="Create Date" DataFormatString="{0}">
															<HeaderStyle Wrap="False"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="rows" HeaderText="Rows" DataFormatString="{0}">
															<HeaderStyle Wrap="False" HorizontalAlign="Right"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Edit">
															<HeaderStyle Wrap="False" HorizontalAlign="Right"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="EditTable" runat="server" text="edit" cssclass="databaseListAction" NavigateUrl='<%# String.Format("columns.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Rename">
															<HeaderStyle Wrap="False" HorizontalAlign="Right"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="RenameHyperLink" runat="server" text="rename" cssclass="databaseListAction" NavigateUrl='<%# String.Format("renametable.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Delete">
															<HeaderStyle Wrap="False" HorizontalAlign="Right"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="DeleteTable" runat="server" text="delete" cssclass="databaseListAction" NavigateUrl='<%# String.Format("deletetable.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="View">
															<HeaderStyle Wrap="False" HorizontalAlign="Right"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="ViewTable" runat="server" text="view" cssclass="databaseListAction" NavigateUrl='<%# String.Format("viewtableData.aspx?database={0}&table={1}", Server.UrlEncode(Request["database"]), DataBinder.Eval(Container.DataItem, "encodedname")) %>'>
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid>
												<asp:label id="TableTypeErrorLabel" runat="server" EnableViewState="False" Font-Bold="true"
													Font-Size="10">There are no tables to display.</asp:label>
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
