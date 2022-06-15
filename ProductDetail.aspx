<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" type="text/css" href="css/productdetail.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <%Urun urungetir = new UrunDao().tekurungetir(Convert.ToInt32(Request.QueryString["urunid"]));
      UrunResimler urunresimgetir = new UrunresimDao().resimlerigetir(Convert.ToInt32(Request.QueryString["urunid"]));%>
    <nav class="breadcrumb-wrp" aria-label="breadcrumb">
        <ol class="breadcrumb">
            <asp:Literal ID="ProductdetailBreadcrumb" runat="server"></asp:Literal>
        </ol>
    </nav>
    <div class="product-detail-container">
        <div class="product-gallery-wrp">
            <div class="slick-slider-l">
                <%int resimsayac = 0;
                  if (urunresimgetir.Urunresim1 != null)
                  {%>
                <div class="product-gallery-items">
                    <img src="urunimgs/<%Response.Write(urunresimgetir.Urunresim1);%>" />
                </div>
                <%resimsayac++;
                  }%>
                <%if (urunresimgetir.Urunresim2 != null)
                  {%>
                <div class="product-gallery-items">
                    <img src="urunimgs/<%Response.Write(urunresimgetir.Urunresim2);%>" />
                </div>
                <%resimsayac++;
                  }%>
                <%if (urunresimgetir.Urunresim3 != null)
                  {%>
                <div class="product-gallery-items">
                    <img src="urunimgs/<%Response.Write(urunresimgetir.Urunresim3);%>" />
                </div>
                <%resimsayac++;
                  }%>
                <%if (urunresimgetir.Urunresim4 != null)
                  {%>
                <div class="product-gallery-items">
                    <img src="urunimgs/<%Response.Write(urunresimgetir.Urunresim4);%>" />
                </div>
                <%resimsayac++;
                  }%>
                <%if (urunresimgetir.Urunresim5 != null)
                  {%>
                <div class="product-gallery-items">
                    <img src="urunimgs/<%Response.Write(urunresimgetir.Urunresim5);%>" />
                </div>
                <%resimsayac++;
                  }%>
                <%for (int i = 0; i < 5 - resimsayac; i++){%>
                    <div class="product-gallery-items">
                        <img src="img/noimage.png" />
                    </div>
                <%}%>
            </div>
            <div class="slick-slider-r">
                <img src="urunimgs/<%Response.Write(urungetir.Urun_resim);%>" />
            </div>
        </div>
        <div class="product-detail-wrp">
            <div class="p-detail-left">
                <!--p(product) d(detail)-->
                <div class="p-d-rate">
                    <span>
                        <%for (int i = 0; i < urungetir.Urun_puan; i++)
                          {%>
                        <span class="fa fa-star checked-star"></span>
                        <%}%>
                        <%for (int i = 0; i < 5 - urungetir.Urun_puan; i++)
                          {%>
                        <span class="fa fa-star"></span>
                        <%}%>
                    </span>
                </div>
                <div class="p-d-price-wrp">
                    <div class="p-d-price-discount">
                        <div class="p-d-price-discount-percent">
                            <span>
                                <asp:Literal ID="ProductdetailDiscountPercent" runat="server"></asp:Literal>
                            </span>
                        </div>
                        <div class="p-d-price-discount-oldprice">
                            <span>
                                <asp:Literal ID="ProductdetailOldPrice" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div class="p-d-price">
                        <span>
                            <asp:Literal ID="ProductdetailPrice" runat="server"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="p-d-ring-fav-wrp">
                    <div class="p-d-ring">
                        <img src="img/ringbelloff.png" />
                    </div>
                    <div class="p-d-fav">
                        <img src="img/heartoff.png" />
                    </div>
                </div>
                <a href="ProductBasket.aspx?urunekle=<%Response.Write(urungetir.Urun_id);%>" class="p-d-addtobasket">
                    <div class="p-d-addtobasket-text">
                        <span>Sepete Ekle</span>
                    </div>
                </a>
                <%if (urungetir.Urun_ucretsizkargo == true)
                  {%>
                <div class="p-d-ucretsizkargo">
                    <img src="img/ucretsizkargo.png">
                </div>
                <%}%>
            </div>
            <div class="p-detail-right">
                <div class="p-d-top">
                    <div class="p-d-header">
                        <span>
                            <%Response.Write(urungetir.Urun_baslik);%></span>
                    </div>
                    <div class="p-d-subheader">
                        <span>
                            <%Response.Write(urungetir.Urun_altbaslik);%></span>
                    </div>
                    <div class="p-d-brand">
                        <span>
                            <%Response.Write(urungetir.Urun_marka.Markaad);%></span>
                    </div>
                </div>
                <div class="p-d-about-title">
                    <span>Ürün Bilgileri</span>
                </div>
                <div class="p-d-about-content">
                    <p>
                        <%Response.Write(urungetir.Urun_aciklama);%></p>
                </div>
            </div>
        </div>
    </div>
    <!--
    <div class="product-rating-container">
        <div class="rating-title">
            <h3 class="rating-title-header">ÜRÜN OYLARI</h3>
        </div>
        <div class="product-rate">
            <div class="rate">
                <input type="radio" id="star5" name="rate" value="5" />
                <label for="star5" title="text">5 stars</label>
                <input type="radio" id="star4" name="rate" value="4" />
                <label for="star4" title="text">4 stars</label>
                <input type="radio" id="star3" name="rate" value="3" />
                <label for="star3" title="text">3 stars</label>
                <input type="radio" id="star2" name="rate" value="2" />
                <label for="star2" title="text">2 stars</label>
                <input type="radio" id="star1" name="rate" value="1" />
                <label for="star1" title="text">1 star</label>
            </div>
        </div>
        <div class="comment-title">
            <h3 class="comment-title-header">ÜRÜN YORUMLARI</h3>
        </div>
        <div class="product-comments">
            
        </div>
    </div>
    -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomJSPlaceHolder" runat="Server">
</asp:Content>
