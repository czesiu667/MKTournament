<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayerAdd.ascx.cs" Inherits="MKTournament.Controls.PlayerAdd" %>

<script>
	$(document).ready(function(){
		$(".AddUser select").each(function () {
			var img = $("option:selected", this).css("background-image");
			$(this).css("background-image", img);
		});

		$(".AddUser select").change(function () {
			var img = $("option:selected", this).css("background-image");
			$(this).css("background-image", img);
		});
	});
	function CloseAddUser(that) {
		$(that).closest(".AddUser").hide();
		return false;
	}
</script>
<div class="BlackBackground AddUser">
	<div class="BorderSmallest">
		<div id="Player1" runat="server">
			Player 1:
        <asp:DropDownList ID="ddlUser1" runat="server"></asp:DropDownList>
			<asp:DropDownList ID="ddlCaracter1" runat="server"></asp:DropDownList>
		</div>
		<div id="Player2" runat="server">
			Player 2:
			<asp:DropDownList ID="ddlUser2" runat="server"></asp:DropDownList>
			<asp:DropDownList ID="ddlCaracter2" runat="server"></asp:DropDownList>
		</div>
		<asp:LinkButton ID="Add" Text="Add" runat="server"></asp:LinkButton>
		<asp:LinkButton ID="Close" Text="Close" OnClientClick="return CloseAddUser(this);" runat="server"></asp:LinkButton>
	</div>
</div>

