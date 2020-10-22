<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LoginRolePicker.ascx.cs" Inherits="SqlAdmin.Controls.ItemPicker" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border=0 cellspacing=0 cellpadding=0>
	<tr>
		<tr class="tableItems">
			<td>
				Available Logins:
			</td>
			<td>
				&nbsp;
			</td>
			<td>
				Assigned Logins:
			</td>
		</tr>
		<tr>	
			<td class="databaseListItem">
				<asp:ListBox
					id="ItemsBox"
					Runat="server"
				/>
			</td>
			<td class="databaseListItem">
				<asp:Button
					Text="<<<"
					OnClick="RemoveItem_Click"
					Runat="server"
				/>
				<br/>
				<asp:Button
					Text=">>>"
					OnClick="AddItem_Click"
					Runat="server"
				/>
			</td>
			<td class="databaseListItem">
				<asp:ListBox
					id="SelectedItemsBox"
					Runat="server"
				/>
			</td>
		</tr>
	</table>