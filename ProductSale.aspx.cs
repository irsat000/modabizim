using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;

public partial class ProductSale : System.Web.UI.Page
{
    String url;
    NameValueCollection filtre = new NameValueCollection();
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    protected void Page_Load(object sender, EventArgs e)
    {
        markalistesi.SelectedIndexChanged += (sender2, e2) => urlfiltreolustur_onselectedindexchanged(sender2, e2, "marka[]", "markalistesi");
        //Filtreleri yazdırma
        if (Request.QueryString["filtretip"] != null)
        {
            /*beden;renk;kumas;boy;numara;form;tip;etki;kozmetikboy;*/
            List<CustomObjectSI> bedenler = new List<CustomObjectSI>();
            bedenler.Add(new CustomObjectSI(1));
            bedenler.Add(new CustomObjectSI(2));
            bedenler.Add(new CustomObjectSI(3));
            bedenler.Add(new CustomObjectSI(4));
            bedenler.Add(new CustomObjectSI(5));
            List<CustomObjectSI> renkler = new List<CustomObjectSI>();
            renkler.Add(new CustomObjectSI("Siyah"));
            renkler.Add(new CustomObjectSI("Mavi"));
            renkler.Add(new CustomObjectSI("Yeşil"));
            renkler.Add(new CustomObjectSI("Kırmızı"));
            renkler.Add(new CustomObjectSI("Gri"));
            List<CustomObjectSI> kumaslar = new List<CustomObjectSI>();
            kumaslar.Add(new CustomObjectSI("Keten"));
            kumaslar.Add(new CustomObjectSI("Kot"));
            kumaslar.Add(new CustomObjectSI("Kadife"));
            kumaslar.Add(new CustomObjectSI("Deri"));
            kumaslar.Add(new CustomObjectSI("Naylon"));
            List<CustomObjectSI> boylar = new List<CustomObjectSI>();
            boylar.Add(new CustomObjectSI(1));
            boylar.Add(new CustomObjectSI(2));
            boylar.Add(new CustomObjectSI(3));
            boylar.Add(new CustomObjectSI(4));
            boylar.Add(new CustomObjectSI(5));
            List<CustomObjectSI> numaralar = new List<CustomObjectSI>();
            numaralar.Add(new CustomObjectSI(1));
            numaralar.Add(new CustomObjectSI(2));
            numaralar.Add(new CustomObjectSI(3));
            numaralar.Add(new CustomObjectSI(4));
            numaralar.Add(new CustomObjectSI(5));
            List<CustomObjectSI> formlar = new List<CustomObjectSI>();
            formlar.Add(new CustomObjectSI("Jel"));
            formlar.Add(new CustomObjectSI("Kalem"));
            formlar.Add(new CustomObjectSI("Krem"));
            formlar.Add(new CustomObjectSI("Toz"));
            formlar.Add(new CustomObjectSI("Pudra"));
            List<CustomObjectSI> tipler = new List<CustomObjectSI>();
            tipler.Add(new CustomObjectSI("Komple"));
            tipler.Add(new CustomObjectSI("Mat"));
            tipler.Add(new CustomObjectSI("Parlak"));
            tipler.Add(new CustomObjectSI("Tekli"));
            List<CustomObjectSI> etkiler = new List<CustomObjectSI>();
            etkiler.Add(new CustomObjectSI("Hacim"));
            etkiler.Add(new CustomObjectSI("Kıvırma"));
            etkiler.Add(new CustomObjectSI("Uzatma"));
            etkiler.Add(new CustomObjectSI("Uzunluk"));
            List<CustomObjectSI> kozmetikboylar = new List<CustomObjectSI>();
            kozmetikboylar.Add(new CustomObjectSI(100));
            kozmetikboylar.Add(new CustomObjectSI(150));
            kozmetikboylar.Add(new CustomObjectSI(200));
            kozmetikboylar.Add(new CustomObjectSI(250));
            var filtreolustur = new Action<String, String, String, List<CustomObjectSI>>((baslik, query, kontrol, liste) =>
            {
                HtmlGenericControl filtrebaslikdiv = new HtmlGenericControl("div");
                filtrebaslikdiv.Attributes.Add("class", "ctg-filter-items-title");
                HtmlGenericControl filtrebaslikicerik = new HtmlGenericControl("h4");
                filtrebaslikicerik.InnerHtml = baslik;
                filtrebaslikdiv.Controls.Add(filtrebaslikicerik);

                HtmlGenericControl filtreicerikdiv = new HtmlGenericControl("div");
                filtreicerikdiv.Attributes.Add("class", "ctg-filter-items");

                CheckBoxList checklist = new CheckBoxList();
                checklist.ID = kontrol;
                checklist.AutoPostBack = true;
                checklist.SelectedIndexChanged += (sender2, e2) => urlfiltreolustur_onselectedindexchanged(sender2, e2, query, kontrol);

                foreach (CustomObjectSI listitem in liste)
                    checklist.Items.Add(listitem.ToString());
                filtreicerikdiv.Controls.Add(checklist);

                filtre_placeholder.Controls.Add(filtrebaslikdiv);
                filtre_placeholder.Controls.Add(filtreicerikdiv);
            });
            switch (Convert.ToInt32(Request.QueryString["filtretip"]))
            {
                case 1:
                    filtreolustur("Beden", "beden[]", "bedenlistesi", bedenler);
                    filtreolustur("Renk", "renk[]", "renklistesi", renkler);
                    filtreolustur("Kumaş", "kumas[]", "kumaslistesi", kumaslar);
                    filtreolustur("Boy", "boy[]", "boylistesi", boylar);
                    /*beden + renk + kumas + boy*/
                    break;
                case 2:
                    filtreolustur("Beden", "beden[]", "bedenlistesi", bedenler);
                    filtreolustur("Renk", "renk[]", "renklistesi", renkler);
                    filtreolustur("Kumaş", "kumas[]", "kumaslistesi", kumaslar);
                    /*beden + renk + kumas*/
                    break;
                case 3:
                    filtreolustur("Renk", "renk[]", "renklistesi", renkler);
                    filtreolustur("Kumaş", "kumas[]", "kumaslistesi", kumaslar);
                    /*renk + kumas*/
                    break;
                case 4:
                    filtreolustur("Renk", "renk[]", "renklistesi", renkler);
                    filtreolustur("Kumaş", "kumas[]", "kumaslistesi", kumaslar);
                    filtreolustur("Numara", "numara[]", "numaralistesi", kumaslar);
                    /*renk + kumas + numara*/
                    break;
                case 6:
                    filtreolustur("Form", "form[]", "formlistesi", formlar);
                    filtreolustur("Tip", "tip[]", "tiplistesi", tipler);
                    filtreolustur("Etki", "etki[]", "etkilistesi", etkiler);
                    filtreolustur("Renk", "renk[]", "renklistesi", renkler);
                    /*form + tip + etki + renk*/
                    break;
                case 7:
                    filtreolustur("Form", "form[]", "formlistesi", formlar);
                    filtreolustur("Tip", "tip[]", "tiplistesi", tipler);
                    filtreolustur("Boy", "kozmetikboy[]", "kozmetikboylistesi", kozmetikboylar);
                    /*form + tip + kozmetikboy*/
                    break;
                case 8:
                    filtreolustur("Form", "form[]", "formlistesi", formlar);
                    filtreolustur("Tip", "tip[]", "tiplistesi", tipler);
                    filtreolustur("Boy", "kozmetikboy[]", "kozmetikboylistesi", kozmetikboylar);
                    filtreolustur("Etki", "etki[]", "etkilistesi", etkiler);
                    /*form + tip + kozmetikboy + etki*/
                    break;
                default:
                    break;
            }
        }

        int[] giyimgenelkate = { 1, 2, 3, 4, 5 };
        int[] dissporgenelkate = { 6, 7 };
        int[] abiyebasortugenelkate = { 8, 9 };
        int[] ayakkabigenelkate = { 10 };
        int[] aksesuarcantagenelkate = { 11, 12 };
        int[] kozmetikgenelkate = { 13, 14, 15, 16, 17 };
        if (Page.IsPostBack == false)
        {
            //Kategorileri çekme
            ArrayList anakategorilistesi = new KategoriDao().tumanakategoriler();
            foreach (Kategori gelenkat in anakategorilistesi)
            {
                if (giyimgenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdir(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_1);
                }
                else if (dissporgenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdir(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_2);
                }
                else if (abiyebasortugenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdir(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_3);
                }
                else if (ayakkabigenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdirtekbaslik(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_4);
                }
                else if (aksesuarcantagenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdir(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_5);
                }
                else if (kozmetikgenelkate.Contains(gelenkat.Anakateid))
                {
                    kategoriyazdir(gelenkat.Anakateadi, gelenkat.Anakateid, KategoriLiteral_6);
                }
            }
            //Markaları çekme
            ArrayList gelenmarkalar;
            if (Request.QueryString["altkateno"] != null)
                gelenmarkalar = new MarkaDao().kateyegoremarkalar(Convert.ToInt32(Request.QueryString["altkateno"]), -1);
            else if (Request.QueryString["anakateno"] != null)
                gelenmarkalar = new MarkaDao().kateyegoremarkalar(-1, Convert.ToInt32(Request.QueryString["anakateno"]));
            else
                gelenmarkalar = new MarkaDao().kateyegoremarkalar(-1, -1);
            int mrksirasi = 0;
            foreach (Marka mrk in gelenmarkalar)
            {
                markalistesi.Items.Add(mrk.Markaad);
                markalistesi.Items[mrksirasi].Value = mrk.Markaid.ToString();
                mrksirasi++;
            }
            //Seçili filtreleri doldurma
            var filtreyazdir = new Action<String, String>((filtre, control) =>
            {
                if (Request.QueryString.AllKeys.Contains(filtre))
                {
                    CheckBoxList chklist = (CheckBoxList)category_filters.FindControl(control);
                    if (Request.QueryString[filtre].Contains(","))
                    {
                        String[] markalar = Request.QueryString[filtre].Split(',');
                        foreach (String istenenFiltre in markalar)
                        {
                            foreach (ListItem chkitem in chklist.Items)
                            {
                                if (chkitem.Text == istenenFiltre)
                                {
                                    chkitem.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (String istenenFiltre in Request.QueryString.GetValues(filtre))
                        {
                            foreach (ListItem chkitem in chklist.Items)
                            {
                                if (chkitem.Text == istenenFiltre)
                                {
                                    chkitem.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            });

            if (Request.QueryString.AllKeys.Contains("marka[]"))
                filtreyazdir("marka[]", "markalistesi");
            if (Request.QueryString.AllKeys.Contains("beden[]"))
                filtreyazdir("beden[]", "bedenlistesi");
            if (Request.QueryString.AllKeys.Contains("renk[]"))
                filtreyazdir("renk[]", "renklistesi");
            if (Request.QueryString.AllKeys.Contains("kumas[]"))
                filtreyazdir("kumas[]", "kumaslistesi");
            if (Request.QueryString.AllKeys.Contains("boy[]"))
                filtreyazdir("boy[]", "boylistesi");
            if (Request.QueryString.AllKeys.Contains("numara[]"))
                filtreyazdir("numara[]", "numaralistesi");
            if (Request.QueryString.AllKeys.Contains("form[]"))
                filtreyazdir("form[]", "formlistesi");
            if (Request.QueryString.AllKeys.Contains("tip[]"))
                filtreyazdir("tip[]", "tiplistesi");
            if (Request.QueryString.AllKeys.Contains("etki[]"))
                filtreyazdir("etki[]", "etkilistesi");
            if (Request.QueryString.AllKeys.Contains("kozmetikboy[]"))
                filtreyazdir("kozmetikboy[]", "kozmetikboylistesi");
            if (Request.QueryString.AllKeys.Contains("minfiyat"))
                MinPrice.Text = Request.QueryString["minfiyat"];
            if (Request.QueryString.AllKeys.Contains("maxfiyat"))
                MaxPrice.Text = Request.QueryString["maxfiyat"];
            if (Request.QueryString.AllKeys.Contains("ucrtszkrg"))
                ucretsizkargocheck.Checked = true;
        }
        if (Request.QueryString["altkateno"] != null)
        {
            Altkategori gelenaltkate = new AltkategoriDao().tekaltkategori(Convert.ToInt32(Request.QueryString["altkateno"]));
            ProductsaleBreadcrumb.Text = "<li class='breadcrumb-item'><a href='Default.aspx'>Anasayfa</a></li>" +
                "<li class='breadcrumb-item'><a href='ProductSale.aspx?anakateno=" + gelenaltkate.Anakate.Anakateid + "'>" + gelenaltkate.Anakate.Anakateadi + "</a></li>" +
                "<li class='breadcrumb-item'><a href='ProductSale.aspx?altkateno=" + gelenaltkate.Altkateid + "&filtretip=" + gelenaltkate.Filtretip + "'>" + gelenaltkate.Altkateadi + "</a></li>";

            selectedcate.Text = "ctg-item-" + gelenaltkate.Altkateid;
            opencategory.Text = "allctg-item-" + gelenaltkate.Anakate.Anakateid;
            if (giyimgenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-giyim";
            else if (dissporgenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-disspor";
            else if (abiyebasortugenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-abiyebasortu";
            else if (ayakkabigenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-ayakkabi";
            else if (aksesuarcantagenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-aksesuar";
            else if (kozmetikgenelkate.Contains(gelenaltkate.Anakate.Anakateid))
                openhighcategory.Text = "allctg-item-kozmetik";
        }
        else if (Request.QueryString["anakateno"] != null)
        {
            Kategori sayfaninanakatesi = new KategoriDao().tekanakategori(Convert.ToInt32(Request.QueryString["anakateno"]));
            ProductsaleBreadcrumb.Text = "<li class='breadcrumb-item'><a href='Default.aspx'>Anasayfa</a></li>" +
                "<li class='breadcrumb-item'><a href='ProductSale.aspx?anakateno=" + sayfaninanakatesi.Anakateid + "'>" + sayfaninanakatesi.Anakateadi + "</a></li>";

            opencategory.Text = "allctg-item-" + Request.QueryString["anakateno"];
            if (giyimgenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-giyim";
            else if (dissporgenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-disspor";
            else if (abiyebasortugenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-abiyebasortu";
            else if (ayakkabigenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-ayakkabi";
            else if (aksesuarcantagenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-aksesuar";
            else if (kozmetikgenelkate.Contains(sayfaninanakatesi.Anakateid))
                openhighcategory.Text = "allctg-item-kozmetik";
        }
        else
        {
            ProductsaleBreadcrumb.Text = "<li class='breadcrumb-item'><a href='Default.aspx'>Anasayfa</a></li>";
        }
    }
    void kategoriyazdirtekbaslik(String anakatead, int anakateid, Literal hangialan)
    {
        KategoriLiteral_4.Text +=
            "<a href='#' class='high-category-header' data-rel='allctg-item-ayakkabi'>" + anakatead + "</a>" +
            "<div class='high-category-wrp allctg-item-ayakkabi'>" +
                "<ul class='ayakkabi-subcategory-wrp'>";
        ArrayList altkategorilistesi = new AltkategoriDao().tumaltkategoriler(anakateid);
        foreach (Altkategori gelenaltkat in altkategorilistesi)
        {
            KategoriLiteral_4.Text +=
            "<li class='allctg-items-sub'>" +
                "<a href='ProductSale.aspx?altkateno=" + gelenaltkat.Altkateid + "&filtretip=" + gelenaltkat.Filtretip + "' class='category-sub-header' data-subcate='ctg-item-" + gelenaltkat.Altkateid + "'>" + gelenaltkat.Altkateadi + "</a>" +
            "</li>";
        }
        KategoriLiteral_4.Text += "</ul></div>";
    }
    void kategoriyazdir(String anakatead, int anakateid, Literal hangialan)
    {
        hangialan.Text +=
            "<div class='categories-item'>" +
                "<a href='#' class='category-header' data-rel='allctg-item-" + anakateid + "'>" + anakatead + "</a>" +
                "<ul class='category-items-wrp allctg-item-" + anakateid + "'>";
        ArrayList altkategorilistesi = new AltkategoriDao().tumaltkategoriler(anakateid);
        foreach (Altkategori gelenaltkat in altkategorilistesi)
        {
            hangialan.Text +=
            "<li class='allctg-items-sub'>" +
                "<a href='ProductSale.aspx?altkateno=" + gelenaltkat.Altkateid + "&filtretip=" + gelenaltkat.Filtretip + "' class='category-sub-header' data-subcate='ctg-item-" + gelenaltkat.Altkateid + "'>" + gelenaltkat.Altkateadi + "</a>" +
            "</li>";
        }
        hangialan.Text += "</ul></div>";
    }
    protected void Fiyatara_Click(object sender, EventArgs e)
    {
        url = Request.Path;
        filtre = new NameValueCollection(Request.QueryString);
        filtre.Remove("minfiyat");
        filtre.Remove("maxfiyat");
        urlduzelt();

        try
        {
            if (Convert.ToInt32(MinPrice.Text) >= 0 && Convert.ToInt32(MaxPrice.Text) >= 0 && Convert.ToInt32(MinPrice.Text) > Convert.ToInt32(MaxPrice.Text))
                goto pricefilterskip;
        }
        catch (FormatException)
        {
            if (!((MinPrice.Text != "" && MaxPrice.Text == "") || (MinPrice.Text == "" && MaxPrice.Text != "")))
                goto pricefilterskip;
        }
        int parsedValue;
        if (int.TryParse(MinPrice.Text, out parsedValue) && MinPrice.Text != null && Convert.ToInt32(MinPrice.Text) >= 0)
            url += "&minfiyat=" + MinPrice.Text;
        if (int.TryParse(MaxPrice.Text, out parsedValue) && MaxPrice.Text != null && Convert.ToInt32(MaxPrice.Text) >= 0)
            url += "&maxfiyat=" + MaxPrice.Text;
    pricefilterskip:
        Response.Redirect(url);
    }
    protected void ucretsizkargocheck_onselectedindexchanged(object sender, EventArgs e)
    {
        url = Request.Path;
        filtre = new NameValueCollection(Request.QueryString);
        filtre.Remove("ucrtszkrg");
        urlduzelt();

        if (ucretsizkargocheck.Checked == true)
            url += "&ucrtszkrg=true";
        Response.Redirect(url);
    }
    protected void urlfiltreolustur_onselectedindexchanged(object sender, EventArgs e, String query, String control)
    {
        url = Request.Path;
        filtre = new NameValueCollection(Request.QueryString);
        filtre.Remove(query);
        urlduzelt();

        CheckBoxList chklist = (CheckBoxList)category_filters.FindControl(control);
        List<ListItem> secililer = new List<ListItem>();
        foreach (ListItem chkitem in chklist.Items)
        {
            if (chkitem.Selected == true)
                secililer.Add(chkitem);
        }
        foreach (ListItem secili in secililer)
        {
            url += "&" + query + "=" + secili;
        }
        Response.Redirect(url);
    }
    void urlduzelt()
    {
        filtre.Remove("sayfa");
        int i = 0;
        foreach (String query in filtre)
        {
            if (i == 0)
                url += "?" + query + "=" + filtre[query];
            else
                url += "&" + query + "=" + filtre[query];
            i++;
        }
    }
}