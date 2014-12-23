<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MKTournament.Test" %>

<%@ Register tagPrefix="uc" tagName="TeamMemberControl" src="Controls/TeamMemberControl.ascx"%>
<%@ Register tagPrefix="uc" tagName="TeamControl" src="~/Controls/TeamControl.ascx"%>
<%@ Register Src="~/Controls/PlayerAdd.ascx" TagPrefix="uc" TagName="PlayerAdd" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/User.aspx" Text="aaaa"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/User.aspx" Text="bbbb"></asp:MenuItem>
            </Items>
        </asp:Menu>
        
    </div>
    </form>
</body>
</html>
