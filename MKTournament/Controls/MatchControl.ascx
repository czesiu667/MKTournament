<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchControl.ascx.cs" Inherits="MKTournament.Controls.MatchControl" %>
<%@ Register Src="~/Controls/TeamControl.ascx" TagPrefix="uc" TagName="TeamControl" %>

<div class="BorderSmallest Match">
	<uc:TeamControl runat="server" Team="<%# Match.FirstTeam %>" ID="Team1" />
	<uc:TeamControl runat="server" Team="<%# Match.SecondTeam %>" ID="Team2" />
	<div>
		<asp:Image ID="Image1" ImageUrl="~/Images/Layout/vs.png" runat="server" />
		<asp:DropDownList ID="ddlResult" runat="server"></asp:DropDownList>
	</div>
</div>
