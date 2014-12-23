<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TournamentControl.ascx.cs" Inherits="MKTournament.TournamentControl" %>
<%@ Register TagPrefix="uc" TagName="TeamControl" Src="~/Controls/TeamControl.ascx" %>
<%@ Register Src="~/Controls/PlayerAdd.ascx" TagPrefix="uc" TagName="PlayerAdd" %>
<%@ Register Src="~/Controls/OpenTournamentConfirm.ascx" TagPrefix="uc" TagName="OpenTournamentConfirm" %>


<script>
	function ShowAddPlayer(that) {
		var picker = $(that).siblings(".AddUser");
		picker.show();
		return false;
	}

	function OpenTournament(that) {
		var picker = $(that).siblings(".OpenTournament");
		picker.show();
		return false;
	}
</script>

<div class="Border">

	<h1>
		<asp:Label ID="Name" runat="server"></asp:Label></h1>
	<ul class="MenuHorizontal">
		<li>
			<asp:LinkButton ID="Menu1" runat="server" />
			<uc:OpenTournamentConfirm runat="server" Tournament="<%# Tournament %>" id="OpenTournamentConfirm" />
		</li>
		<li>
			<asp:LinkButton ID="Menu2" runat="server" />
			<uc:PlayerAdd runat="server" ID="PlayerAddControl" Tournament="<%# Tournament %>" />
		</li>
		<li>
			<asp:LinkButton ID="Menu3" runat="server" />
		</li>
		<li class="MenuHorizontalAfter"></li>
	</ul>

	<table class="DetailTable">
		<tr>
			<td>Status:</td>
			<td>
				<asp:Label ID="Status" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Type:</td>
			<td>
				<asp:Label ID="Type" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Start Date:</td>
			<td>
				<asp:Label ID="StartDate" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>End Date:</td>
			<td>
				<asp:Label ID="EndDate" runat="server"></asp:Label></td>
		</tr>
	</table>
	<table class="DetailTable">
		<tr>
			<td>Players Count:</td>
			<td>
				<asp:Label ID="TeamsCount" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Matches Count:</td>
			<td>
				<asp:Label ID="MatchesCount" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Matches Left:</td>
			<td>
				<asp:Label ID="MatchesLeft" runat="server"></asp:Label></td>
		</tr>
	</table>
	<div class="Winner">
		<uc:TeamControl ID="Winner" runat="server" />
	</div>

	<div class="Players">
		<asp:Repeater ID="rptTeamMembers" runat="server">
			<ItemTemplate>
				<uc:TeamControl Team="<%# Container.DataItem %>" runat="server" />
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>

