<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true"
    CodeFile="ProductSale.aspx.cs" Inherits="ProductSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/productsale.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="ctg-filter-container-all">
        <div class="ctg-filter-items-wrp" id="category_filters" runat="server">
            <div class="ctg-filter-items-title">
                <h4>
                    Tüm Kategoriler</h4>
            </div>
            <div class="ctg-filter-items ctg-all-categories">
                <div class="high-categories-item">
                    <a href="#" class="high-category-header" data-rel="allctg-item-giyim">Giyim</a>
                    <div class="high-category-wrp allctg-item-giyim">
                        <asp:Literal ID="KategoriLiteral_1" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="high-categories-item">
                    <a href="#" class="high-category-header" data-rel="allctg-item-disspor">Dış & Spor</a>
                    <div class="high-category-wrp allctg-item-disspor">
                        <asp:Literal ID="KategoriLiteral_2" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="high-categories-item">
                    <a href="#" class="high-category-header" data-rel="allctg-item-abiyebasortu">Abiye &
                        Başörtü</a>
                    <div class="high-category-wrp allctg-item-abiyebasortu">
                        <asp:Literal ID="KategoriLiteral_3" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="high-categories-item">
                    <asp:Literal ID="KategoriLiteral_4" runat="server"></asp:Literal>
                </div>
                <div class="high-categories-item">
                    <a href="#" class="high-category-header" data-rel="allctg-item-aksesuar">Aksesuar</a>
                    <div class="high-category-wrp allctg-item-aksesuar">
                        <asp:Literal ID="KategoriLiteral_5" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="high-categories-item">
                    <a href="#" class="high-category-header" data-rel="allctg-item-kozmetik">Kozmetik</a>
                    <div class="high-category-wrp allctg-item-kozmetik">
                        <asp:Literal ID="KategoriLiteral_6" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <!--<div class="ctg-filter-items-title">
                <h4>Deneme</h4>
            </div>
            <div class="ctg-filter-items">
            </div>-->
            <%if (Request.QueryString["altkateno"] != null || Request.QueryString["anakateno"] != null)
              {%>
            <div class="ctg-filter-items-title">
                <h4>
                    Fiyat</h4>
            </div>
            <div class="ctg-filter-items price-filter">
                <asp:TextBox ID="MinPrice" class="price-filter-txt" placeholder="Min Fiyat" runat="server"
                    autocomplete="off"></asp:TextBox>
                <div class="w15h30">
                    -</div>
                <asp:TextBox ID="MaxPrice" class="price-filter-txt" placeholder="Max Fiyat" runat="server"
                    autocomplete="off"></asp:TextBox>
                <asp:Button ID="PriceFilterButton" class="pricefilter-button" runat="server" Text="Ara"
                    OnClick="Fiyatara_Click" />
            </div>
            <div class='ctg-filter-items-title'>
                <h4>
                    Marka</h4>
            </div>
            <div class='ctg-filter-items'>
                <asp:CheckBoxList ID="markalistesi" runat="server" AutoPostBack="True">
                </asp:CheckBoxList>
            </div>
            <asp:PlaceHolder ID="filtre_placeholder" runat="server"></asp:PlaceHolder>
            <div class='ctg-filter-items-title'>
                <span>
                    <asp:CheckBox ID="ucretsizkargocheck" runat="server" OnCheckedChanged="ucretsizkargocheck_onselectedindexchanged"
                        AutoPostBack="True" Text="Ücretsiz Kargo" class="ucretsiz-kargo-check" />
                </span>
            </div>
            <%}%>
        </div>
    </div>
    <div class="product-container-all">
        <nav class="breadcrumb-wrp" aria-label="breadcrumb">
            <ol class="breadcrumb">
                <asp:Literal ID="ProductsaleBreadcrumb" runat="server"></asp:Literal>
            </ol>
            <span id="urunsayibilgisi" class="product-count-span"></span>
        </nav>
        <div class="productlist-container">
            <ul class="productlist" id="productlistsale">
                <%  ArrayList gelenurunlerinlistesi = new ArrayList();
                    int sayfano;
                    int urunsayisi = 0;
                    int sayfasayisi;
                    int kacurungetir = 18;
                    if (Request.QueryString["sayfa"] == null) sayfano = 1;
                    else sayfano = Convert.ToInt32(Request.QueryString["sayfa"]);
                    int urunbaslangic = (sayfano - 1) * kacurungetir;
                    NameValueCollection filtre = new NameValueCollection(Request.QueryString);
                    String[] filtrelistesi = { "marka[]", "minfiyat", "maxfiyat", "ucrtszkrg", "beden[]", "renk[]", "kumas[]", "boy[]", "numara[]", "form[]", "tip[]", "etki[]", "kozmetikboy[]" };
                    if (filtrelistesi.Any(filtre.AllKeys.Contains))
                    {
                        urunsayisi = 0;
                        int anakateno = -1;
                        int altkateno = -1;
                        double minfiyat = -1;
                        double maxfiyat = -1;
                        bool ucrtszkgr = false;
                        List<String> fmarkalar = new List<String>();
                        List<String> fbedenler = new List<String>();
                        List<String> frenkler = new List<String>();
                        List<String> fkumaslar = new List<String>();
                        List<String> fboylar = new List<String>();
                        List<String> fnumaralar = new List<String>();
                        List<String> fformlar = new List<String>();
                        List<String> ftipler = new List<String>();
                        List<String> fetkiler = new List<String>();
                        List<String> fkozmetikboylar = new List<String>();

                        var filtreleribul = new Action<String, List<String>>((query, liste) =>
                        {
                            if (Request.QueryString[query].Contains(","))
                            {
                                String[] filtreler = Request.QueryString[query].Split(',');
                                foreach (String filtreitem in filtreler)
                                    liste.Add(filtreitem);
                            }
                            else
                                foreach (String filtreitem in Request.QueryString.GetValues(query))
                                    liste.Add(filtreitem);
                        });
                        if (filtre.AllKeys.Contains("marka[]"))
                            filtreleribul("marka[]", fmarkalar);
                        if (filtre.AllKeys.Contains("beden[]"))
                            filtreleribul("beden[]", fbedenler);
                        if (filtre.AllKeys.Contains("renk[]"))
                            filtreleribul("renk[]", frenkler);
                        if (filtre.AllKeys.Contains("kumas[]"))
                            filtreleribul("kumas[]", fkumaslar);
                        if (filtre.AllKeys.Contains("boy[]"))
                            filtreleribul("boy[]", fboylar);
                        if (filtre.AllKeys.Contains("numara[]"))
                            filtreleribul("numara[]", fnumaralar);
                        if (filtre.AllKeys.Contains("form[]"))
                            filtreleribul("form[]", fformlar);
                        if (filtre.AllKeys.Contains("tip[]"))
                            filtreleribul("tip[]", ftipler);
                        if (filtre.AllKeys.Contains("etki[]"))
                            filtreleribul("etki[]", fetkiler);
                        if (filtre.AllKeys.Contains("kozmetikboy[]"))
                            filtreleribul("kozmetikboy[]", fkozmetikboylar);
                        if (filtre.AllKeys.Contains("minfiyat"))
                            minfiyat = Convert.ToDouble(Request.QueryString["minfiyat"]);
                        if (filtre.AllKeys.Contains("maxfiyat"))
                            maxfiyat = Convert.ToDouble(Request.QueryString["maxfiyat"]);
                        if (filtre.AllKeys.Contains("ucrtszkrg"))
                            ucrtszkgr = true;
                        if (filtre.AllKeys.Contains("anakateno"))
                            anakateno = Convert.ToInt32(Request.QueryString["anakateno"]);
                        else if (filtre.AllKeys.Contains("altkateno"))
                            altkateno = Convert.ToInt32(Request.QueryString["altkateno"]);

                        gelenurunlerinlistesi = new UrunDao().filtreliurunlerinlistesi(anakateno, altkateno, urunbaslangic, kacurungetir, fmarkalar, minfiyat, maxfiyat, ucrtszkgr, fbedenler, frenkler, fkumaslar, fboylar, fnumaralar, fformlar, ftipler, fetkiler, fkozmetikboylar);
                        urunsayisi = new UrunDao().toplamurunsayisi(anakateno, altkateno, fmarkalar, minfiyat, maxfiyat, ucrtszkgr, fbedenler, frenkler, fkumaslar, fboylar, fnumaralar, fformlar, ftipler, fetkiler, fkozmetikboylar);
                    }
                    else
                    {
                        int anakateno = -1;
                        int altkateno = -1;
                        if (filtre.AllKeys.Contains("anakateno"))
                            anakateno = Convert.ToInt32(Request.QueryString["anakateno"]);
                        else if (filtre.AllKeys.Contains("altkateno"))
                            altkateno = Convert.ToInt32(Request.QueryString["altkateno"]);

                        gelenurunlerinlistesi = new UrunDao().kateurunlerinlistesi(anakateno, altkateno, urunbaslangic, kacurungetir);
                        urunsayisi = new UrunDao().toplamurunsayisi(anakateno, altkateno);
                    }
                    foreach (Urun gelenurun in gelenurunlerinlistesi)
                    {%>
                <li class="products" id="productid-<%Response.Write(gelenurun.Urun_id);%>"><a href="ProductDetail.aspx?urunid=<%Response.Write(gelenurun.Urun_id);%>">
                    <img src="urunimgs/<%Response.Write(gelenurun.Urun_resim);%>" />
                    <div class="product-info-wrp">
                        <div class="product-info-header">
                            <span>
                                <%Response.Write(gelenurun.Urun_baslik);%></span></div>
                        <div class="product-info-subheader">
                            <span>
                                <%Response.Write(gelenurun.Urun_altbaslik);%></span></div>
                        <div class="product-info-price">
                            <%if (gelenurun.Urun_gecicifiyat == -1)
                              {%>
                            <span class="productsale-price-span">
                                <%Response.Write(String.Format("{0:0.00}", gelenurun.Urun_fiyat));%>
                                TL</span>
                            <%}
                              else
                              {%>
                            <span class="productsale-price-span">
                                <%Response.Write(String.Format("{0:0.00}", gelenurun.Urun_gecicifiyat));%>
                                TL</span> <span class="no-discount">
                                    <%Response.Write(String.Format("{0:0.00}", gelenurun.Urun_fiyat));%>
                                    TL</span>
                            <%}%>
                        </div>
                        <div class="product-info-ucretsizkargo">
                            <span>
                                <%if (gelenurun.Urun_ucretsizkargo == true)
                                  {%>Ücretsiz Kargo<%} %></span></div>
                    </div>
                </a></li>
                <%}
                    if (urunsayisi % kacurungetir == 0) sayfasayisi = urunsayisi / kacurungetir;
                    else sayfasayisi = urunsayisi / kacurungetir + 1;
                    //Response.Write(urunsayisi + " / " + sayfasayisi);
                    Response.Write("<script>$('#urunsayibilgisi').html('" + urunsayisi + " ürün / " + sayfasayisi + " sayfa');</script>");
                %>
            </ul>
        </div>
        <div class="productlist-paging-wrp">
            <ul>
                <%
                    String sayfadegis;
                    int oncekisayfa = sayfano - 1;
                    int sonrakisayfa = sayfano + 1;
                    if (Request.RawUrl.Contains("sayfa"))
                        sayfadegis = Request.RawUrl.Replace("sayfa=" + sayfano, "sayfa=");
                    else
                    {
                        if (Request.QueryString.Count > 0)
                            sayfadegis = Request.RawUrl + "&sayfa=";
                        else
                            sayfadegis = Request.RawUrl + "?sayfa=";
                    }
                %>
                <%if (sayfano > 1)
                  {%>
                <li class="paging-prevv-btn"><a href="<%Response.Write(sayfadegis);%>1"><<</a></li>
                <li class="paging-prev-btn"><a href="<%Response.Write(sayfadegis+oncekisayfa);%>"><</a></li>
                <%if (sayfano - 3 > 1 && sayfasayisi > 8)
                  {%>
                <li><span>...</span></li>
                <%}
                  }
                  for (int i = 1; i <= sayfasayisi; i++)
                  {
                      if (sayfasayisi > 8)
                      {
                          if (i > sayfano - 4 && i < sayfano + 4)
                          {
                              if (sayfano == i)
                              {%>
                <li><a href="<%Response.Write(sayfadegis+i);%>" class="paging-current-btn">
                    <%Response.Write(i);%></a></li>
                <%}
                              else
                              {%>
                <li><a href="<%Response.Write(sayfadegis+i);%>">
                    <%Response.Write(i);%></a></li>
                <%}
                          }
                      }
                      else
                      {
                          if (sayfano == i)
                          {%>
                <li><a href="<%Response.Write(sayfadegis+i);%>" class="paging-current-btn">
                    <%Response.Write(i);%></a></li>
                <%}
                          else
                          {%>
                <li><a href="<%Response.Write(sayfadegis+i);%>">
                    <%Response.Write(i);%></a></li>
                <%}
                      }
                  }
                  if (sayfano < sayfasayisi)
                  {
                      if (sayfano + 3 < sayfasayisi && sayfasayisi > 8)
                      {
                          if (sayfano + 3 == sayfasayisi - 3)
                          {%>
                <li><a href="<%Response.Write(sayfadegis+(sayfasayisi-2));%>">
                    <%Response.Write(sayfasayisi - 2);%></a></li>
                <%}
                          else if (sayfano + 3 != sayfasayisi - 2 && sayfano + 3 < sayfasayisi - 2)
                          {%>
                <li><span>...</span></li>
                <%}
                          if (sayfano + 3 != sayfasayisi - 1)
                          {%>
                <li><a href="<%Response.Write(sayfadegis+(sayfasayisi-1));%>">
                    <%Response.Write(sayfasayisi - 1);%></a></li>
                <%}%>
                <li><a href="<%Response.Write(sayfadegis+sayfasayisi);%>">
                    <%Response.Write(sayfasayisi);%></a></li>
                <%}%>
                <li class="paging-next-btn"><a href="<%Response.Write(sayfadegis+sonrakisayfa);%>">></a></li>
                <li class="paging-nextt-btn"><a href="<%Response.Write(sayfadegis+sayfasayisi);%>">>></a></li>
                <%}%>
            </ul>
        </div>
    </div>
    <asp:Label class="selectedcategories" ID="selectedcate" runat="server"></asp:Label>
    <asp:Label class="selectedcategories" ID="opencategory" runat="server"></asp:Label>
    <asp:Label class="selectedcategories" ID="openhighcategory" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomJSPlaceHolder" runat="Server">
    <script type="text/javascript">
        $(".high-category-header").click(function () {
            var thisheader = this;
            var x = this.getAttribute('data-rel');
            var y = document.getElementsByClassName(x)[0];
            var dynamictimer = 0;
            $(".category-items-wrp").removeClass("c-i-w-visible c-i-w-visible-for0 c-i-w-visible-for1 c-i-w-visible-for2 c-i-w-visible-for3");
            $(".c-i-w-visible2").not(y).each(function () {
                $(".high-category-wrp").removeClass("c-i-w-visible2");
                if (!$(y).hasClass("c-i-w-visible2")) {
                    dynamictimer = 400;
                }
            });
            $(".category-header").removeClass("accordionminus-on");
            $(".accordionarrow-on").not(thisheader).each(function () {
                $(".high-category-header").removeClass("accordionarrow-on");
            });
            setTimeout(function () {
                $(y).toggleClass("c-i-w-visible2");
                $(thisheader).toggleClass("accordionarrow-on");
            }, dynamictimer);
        });

        $(".category-header").click(function () {
            var thisheader = this;
            var x = this.getAttribute('data-rel');
            var y = document.getElementsByClassName(x)[0];
            var dynamictimer = 0;
            $(".c-i-w-visible-for0, .c-i-w-visible-for1, .c-i-w-visible-for2, .c-i-w-visible-for3, .c-i-w-visible").not(y).each(function () {
                $(".category-items-wrp").removeClass("c-i-w-visible c-i-w-visible-for0 c-i-w-visible-for1 c-i-w-visible-for2 c-i-w-visible-for3");
                if (!$(y).hasClass("c-i-w-visible-for0", "c-i-w-visible-for1", "c-i-w-visible-for2", "c-i-w-visible-for3", "c-i-w-visible")) {
                    dynamictimer = 400;
                }
            });
            setTimeout(function () {
                $(".accordionminus-on").not(thisheader).each(function () {
                    $(".category-header").removeClass("accordionminus-on");
                });
                $(y).toggleClass("c-i-w-visible");
                $(thisheader).toggleClass("accordionminus-on");
            }, dynamictimer);
        });
        $(document).ready(function() {
        <%if (Request["anakateno"] != null || Request["altkateno"] != null) {%>
            var openhighcategory = $("#ContentPlaceHolder_openhighcategory").text();
            $('.'+openhighcategory).siblings(".high-category-header").addClass("accordionarrow-on");
            $('.'+openhighcategory).addClass('c-i-w-visible2');
            var opencategory = $("#ContentPlaceHolder_opencategory").text();
            $('.'+opencategory).siblings(".category-header").addClass("accordionminus-on");
            $('.'+opencategory).addClass('c-i-w-visible');
            <%if (Request["altkateno"] != null) {%>
                var selectedcategory = $("#ContentPlaceHolder_selectedcate").text();
                $('*[data-subcate="'+selectedcategory+'"]').addClass("subcategory-on");
            <%}
        }%>
        });
    </script>
</asp:Content>
