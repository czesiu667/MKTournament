<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TournamentMatches.aspx.cs" Inherits="MKTournament.TournamentMatches" %>

<%@ Register Src="~/Controls/MatchControl.ascx" TagPrefix="uc" TagName="MatchControl" %>
<%@ Register Src="~/Controls/ScoreBoardControl.ascx" TagPrefix="uc" TagName="ScoreBoardControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
            <h1 class="Header"> Scoreboard</h1>
    <uc:ScoreBoardControl runat="server" id="ScoreBoardControl" />
	<asp:Repeater ID="rptMachesOpen" runat="server">
         <HeaderTemplate>
            <h1 class="Header"> Matches: Open</h1>
        </HeaderTemplate>
		<ItemTemplate>
			<uc:MatchControl runat="server" Match="<%# Container.DataItem %>" ID="MatchControl" />
		</ItemTemplate>
	</asp:Repeater>
    <asp:Repeater ID="rptMachesClosed" runat="server">
         <HeaderTemplate>
            <h1 class="Header"> Tournaments: Played</h1>
        </HeaderTemplate>
		<ItemTemplate>
			<uc:MatchControl runat="server" Match="<%# Container.DataItem %>" ID="MatchControl" />
		</ItemTemplate>
	</asp:Repeater>
	<div class="BorderSmallest">
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
</asp:Content>
