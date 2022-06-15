<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminpanelgiris.aspx.cs" Inherits="Adminpanelgiris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            height: 26px;
            width: 129px;
        }
        .style3
        {}
        .style4
        {
            height: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" style="width: 39%;">
            <tr>
                <td class="style2">
                    Kullanıcı Adı:</td>
                <td class="style1">
                    <asp:TextBox ID="username" runat="server" Height="33px" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Şifre</td>
                <td>
                    <asp:TextBox ID="password" runat="server" Height="33px" TextMode="Password" 
                        Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:Button ID="admingiris" runat="server" onclick="admingiris_Click" 
                        Text="Admin Girişi" />
                    <asp:Button ID="admincikis" runat="server" onclick="admincikis_Click" 
                        Text="Çıkış" Width="76px" />
                </td>
            </tr>
            <tr>
                <td align="center" class="style4" colspan="2">
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:HyperLink ID="uruneklelink" runat="server" NavigateUrl="~/APUrunEkle.aspx">Urun ekle</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:HyperLink ID="urunlistelelink" runat="server" 
                        NavigateUrl="~/APUrunListele.aspx">Urun listele</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
