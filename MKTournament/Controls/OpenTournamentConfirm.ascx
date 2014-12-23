<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenTournamentConfirm.ascx.cs" Inherits="MKTournament.Controls.OpenTournamentConfirm" %>

<div class="BlackBackground OpenTournament">
	<div class="BorderSmallest">
		Are you sure you want to close this tournament?<br />
		All matches will be lost.
		<ul class="MenuHorizontal">
		<li>
			<asp:LinkButton ID="Menu1" runat="server" />
		</li>
		<li>
			<asp:LinkButton ID="Menu2" runat="server" />
		</li>
		<li class="MenuHorizontalAfter"></li>
	</ul>
	</div>
</div>
