<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScoreBoardControl.ascx.cs" Inherits="MKTournament.Controls.ScoreBoardControl" %>
<%@ Register Src="~/Controls/TeamControl.ascx" TagPrefix="uc" TagName="TeamControl" %>

<div class="BorderSmallest ScoreBoard">
    <asp:Repeater ID="rptScoreBoard" runat="server">
        <HeaderTemplate>
            <table class="ScoreTable">
                <tr>
                    <td></td>
                    <td>Score:
                    </td>
                    <td>Matches Won:
                    </td>
                    <td>Matches Lost:
                    </td>
                    </td>
                    <td>Matches Remain:
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <uc:TeamControl runat="server" ID="TeamControl" Team="<%# Container.DataItem %>" />
                </td>
                <td><%# ((DAL.TeamInfo)Container.DataItem).Score.ToString() %>
                </td>
                <td><%# ((DAL.TeamInfo)Container.DataItem).MatchesWon.ToString() %>
                </td>
                <td><%# ((DAL.TeamInfo)Container.DataItem).MatchesLost.ToString() %>
                </td>
                <td><%# ((DAL.TeamInfo)Container.DataItem).MatchesRemain.ToString() %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
