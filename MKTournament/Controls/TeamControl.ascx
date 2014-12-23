<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamControl.ascx.cs" Inherits="MKTournament.Controls.TeamControl" %>
<%@ Register tagPrefix="uc" tagName="TeamMemberControl" src="TeamMemberControl.ascx"%>

<div class="Team BorderSmallest">
    <asp:Repeater ID="rptTeamMembers" runat="server">
        <ItemTemplate>
            <uc:TeamMemberControl TeamMember="<%# Container.DataItem %>" runat="server"/>
        </ItemTemplate>
    </asp:Repeater>
</div>
