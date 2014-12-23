<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPickerControl.ascx.cs" Inherits="MKTournament.Controls.UserPickerControl" %>
<%--usun to--%>
<script src="scripts/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>

<script>
    function ShowUserPicker(that) {
        var picker = $(that).parent().next();
        picker.toggle();
        return false;
    }
    function SelectUser(that) {
        $(that).closest(".UserPicker").prev().children().first().val($(that).attr("UserID")).attr("src", $(that).attr("src"));
        $(that).closest(".UserPicker").prev().children().first().next().val($(that).attr("UserID"));
        CloseUserPicker(that);
        return false;
    }

    function CloseUserPicker(that) {
        $(that).closest(".UserPicker").hide();
        return false;
    }


    $(".UserPicker input").hover(function () {
        $(".UserPicker .HeaderSmall").text(($(this).attr("UserName")));
    });
</script>

<div class="inline">
    <asp:ImageButton CssClass="PickedUser" ImageUrl="~/Images/Characters/None.png" OnClientClick="return ShowUserPicker(this);" runat="server" />
    <asp:HiddenField ID="SelectedUser" runat="server"/>
</div>
<div class="UserPicker">
    <div class="MainBorder">
        <h1 class="HeaderSmall">ssss</h1>
        <asp:Repeater ID="rptCharacterPicker" runat="server">
            <ItemTemplate>
                <asp:ImageButton ID="UserIcon" UserID="<%# ((DAL.UserInfo)Container.DataItem).UserID  %>" UserName="<%#((DAL.UserInfo)Container.DataItem).Name  %>" ImageUrl="<%# ((DAL.UserInfo)Container.DataItem).AvatarPath  %>" OnClientClick="return SelectUser(this);" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        <ul class="MenuHorizontal">
            <li>
                <asp:LinkButton Text="Close" OnClientClick="return CloseUserPicker(this);" runat="server" />
            </li>
        </ul>
    </div>
</div>
