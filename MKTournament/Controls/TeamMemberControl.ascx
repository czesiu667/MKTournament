<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamMemberControl.ascx.cs" Inherits="MKTournament.Controls.TeamMemberControl" %>
<div class="TeamMember">
	<div>
		<asp:Image ID="Character" runat="server" />
		<asp:Image ID="UserAvatar" runat="server" />
	</div>
	<div class="HighlightBackground">
		<asp:Label ID="UserName" runat="server"></asp:Label>
	</div>
</div>
