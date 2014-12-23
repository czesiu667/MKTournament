<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewUserControl.ascx.cs" Inherits="MKTournament.Controls.NewUserControl" %>
<asp:Panel DefaultButton="btnCreate" runat="server">
    <div class="Border">
        <h1>New User</h1>
        <ul class="MenuHorizontal">
            <li>Name:
            <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
            </li>
            <li>Avatar:
            <asp:FileUpload ID="fupUserAvatar" runat="server"/>
            </li>
            <li>
                <asp:LinkButton ID="btnCreate" runat="server" Text="Create User"></asp:LinkButton>
            </li>
            <li class="MenuHorizontalAfter"></li>
        </ul>
    </div>
</asp:Panel>
