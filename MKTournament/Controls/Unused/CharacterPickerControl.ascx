<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CharacterPickerControl.ascx.cs" Inherits="MKTournament.Controls.CharacterPickerControl" ViewStateMode="Enabled" %>
<%--usun to--%>
<script src="scripts/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>

<script>
    function ShowCharacterPicker(that) {
        var picker = $(that).parent().next();
        picker.toggle();
        return false;
    }
    function SelectCharacter(that) {
        $(that).closest(".CharacterPicker").prev().children().first().val($(that).attr("CharacterID")).attr("src", $(that).attr("src"));
        $(that).closest(".CharacterPicker").prev().children().first().next().val($(that).attr("CharacterID"));
        CloseCharacterPicker(that);
        return false;
    }

    function CloseCharacterPicker(that) {
        $(that).closest(".CharacterPicker").hide();
        return false;
    }


    $(".CharacterPicker input").hover(function () {
        $(".CharacterPicker .HeaderSmall").text(($(this).attr("CharacterName")));
    });
</script>

<div class="inline">
    <asp:ImageButton CssClass="PickedCharacter" ImageUrl="~/Images/Characters/None.png" OnClientClick="return ShowCharacterPicker(this);" runat="server" />
    <asp:HiddenField ID="SelectedCharacter" runat="server"/>
    <asp:TextBox ID="test" runat="server"></asp:TextBox>
</div>
<div class="CharacterPicker">
    <div class="MainBorder">
        <h1 class="HeaderSmall"></h1>
        <asp:Repeater ID="rptCharacterPicker" runat="server">
            <ItemTemplate>
                <asp:ImageButton ID="CharacterIcon" CharacterID="<%# ((DAL.CharacterInfo)Container.DataItem).CharacterID  %>" CharacterName="<%#((DAL.CharacterInfo)Container.DataItem).Name  %>" ImageUrl="<%# ((DAL.CharacterInfo)Container.DataItem).AvatarPath  %>" OnClientClick="return SelectCharacter(this);" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        <ul class="MenuHorizontal">
            <li>
                <asp:LinkButton Text="Close" OnClientClick="return CloseCharacterPicker(this);" runat="server" />
            </li>
        </ul>
    </div>
</div>
