﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APUrunListele.aspx.cs" Inherits="APUrunListele" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Table ID="urunlisteletable" runat="server" align="center">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Başlık</asp:TableCell>
                <asp:TableCell runat="server">Alt başlık</asp:TableCell>
                <asp:TableCell runat="server">Fiyat</asp:TableCell>
                <asp:TableCell runat="server">Marka</asp:TableCell>
                <asp:TableCell runat="server">Guncelle</asp:TableCell>
                <asp:TableCell runat="server">Sil</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    </div>
    </form>
</body>
</html>
