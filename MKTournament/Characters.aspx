<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Characters.aspx.cs" Inherits="MKTournament.Characters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<div class="Characters">
		<div class="Border">
			<h1 class="HeaderSmall"></h1>
			<asp:Repeater ID="rptCharacterPicker" runat="server">
				<ItemTemplate>
					<a href="Characters.aspx?CharacterID=<%# ((DAL.CharacterInfo)Container.DataItem).CharacterID %>"><asp:Image ImageUrl="<%# ((DAL.CharacterInfo)Container.DataItem).AvatarPath %>" runat="server"/></a>
				</ItemTemplate>
			</asp:Repeater>
			<ul class="MenuHorizontal">
				<li>
					<asp:LinkButton Text="Close" OnClientClick="return CloseCharacterPicker(this);" runat="server" />
				</li>
			</ul>
		</div>
	</div>
	<div class="CharactersInfo">
		<div class="Border">
			<asp:MultiView ID="mvwCharacter" ActiveViewIndex="0" runat="server">
				<asp:View runat="server">
					scorpion
				</asp:View>
				<asp:View>
					aaa
				</asp:View>
				<asp:View>
					bbb
				</asp:View>
			</asp:MultiView>
		</div>
	</div>
</asp:Content>
