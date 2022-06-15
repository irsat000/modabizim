using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["urunid"] == null)
        {
            Response.Write("Bu sayfa ürün seçilmeden görüntülenemez");
            Response.End();
        }
        if (Request.QueryString["urunid"] != null)
	    {
            Urun urungetir = new UrunDao().tekurungetir(Convert.ToInt32(Request["urunid"]));
            ProductdetailBreadcrumb.Text = "<li class='breadcrumb-item'><a href='Default.aspx'>Anasayfa</a></li>" +
                "<li class='breadcrumb-item'><a href='ProductSale.aspx?anakateno=" + urungetir.Urun_marka.Altkate.Anakate.Anakateid + "'>" + urungetir.Urun_marka.Altkate.Anakate.Anakateadi + "</a></li>" +
                "<li class='breadcrumb-item'><a href='ProductSale.aspx?altkateno=" + urungetir.Urun_marka.Altkate.Altkateid + "&filtretip=" + urungetir.Urun_marka.Altkate.Filtretip + "'>" + urungetir.Urun_marka.Altkate.Altkateadi + "</a></li>"+
                "<li class='breadcrumb-item'><a href='#'>"+urungetir.Urun_baslik+"</a></li>";

            if (urungetir.Urun_gecicifiyat == -1)
            {
                ProductdetailPrice.Text = urungetir.Urun_fiyat + " TL";
            }
            else
            {
                int indirimorani = Convert.ToInt32(Math.Floor((urungetir.Urun_fiyat - urungetir.Urun_gecicifiyat) / urungetir.Urun_fiyat * 100));
                ProductdetailDiscountPercent.Text = indirimorani + "%";
                ProductdetailOldPrice.Text = urungetir.Urun_fiyat + " TL";
                ProductdetailPrice.Text = urungetir.Urun_gecicifiyat + " TL";
            }
	    }
    }
}