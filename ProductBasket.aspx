<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="ProductBasket.aspx.cs" Inherits="ProductBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" type="text/css" href="css/productbasket.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<%if (Session["sepet"] != null){%>
    <asp:Table ID="Basket_list" class="basket-list-wrp" runat="server" 
        HorizontalAlign="Center">
        <asp:TableRow class="bl-title-wrp" runat="server" TableSection="TableHeader">
            <asp:TableCell class="bl-titleurun" runat="server"><span class="bl-titles">Ürün</span></asp:TableCell>
            <asp:TableCell class="bl-titleadet" runat="server"><span class="bl-titles">Adet</span></asp:TableCell>
            <asp:TableCell class="bl-titlebirimfiyat" runat="server"><span class="bl-titles">Birim Fiyat</span></asp:TableCell>
            <asp:TableCell class="bl-titlefiyat" runat="server"><span class="bl-titles">Fiyat</span></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div class="basket-list-buyall-wrp">
        <asp:LinkButton ID="buyallcart" class="basket-list-button bl-buyall" onclick="buyallcart_Click" runat="server" PostBackUrl="~/ProductBasket.aspx">
            <span>HEPSİNİ AL</span>
        </asp:LinkButton>
        <asp:LinkButton ID="clearallcart" class="basket-list-button bl-clearall" onclick="clearallcart_Click" runat="server" PostBackUrl="~/ProductBasket.aspx">
            <span>SEPETİ TEMİZLE</span>
        </asp:LinkButton>
    </div>
<%}else{%>
    <div class="basketisnull-wrp">
        <div class="basketisnull-message">
            <span>Sepetinizde hiç ürün bulunmamaktadır.<a href="Default.aspx" class="basketmainpagelink">Hemen alışverişe başla!</a></span>
        </div>
    </div>
<%}%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomJSPlaceHolder" Runat="Server">
    <script type="text/javascript">
        jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up">+</div><div class="quantity-button quantity-down">-</div></div>').insertAfter('.blitem-adet input');
        jQuery('.blitem-adet').each(function () {
            var spinner = jQuery(this),
        input = spinner.find('input[type="number"]'),
        btnUp = spinner.find('.quantity-up'),
        btnDown = spinner.find('.quantity-down'),
        min = input.attr('min'),
        max = input.attr('max');
            btnUp.click(function () {
                var oldValue = parseFloat(input.val());
                if (oldValue >= max) {
                    var newVal = oldValue;
                } else {
                    var newVal = oldValue + 1;
                }
                spinner.find("input").val(newVal);
                spinner.find("input").trigger("change");
            });
            btnDown.click(function () {
                var oldValue = parseFloat(input.val());
                if (oldValue <= min) {
                    var newVal = oldValue;
                } else {
                    var newVal = oldValue - 1;
                }
                spinner.find("input").val(newVal);
                spinner.find("input").trigger("change");
            });
        });
    </script>
    <script type="text/javascript">
        $('.product-quantity-txt').focusout(function () {
            if (this.value > 20) this.value = "20";
            else if (this.value < 1) this.value = "1";
        });
    </script>
</asp:Content>

