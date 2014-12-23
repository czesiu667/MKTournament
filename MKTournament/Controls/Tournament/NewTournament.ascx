<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewTournament.ascx.cs" Inherits="MKTournament.Controls.NewTournament" %>

<div class="Border">
	<h1>New Toutnament</h1>
	<ul class="MenuHorizontal">
		<li>Name:
            <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
		</li>
		<li>Type:
            <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
		</li>
		<li>
			<asp:LinkButton ID="btnCreate" runat="server" Text="Create Tournament"></asp:LinkButton>
		</li>
		<li class="MenuHorizontalAfter"></li>
	</ul>
</div>
