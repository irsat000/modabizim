using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ProductBasket : System.Web.UI.Page
{
    ArrayList sepettekiurunler = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Request.QueryString["urunekle"] != null)
            {
                int urunid = Convert.ToInt32(Request.QueryString["urunekle"]);
                Urun eklenecekurun = new UrunDao().tekurungetir(urunid);
                if (Session["sepet"] != null)
                {
                    sepettekiurunler = (ArrayList)Session["sepet"];
                }
                bool kontrol = false;
                int j = 0;
                foreach (Sepet sepettekiurun in sepettekiurunler)
                {
                    if (sepettekiurun.Urun.Urun_id == urunid)
                    {
                        ((Sepet)sepettekiurunler[j]).Adet++;
                        kontrol = true;
                    }
                    j++;
                }
                if (kontrol == false)
                {
                    Sepet sepeteeklenecekurun = new Sepet();
                    sepeteeklenecekurun.Urun = eklenecekurun;
                    sepeteeklenecekurun.Adet = 1;
                    sepettekiurunler.Add(sepeteeklenecekurun);
                }
                Session["sepet"] = sepettekiurunler;
            }
        }
        if (Session["sepet"] != null)
        {
            sepettekiurunler = (ArrayList)Session["sepet"];
            sepetyazdir();
            Session["sepet"] = sepettekiurunler;
        }
    }
    protected void sepetyazdir()
    {
        foreach (Sepet gelenurun in sepettekiurunler)
        {
            TableRow productitem = new TableRow();
            productitem.TableSection = TableRowSection.TableBody;
            productitem.Attributes.Add("class", "bl-item");
            for (int i = 0; i < 4; i++)
            {
                TableCell productcell = new TableCell();
                switch (i)
                {
                    case 0:
                        productcell.Attributes.Add("class", "blitem-urun");
                        Panel urunanaresimwrp = new Panel();
                        urunanaresimwrp.CssClass = "blitem-img-wrp";
                        HyperLink anaresimurunlink = new HyperLink();
                        anaresimurunlink.NavigateUrl = "ProductDetail.aspx?urunid=" + gelenurun.Urun.Urun_id;
                        Image urunanaresim = new Image();
                        urunanaresim.ImageUrl = "urunimgs/" + gelenurun.Urun.Urun_resim;
                        anaresimurunlink.Controls.Add(urunanaresim);
                        urunanaresimwrp.Controls.Add(anaresimurunlink);
                        productcell.Controls.Add(urunanaresimwrp);
                        Panel urundetaywrp = new Panel();
                        urundetaywrp.CssClass = "blitem-detail";
                        Panel blitem_title = new Panel();
                        HyperLink spanbaslik = new HyperLink();
                        spanbaslik.Text = gelenurun.Urun.Urun_baslik;
                        spanbaslik.NavigateUrl = "ProductDetail.aspx?urunid=" + gelenurun.Urun.Urun_id;
                        blitem_title.Controls.Add(spanbaslik);
                        blitem_title.CssClass = "blitem-title";
                        Panel blitem_subtitle = new Panel();
                        Label spanaltbaslik = new Label();
                        spanaltbaslik.Text = gelenurun.Urun.Urun_altbaslik;
                        blitem_subtitle.Controls.Add(spanaltbaslik);
                        blitem_subtitle.CssClass = "blitem-subtitle";
                        Panel blitem_brand = new Panel();
                        Label spanmarka = new Label();
                        spanmarka.Text = gelenurun.Urun.Urun_marka.Markaad;
                        blitem_brand.Controls.Add(spanmarka);
                        blitem_brand.CssClass = "blitem-brand";
                        Panel blitem_ucretsizkargo = new Panel();
                        Image ucretsizkargo = new Image();
                        ucretsizkargo.ImageUrl = "img/ucretsizkargo2.png";
                        blitem_ucretsizkargo.Controls.Add(ucretsizkargo);
                        blitem_ucretsizkargo.CssClass = "blitem-ucretsizkargo";
                        Panel blitem_indirimliurun = new Panel();
                        Image indirimliurun = new Image();
                        indirimliurun.ImageUrl = "img/indirimliurun.png";
                        blitem_indirimliurun.Controls.Add(indirimliurun);
                        blitem_indirimliurun.CssClass = "blitem-indirimliurun";
                        urundetaywrp.Controls.Add(blitem_title);
                        urundetaywrp.Controls.Add(blitem_subtitle);
                        urundetaywrp.Controls.Add(blitem_brand);
                        if (gelenurun.Urun.Urun_ucretsizkargo == true)
                            urundetaywrp.Controls.Add(blitem_ucretsizkargo);
                        if (gelenurun.Urun.Urun_gecicifiyat != -1)
                            urundetaywrp.Controls.Add(blitem_indirimliurun);
                        productcell.Controls.Add(urundetaywrp);
                        break;
                    case 1:
                        productcell.Attributes.Add("class", "blitem-adet");
                        TextBox adet = new TextBox();
                        adet.ID = "adettxt_urun_" + gelenurun.Urun.Urun_id;
                        adet.Text = gelenurun.Adet.ToString();
                        adet.AutoPostBack = true;
                        adet.TextChanged += (sender2, e2) => adet_TextChanged(sender2, e2, adet.ID);
                        adet.CssClass = "product-quantity-txt";
                        adet.Attributes.Add("type", "number");
                        adet.Attributes.Add("min", "1");
                        adet.Attributes.Add("max", "20");
                        LinkButton uruncikar = new LinkButton();
                        uruncikar.Command += (sender2, e2) => uruncikar_Click(sender2, e2, gelenurun.Urun.Urun_id);
                        uruncikar.Text = "Çıkar";
                        uruncikar.ID = "sepettenuruncikar_" + gelenurun.Urun.Urun_id;
                        uruncikar.Attributes.Add("class", "blitem-clearone");
                        productcell.Controls.Add(adet);
                        productcell.Controls.Add(uruncikar);
                        break;
                    case 2:
                        productcell.Attributes.Add("class", "blitem-birimfiyat");
                        Label spaneskifiyat = new Label();
                        Label spanbirimfiyat = new Label();
                        if (gelenurun.Urun.Urun_gecicifiyat == -1)
                        {
                            spanbirimfiyat.Text = gelenurun.Urun.Urun_fiyat + " TL";
                            productcell.Controls.Add(spanbirimfiyat);
                        }
                        else
                        {
                            spaneskifiyat.Text = gelenurun.Urun.Urun_fiyat + " TL<br />";
                            spaneskifiyat.CssClass = "oldprice";
                            spanbirimfiyat.Text = gelenurun.Urun.Urun_gecicifiyat + " TL";
                            productcell.Controls.Add(spaneskifiyat);
                            productcell.Controls.Add(spanbirimfiyat);
                        }
                        break;
                    case 3:
                        productcell.Attributes.Add("class", "blitem-fiyat");
                        Label adettoplamfiyat = new Label();
                        if (gelenurun.Urun.Urun_gecicifiyat == -1)
                            adettoplamfiyat.Text = (gelenurun.Urun.Urun_fiyat * gelenurun.Adet).ToString();
                        else
                            adettoplamfiyat.Text = (gelenurun.Urun.Urun_gecicifiyat * gelenurun.Adet).ToString();
                        adettoplamfiyat.Text += " TL";
                        productcell.Controls.Add(adettoplamfiyat);
                        break;
                    default:
                        break;
                }
                productitem.Cells.Add(productcell);
            }
            Basket_list.Rows.Add(productitem);
        }
    }
    protected void adet_TextChanged(object sender, EventArgs e, String degisecekurunid)
    {
        int sira = 0;
        foreach (Sepet gelenurun in sepettekiurunler)
        {
            if (gelenurun.Urun.Urun_id == Convert.ToInt32(degisecekurunid.Replace("adettxt_urun_", "")))
                ((Sepet)sepettekiurunler[sira]).Adet = Convert.ToInt32(((TextBox)Basket_list.FindControl(degisecekurunid)).Text);
            TableRow rw = Basket_list.Rows[1];
            Basket_list.Rows.Remove(rw);
            sira++;
        }
        Session["sepet"] = sepettekiurunler;
        sepetyazdir();
    }
    protected void clearallcart_Click(object _sender, EventArgs _args)
    {
        if (Session["sepet"] != null)
            Session.Remove("sepet");
        else
            Response.Redirect(Request.RawUrl);
    }
    protected void uruncikar_Click(object _sender, EventArgs _args, int urunid)
    {
        if (Session["sepet"] != null)
            sepettekiurunler = (ArrayList)Session["sepet"];
        int cikarilacakurunid = urunid;
        int urunsirasi = 0;
        foreach (Sepet urun in sepettekiurunler)
        {
            if (urun.Urun.Urun_id == cikarilacakurunid)
            {
                sepettekiurunler.Remove(urun);
                break;
            }
            urunsirasi++;
        }
        if (sepettekiurunler.Count > 0)
            Session["sepet"] = sepettekiurunler;
        else
            Session.Remove("sepet");
        Response.Redirect("ProductBasket.aspx");
    }
    protected void buyallcart_Click(object _sender, EventArgs _args)
    {
        if (Session["uyeid"] != null)
        {
            int uyeid = Convert.ToInt32(Session["uyeid"]);
            int siparis = new SiparisDao().siparisekle(sepettekiurunler, uyeid);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Sipariş başarılı');}", true);
        }
        else Response.Write(@"<script language='javascript'>alert('Bu işlemi yapabilmek için önce giriş yapmalısınız!')</script>");
    }
}