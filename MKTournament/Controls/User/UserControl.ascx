<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="MKTournament.Controls.UserControl" %>
<div class="Border">
	<h1>
		<asp:Label ID="lblName" runat="server" /></h1>
	<div class="BorderSmallest User">
		<asp:Image ID="imgUserAvatar" runat="server" />
	</div>
	<table class="DetailTable">
        <tr>
			<td>Tournaments Played:</td>
			<td>
				<asp:Label ID="lblTournamentsPlayed" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Tournaments Won:</td>
			<td>
				<asp:Label ID="lblTournamentsWon" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Matches Played:</td>
			<td>
				<asp:Label ID="lblMatchesPlayed" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Matches Won:</td>
			<td>
				<asp:Label ID="lblMatchesWon" runat="server"></asp:Label></td>
		</tr>
	</table>
</div>
