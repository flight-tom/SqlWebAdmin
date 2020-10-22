<%@ Register TagPrefix="Toolbar" TagName="HelpLogout" Src="Toolbars/HelpLogoutToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Database" Src="Toolbars/DatabaseToolbar.ascx" %>
<%@ Register TagPrefix="Toolbar" TagName="Server" Src="Toolbars/ServerToolbar.ascx" %>
<%@ Register TagPrefix="Location" TagName="Server" Src="Toolbars/ServerLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Database" Src="Toolbars/DatabaseLocation.ascx" %>
<%@ Register TagPrefix="Location" TagName="Table" Src="Toolbars/TableLocation.ascx" %>
<%@ Page language="c#" Inherits="SqlWebAdmin.EditColumn" CodeFile="EditColumn.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Web Data Administrator - Edit Column</title>
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
									<Toolbar:HelpLogout Runat="server" id="HelpLogout" HelpTopic="editcolumn"></Toolbar:HelpLogout>
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
						<Toolbar:Server Runat="server" id="ServerToolbar"></Toolbar:Server>
						<Toolbar:Database Runat="server" ID="DatabaseToolbar"></Toolbar:Database>
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
												EDIT COLUMN
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
												<!-- Column Editor START -->
												<asp:Label id="DataLossWarningLabel" runat="server" Visible="False" ForeColor="red">
                                                Warning:
                                                There is a potential for column data loss when updating an existing column that has been created or modified outside of the Web Data Adminstrator tool.
                                                Properties such as foreign keys and indexes are not preserved when editing an existing column.
                                                <br>
                                                <br>
                                                </asp:Label>
												<TABLE cellSpacing="2" cellPadding="0" border="0">
													<TR>
														<TD class="databaseListItem">Primary Key</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:CheckBox id="PrimaryKeyCheckbox" Runat="server"></asp:CheckBox></TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Column Name</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="ColumnNameTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem">
															<asp:requiredfieldvalidator id="ColumnNameRequiredFieldValidator" runat="server" ErrorMessage=" A column name must be specified." ControlToValidate="ColumnNameTextBox" Display="Dynamic"></asp:requiredfieldvalidator>
														</td>
													</TR>
													<TR>
														<TD class="databaseListItem">Data Type</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:DropDownList id="DataTypeDropdownlist" Runat="server">
																<asp:ListItem Value="bigint">bigint</asp:ListItem>
																<asp:ListItem Value="binary">binary</asp:ListItem>
																<asp:ListItem Value="bit">bit</asp:ListItem>
																<asp:ListItem Value="char" Selected="True">char</asp:ListItem>
																<asp:ListItem Value="datetime">datetime</asp:ListItem>
																<asp:ListItem Value="decimal">decimal</asp:ListItem>
																<asp:ListItem Value="float">float</asp:ListItem>
																<asp:ListItem Value="image">image</asp:ListItem>
																<asp:ListItem Value="int">int</asp:ListItem>
																<asp:ListItem Value="money">money</asp:ListItem>
																<asp:ListItem Value="nchar">nchar</asp:ListItem>
																<asp:ListItem Value="ntext">ntext</asp:ListItem>
																<asp:ListItem Value="numeric">numeric</asp:ListItem>
																<asp:ListItem Value="nvarchar">nvarchar</asp:ListItem>
																<asp:ListItem Value="real">real</asp:ListItem>
																<asp:ListItem Value="smalldatetime">smalldatetime</asp:ListItem>
																<asp:ListItem Value="smallint">smallint</asp:ListItem>
																<asp:ListItem Value="smallmoney">smallmoney</asp:ListItem>
																<asp:ListItem Value="sql_varient">sql_varient</asp:ListItem>
																<asp:ListItem Value="text">text</asp:ListItem>
																<asp:ListItem Value="timestamp">timestamp</asp:ListItem>
																<asp:ListItem Value="tinyint">tinyint</asp:ListItem>
																<asp:ListItem Value="uniqueidentifier">uniqueidentifier</asp:ListItem>
																<asp:ListItem Value="varbinary">varbinary</asp:ListItem>
																<asp:ListItem Value="varchar">varchar</asp:ListItem>
															</asp:DropDownList>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Length</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="LengthTextbox" Runat="server" Text="10" Columns="15">10</asp:TextBox>
														</TD>
														<td class="databaseListItem">
															<asp:requiredfieldvalidator id="LengthRequiredFieldValidator" runat="server" ErrorMessage=" Must specify a length (or specify 0 for non-length datatypes)." ControlToValidate="LengthTextBox" Display="Dynamic"></asp:requiredfieldvalidator>
															<asp:RangeValidator ID="LengthRangeValidator" Runat="server" ErrorMessage=" Length must be between 0 and 8000" ControlToValidate="LengthTextBox" Display="Dynamic" MaximumValue="8000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
														</td>
													</TR>
													<TR>
														<TD class="databaseListItem">Allow Null</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:CheckBox id="AllowNullCheckbox" Runat="server"></asp:CheckBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD colSpan="3" height="2"><hr>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Default Value</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="DefaultValueTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Precision</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="PrecisionTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem">
															<asp:RangeValidator ID="PrecisionRangeValidator" Runat="server" ErrorMessage=" Precision must be an integer" ControlToValidate="PrecisionTextBox" Display="Dynamic" MaximumValue="32000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
														</td>
													</TR>
													<TR>
														<TD class="databaseListItem">Scale</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="ScaleTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem">
															<asp:RangeValidator ID="ScaleRangeValidator" Runat="server" ErrorMessage=" Scale must be an integer" ControlToValidate="ScaleTextBox" Display="Dynamic" MaximumValue="32000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
														</td>
													</TR>
													<TR>
														<TD class="databaseListItem">Identity</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:CheckBox id="IdentityCheckBox" runat="server"></asp:CheckBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Identity Seed</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="IdentitySeedTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Identity Increment</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:TextBox id="IdentityIncrementTextbox" Runat="server" Columns="15"></asp:TextBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD class="databaseListItem">Is RowGuid</TD>
														<TD class="databaseListItem" width="25">&nbsp;</TD>
														<TD class="databaseListItem">
															<asp:CheckBox id="IsRowGuidCheckBox" runat="server"></asp:CheckBox>
														</TD>
														<td class="databaseListItem"></td>
													</TR>
													<TR>
														<TD colSpan="3" height="2"></TD>
														<td class="databaseListItem"></td>
													</TR>
												</TABLE>
												<br>
												<asp:Button id="UpdateButton" Runat="server" CSSClass="button" onMouseOver="this.style.color='#808080';" onMouseOut="this.style.color='#000000';" Text="Update" onclick="UpdateButton_Click"></asp:Button>
												&nbsp;
												<asp:Button id="CancelButton" Runat="server" CSSClass="button" onMouseOver="this.style.color='#808080';" onMouseOut="this.style.color='#000000';" Text="Cancel" CausesValidation="false" onclick="CancelButton_Click"></asp:Button>
												<br>
												<br>
												<asp:Label id="ErrorUpdatingColumnLabel" runat="server" Visible="False" ForeColor="red"></asp:Label>
												<!-- Column Editor END -->
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
