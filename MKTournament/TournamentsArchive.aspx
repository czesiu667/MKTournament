<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TournamentsArchive.aspx.cs" Inherits="MKTournament.TournamentsArchive" %>
<%@ Register src="~/Controls/Tournament/TournamentControl.ascx" tagPrefix="uc" tagName="TournamentControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<asp:Repeater ID="rptTournamentsClosed" runat="server">
        <HeaderTemplate>
            <h1 class="Header"> Tournaments: Closed</h1>
        </HeaderTemplate>
		<ItemTemplate>
			<uc:TournamentControl Tournament="<%# Container.DataItem %>" runat="server"></uc:TournamentControl>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
