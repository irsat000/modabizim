<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APUrunGuncelle.aspx.cs" Inherits="APUrunGuncelle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .urunekletable tr td
        {
            border-top:1px solid black;
            padding:10px 0;
        }
        .style1
        {
            width: 237px;
        }
        .style10
        {
            width: 302px;
        }
        .urunekletable input
        {
            padding-left:4px;
        }
        
        .style4
        {
            width: 407px;
        }
        .style6
        {
            width: 237px;
            height: 29px;
        }
        .style11
        {
            width: 302px;
            height: 29px;
        }
        .style7
        {
            width: 407px;
            height: 29px;
        }
        .style2
        {
            width: 237px;
            height: 26px;
        }
        .style12
        {
            height: 26px;
            }
        .style5
        {
            height: 26px;
            width: 407px;
        }
        .style13
        {
            width: 237px;
            height: 80px;
        }
        .style14
        {
            width: 302px;
            height: 80px;
        }
        .style15
        {
            width: 407px;
            height: 80px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" style="width: 76%;" class="urunekletable">
            <tr>
                <td class="style1">
                    Başlık:</td>
                <td class="style10">
                    <asp:TextBox ID="basliktxt" runat="server" Height="29px" Width="272px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Alt başlık:</td>
                <td class="style10">
                    <asp:TextBox ID="altbasliktxt" runat="server" Height="29px" Width="272px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Fiyat:</td>
                <td class="style10">
                    <asp:TextBox ID="fiyattxt" runat="server" Height="29px" Width="93px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    İndirimli Fiyat:</td>
                <td class="style10">
                    <asp:TextBox ID="gecicifiyattxt" runat="server" Height="29px" Width="94px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Ucretsiz kargo:</td>
                <td class="style10">
                    <asp:CheckBox ID="ucretsizkargochk" runat="server" />
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Kategori:</td>
                <td class="style11">
                    <asp:DropDownList ID="kategorisec" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="kategorisec_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style7">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Altkategori:</td>
                <td class="style10">
                    <asp:DropDownList ID="altkategorisec" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="altkategorisec_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Marka:</td>
                <td class="style12">
                    <asp:DropDownList ID="markasec" runat="server">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Adeti:</td>
                <td class="style10">
                    <asp:TextBox ID="adettxt" runat="server" Height="29px" Width="101px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    Ana resim:</td>
                <td class="style14">
                    <asp:FileUpload ID="urunresim" runat="server" />
                </td>
                <td class="style15">
                    <asp:Image ID="urunresimimg" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Diğer resimler:</td>
                <td class="style10">
                    <asp:FileUpload ID="urunresim1" runat="server" />
                </td>
                <td class="style4">
                    <asp:Image ID="urunresimimg1" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style10">
                    <asp:FileUpload ID="urunresim2" runat="server" />
                </td>
                <td class="style4">
                    <asp:Image ID="urunresimimg2" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style10">
                    <asp:FileUpload ID="urunresim3" runat="server" />
                </td>
                <td class="style4">
                    <asp:Image ID="urunresimimg3" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td class="style10">
                    <asp:FileUpload ID="urunresim4" runat="server" />
                </td>
                <td class="style4">
                    <asp:Image ID="urunresimimg4" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td class="style10">
                    <asp:FileUpload ID="urunresim5" runat="server" />
                </td>
                <td class="style4">
                    <asp:Image ID="urunresimimg5" runat="server" Height="123px" 
                        Width="121px" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Açıklama:</td>
                <td class="style12">
                    <asp:TextBox ID="aciklamatxt" runat="server" Height="78px" TextMode="MultiLine" 
                        Width="279px"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Ürün Ek Özellikleri:</td>
                <td class="style12" colspan="2">
                    <asp:DropDownList ID="bedensec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Beden seçiniz</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="renksec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Renk seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Siyah</asp:ListItem>
                        <asp:ListItem Value="2">Mavi</asp:ListItem>
                        <asp:ListItem Value="3">Kırmızı</asp:ListItem>
                        <asp:ListItem Value="4">Yeşil</asp:ListItem>
                        <asp:ListItem Value="5">Gri</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="kumassec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Kumaş se&#231;iniz</asp:ListItem>
                        <asp:ListItem Value="1">Keten</asp:ListItem>
                        <asp:ListItem Value="2">Kot</asp:ListItem>
                        <asp:ListItem Value="3">Kadife</asp:ListItem>
                        <asp:ListItem Value="4">Deri</asp:ListItem>
                        <asp:ListItem Value="5">Naylon</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="boysec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Boy seçiniz</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="numarasec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Numara seçiniz</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="formsec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Form seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Jel</asp:ListItem>
                        <asp:ListItem Value="2">Kalem</asp:ListItem>
                        <asp:ListItem Value="3">Krem</asp:ListItem>
                        <asp:ListItem Value="4">Toz</asp:ListItem>
                        <asp:ListItem Value="5">Pudra</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="tipsec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Tip seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Komple</asp:ListItem>
                        <asp:ListItem Value="2">Mat</asp:ListItem>
                        <asp:ListItem Value="3">Parlak</asp:ListItem>
                        <asp:ListItem Value="4">Tekli</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="etkisec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Etki seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Hacim</asp:ListItem>
                        <asp:ListItem Value="2">Kıvırma</asp:ListItem>
                        <asp:ListItem Value="3">Uzatma</asp:ListItem>
                        <asp:ListItem Value="4">Uzunluk</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="kozboysec" runat="server" Visible="False">
                        <asp:ListItem Value="0">Boy seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">100</asp:ListItem>
                        <asp:ListItem Value="2">150</asp:ListItem>
                        <asp:ListItem Value="3">200</asp:ListItem>
                        <asp:ListItem Value="4">250</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Button ID="urunguncelle" runat="server" Text="Urun Kaydet" 
                        onclick="urunguncelle_Click" />
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
