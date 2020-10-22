<%@ Control Language="c#" Inherits="SqlWebAdmin.ServerToolbar" CodeFile="ServerToolbar.ascx.cs" %>

<table cellSpacing="0" cellPadding="0" width="148" border="0" style="TABLE-LAYOUT: fixed">
	<tr>
		<td height="12">
			&nbsp;
		</td>
	</tr>
	<!-- SECTION HEADING: START -->
	<tr>
		<td class="menuHeader">
			SERVER TOOLS
		</td>
	</tr>
	<!-- SECTION HEADING: END -->
	<!-- SECTION ITEM: START -->
	<tr>
		<!--BEGIN ONE LINE-->
		<td height="3" valign="middle"><img src="images/blue_dotted_line.gif" width="150" height="3" alt="" border="0"></td>
		<!--END ONE LINE-->
	</tr>
	<tr>
		<td id="DatabasesTd" height="20" runat="server">
			<asp:HyperLink id="DatabasesHyperLink" CssClass="leftMenu" onMouseOver="this.style.color='#ffffff';"
				onMouseOut="this.style.color='#000000';" runat="server"><img src="images/db_ico.gif" align="Absmiddle" border=0>&nbsp;Databases</asp:HyperLink>
		</td>
	</tr>
	<!-- SECTION ITEM: END -->
	<!-- SECTION ITEM: START -->
	<tr>
		<td id="ImportTd" height="20" runat="server">
			<asp:HyperLink id="ImportHyperLink" CssClass="leftMenu" onMouseOver="this.style.color='#ffffff';"
				onMouseOut="this.style.color='#000000';" runat="server"><img src="images/wizards_ico.gif" align="Absmiddle" border=0>&nbsp;Import</asp:HyperLink>
		</td>
	</tr>
	<!-- SECTION ITEM: END -->
	<!-- SECTION ITEM: START -->
	<tr>
		<td id="ExportTd" height="20" runat="server">
			<asp:HyperLink id="ExportHyperLink" CssClass="leftMenu" onMouseOver="this.style.color='#ffffff';"
				onMouseOut="this.style.color='#000000';" runat="server"><img src="images/wizards_ico.gif" align="Absmiddle" border=0>&nbsp;Export</asp:HyperLink>
		</td>
	</tr>
	<!-- SECTION ITEM: END -->
	<!-- SECTION ITEM: START -->
	<tr>
		<td id="SecurityTd" height="20" runat="server">
			<asp:HyperLink id="SecurityHyperLink" CssClass="leftMenu" onMouseOver="this.style.color='#ffffff';"
				onMouseOut="this.style.color='#000000';" runat="server"><img src="images/serverroles_ico.gif" align="Absmiddle" border=0>&nbsp;Security</asp:HyperLink>
		</td>
	</tr>
	<!-- SECTION ITEM: END -->
</table>
