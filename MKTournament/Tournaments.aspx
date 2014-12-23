<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Tournaments.aspx.cs" Inherits="MKTournament.Tournaments"%>
<%@ Register src="~/Controls/Tournament/TournamentControl.ascx" tagPrefix="uc" tagName="TournamentControl" %>
<%@ Register Src="~/Controls/Tournament/NewTournament.ascx" TagPrefix="uc" TagName="NewTournament" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:HiddenField id="Char1" runat="server" ClientIDMode="Static"/>
    <uc:NewTournament runat="server" id="NewTournament" />

	<asp:Repeater ID="rptTournamentsOpen" runat="server">
        <HeaderTemplate>
            <h1 class="Header"> Tournaments: Open</h1>
        </HeaderTemplate>
		<ItemTemplate>
			<uc:TournamentControl Tournament="<%# Container.DataItem %>" test="<%# ((DAL.TournamentInfo)Container.DataItem).TournamentID.ToString() %>" runat="server"></uc:TournamentControl>
		</ItemTemplate>
	</asp:Repeater>

    <asp:Repeater ID="rptTournamentsPending" runat="server">
        <HeaderTemplate>
            <h1 class="Header"> Tournaments: Pending</h1>
        </HeaderTemplate>
		<ItemTemplate>
			<uc:TournamentControl Tournament="<%# Container.DataItem %>" runat="server"></uc:TournamentControl>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
