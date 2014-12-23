<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="MKTournament.User" %>

<%@ Register Src="~/Controls/User/UserControl.ascx" TagPrefix="uc" TagName="UserControl" %>
<%@ Register Src="~/Controls/User/NewUserControl.ascx" TagPrefix="uc" TagName="NewUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc:NewUserControl runat="server" ID="NewUserControl" />
    <asp:Repeater ID="rptUsers" runat="server">
        <ItemTemplate>
            <uc:UserControl runat="server" User="<%# Container.DataItem %>"  ID="ucUserControl" />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
