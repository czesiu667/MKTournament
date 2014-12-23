<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditTournament.aspx.cs" Inherits="MKTournament.EditTournament" %>

<%@ Register TagPrefix="uc" TagName="TeamControl" Src="~/Controls/TeamControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<div class="Border">
		
		<div class="Players">
			<asp:Repeater ID="rptTeamMembers" runat="server">
				<ItemTemplate>
					<uc:TeamControl Team="<%# Container.DataItem %>" runat="server" />
					<ul class="MenuHorizontal">
						<li><asp:Button Text="Delete" runat="server" /></li>
					</ul>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
