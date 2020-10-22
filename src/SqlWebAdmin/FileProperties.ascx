<%@ Control Language="c#" Inherits="SqlWebAdmin.FileProperties" CodeFile="FileProperties.ascx.cs" %>
<asp:CheckBox Runat="server" Text="Automatically grow file" ID="AutomaticallyGrowFileCheckBox"></asp:CheckBox>
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; File growth
<br>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList Runat="server" ID="GrowthTypeDropDownList">
    <asp:ListItem Text="In megabytes"></asp:ListItem>
    <asp:ListItem Text="By percent"></asp:ListItem>
</asp:DropDownList>
<asp:TextBox Runat="server" Columns="4" ID="GrowthTextBox"></asp:TextBox>
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; Maximum file size<br>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton Runat="server" GroupName="MaximumFileSizeType" Text="Unrestricted file growth" ID="UnrestrictedGrowthRadioButton"></asp:RadioButton><br>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton Runat="server" GroupName="MaximumFileSizeType" Text="Restrict file growth" ID="RestrictGrowthRadioButton"></asp:RadioButton>
&nbsp;<asp:TextBox Runat="server" Columns="4" ID="MaximumFileSizeTextBox"></asp:TextBox>
MB
<br>

