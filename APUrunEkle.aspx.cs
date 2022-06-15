using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

public partial class APUrunEkle : System.Web.UI.Page
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Redirect("Adminpanelgiris.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ArrayList katelistesi = new KategoriDao().tumanakategoriler();
            int i = 1;
            foreach (Kategori kate in katelistesi)
            {
                kategorisec.Items.Add(kate.Anakateadi);
                kategorisec.Items[i].Value = kate.Anakateid.ToString();
                i++;
            }
        }
    }
    protected void kategorisec_SelectedIndexChanged(object sender, EventArgs e)
    {
        Control[] filtrealanlari = new Control[] { bedensec, renksec, kumassec, boysec, numarasec, formsec, tipsec, etkisec, kozboysec };
        foreach (Control filtrealani in filtrealanlari)
            filtrealani.Visible = false;
        if (kategorisec.SelectedItem.Value == "0")
        {
            altkategorisec.Items.Clear();
            altkategorisec.Items.Add("Seçiniz");
            altkategorisec.Items[0].Value = "0";
            markasec.Items.Clear();
            markasec.Items.Add("Seçiniz");
            markasec.Items[0].Value = "0";
        }
        else
        {
            altkategorisec.Items.Clear();
            altkategorisec.Items.Add("Seçiniz");
            altkategorisec.Items[0].Value = "0";
            markasec.Items.Clear();
            markasec.Items.Add("Seçiniz");
            markasec.Items[0].Value = "0";
            ArrayList altkatelistesi = new AltkategoriDao().tumaltkategoriler(Convert.ToInt32(kategorisec.SelectedItem.Value));
            int i = 1;
            foreach (Altkategori altkate in altkatelistesi)
            {
                altkategorisec.Items.Add(altkate.Altkateadi);
                altkategorisec.Items[i].Value = altkate.Altkateid.ToString();
                i++;
            }
        }
    }
    protected void altkategorisec_SelectedIndexChanged(object sender, EventArgs e)
    {
        Control[] filtrealanlari = new Control[] { bedensec, renksec, kumassec, boysec, numarasec, formsec, tipsec, etkisec, kozboysec };
        foreach (Control filtrealani in filtrealanlari)
            filtrealani.Visible = false;
        if (kategorisec.SelectedItem.Value == "0")
        {
            markasec.Items.Clear();
            markasec.Items.Add("Seçiniz");
            markasec.Items[0].Value = "0";
        }
        else
        {
            markasec.Items.Clear();
            markasec.Items.Add("Seçiniz");
            markasec.Items[0].Value = "0";
            ArrayList markalistesi = new MarkaDao().altkateyegoremarkalar(Convert.ToInt32(altkategorisec.SelectedItem.Value));
            int i = 1;
            foreach (Marka mrk in markalistesi)
            {
                markasec.Items.Add(mrk.Markaad);
                markasec.Items[i].Value = mrk.Markaid.ToString();
                i++;
            }
        }
        if (altkategorisec.SelectedItem.Value != "0")
        {
            Altkategori altkate = new AltkategoriDao().tekaltkategori(Convert.ToInt32(altkategorisec.SelectedItem.Value));
            switch (altkate.Filtretip)
            {
                case 1:
                    bedensec.Visible = true;
                    renksec.Visible = true;
                    kumassec.Visible = true;
                    boysec.Visible = true;
                    break;
                case 2:
                    bedensec.Visible = true;
                    renksec.Visible = true;
                    kumassec.Visible = true;
                    break;
                case 3:
                    renksec.Visible = true;
                    kumassec.Visible = true;
                    break;
                case 4:
                    renksec.Visible = true;
                    kumassec.Visible = true;
                    numarasec.Visible = true;
                    break;
                case 6:
                    formsec.Visible = true;
                    tipsec.Visible = true;
                    etkisec.Visible = true;
                    renksec.Visible = true;
                    break;
                case 7:
                    formsec.Visible = true;
                    tipsec.Visible = true;
                    kozboysec.Visible = true;
                    break;
                case 8:
                    formsec.Visible = true;
                    tipsec.Visible = true;
                    kozboysec.Visible = true;
                    etkisec.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
    protected void urunkaydet_Click(object sender, EventArgs e)
    {
        try
        {
            Altkategori altkate = new AltkategoriDao().tekaltkategori(Convert.ToInt32(altkategorisec.SelectedItem.Value));

            String baslik = basliktxt.Text;
            String altbaslik = altbasliktxt.Text;
            int fiyat = Convert.ToInt32(fiyattxt.Text);
            int indirimlifiyat = -1;
            if (!(String.IsNullOrWhiteSpace(gecicifiyattxt.Text) || String.IsNullOrEmpty(gecicifiyattxt.Text)))
                indirimlifiyat = Convert.ToInt32(gecicifiyattxt.Text);
            bool ucretsizkargo = ucretsizkargochk.Checked;
            int urunmarka = Convert.ToInt32(markasec.SelectedItem.Value);
            int adet = Convert.ToInt32(adettxt.Text);
            String aciklama = aciklamatxt.Text;
            String resimadi = "-1";
            String resim1adi = "-1";
            String resim2adi = "-1";
            String resim3adi = "-1";
            String resim4adi = "-1";
            String resim5adi = "-1";
            if (urunresim.HasFile == true)
                resimadi = resimekle(urunresim, urunresimimg);
            if (urunresim1.HasFile == true)
                resim1adi = resimekle(urunresim1, urunresimimg1);
            if (urunresim2.HasFile == true)
                resim2adi = resimekle(urunresim2, urunresimimg2);
            if (urunresim3.HasFile == true)
                resim3adi = resimekle(urunresim3, urunresimimg3);
            if (urunresim4.HasFile == true)
                resim4adi = resimekle(urunresim4, urunresimimg4);
            if (urunresim5.HasFile == true)
                resim5adi = resimekle(urunresim5, urunresimimg5);
            if (resimadi == "-2" || resimadi == "-1" || resim1adi == "-2" || resim2adi == "-2" || resim3adi == "-2" || resim4adi == "-2" || resim5adi == "-2")
                goto resimlergirilmemis;

            Control[] filtrealanlari = new Control[] { bedensec, renksec, kumassec, boysec, numarasec, formsec, tipsec, etkisec, kozboysec };
            foreach (Control filtre in filtrealanlari)
                if (filtre is DropDownList && filtre.Visible == true)
                    if (((DropDownList)filtre).SelectedItem.Value == "0")
                        goto filtrelergirilmemis;
            int filtretip = altkate.Filtretip;
            int beden = -1;
            String renk = "-1";
            String kumas = "-1";
            int boy = -1;
            int numara = -1;
            String form = "-1";
            String tip = "-1";
            String etki = "-1";
            int kozboy = -1;
            if (bedensec.Visible == true)
                beden = Convert.ToInt32(bedensec.SelectedItem.Text);
            if (renksec.Visible == true)
                renk = renksec.SelectedItem.Text;
            if (kumassec.Visible == true)
                kumas = kumassec.SelectedItem.Text;
            if (boysec.Visible == true)
                boy = Convert.ToInt32(boysec.SelectedItem.Text);
            if (numarasec.Visible == true)
                numara = Convert.ToInt32(numarasec.SelectedItem.Text);
            if (formsec.Visible == true)
                form = formsec.SelectedItem.Text;
            if (tipsec.Visible == true)
                tip = tipsec.SelectedItem.Text;
            if (etkisec.Visible == true)
                etki = etkisec.SelectedItem.Text;
            if (kozboysec.Visible == true)
                kozboy = Convert.ToInt32(kozboysec.SelectedItem.Text);

            int uruneklekontrol = new UrunDao().urunekle(baslik, altbaslik, fiyat, indirimlifiyat, urunmarka, ucretsizkargo, adet, aciklama, resimadi, resim1adi, resim2adi, resim3adi, resim4adi, resim5adi, filtretip, beden, renk, kumas, boy, numara, form, tip, etki, kozboy);
            if (uruneklekontrol > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt başarılı!');}", true);
            }
            else if (uruneklekontrol == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt işlemi yapılırken bir hata oluştu!');}", true);
            }
            else if (uruneklekontrol == -2)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt başarısız oldu!');}", true);
            }
        resimlergirilmemis:
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Ürün resmi yüklenemediği için işlem yapılamıyor tekrar deneyiniz.');}", true);
            }
        filtrelergirilmemis:
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Filtreler girilmemiş... İşlem yapılamıyor.');}", true);
            }
        }
        catch (NullReferenceException)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Bilgiler düzgün girilmemiş*');}", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Hata!*');}", true);
        }
    }
    String resimekle(FileUpload resimupload, Image resimgoster)
    {
        String resimadi = "";
        String uzanti = Path.GetExtension(resimupload.FileName);
        if (uzanti.Equals(".jpg") || uzanti.Equals(".png") || uzanti.Equals(".jpeg"))
        {
            int sonresimno = new UrunresimDao().sonurunresimno();
            sonresimno++;
            resimadi = "urunresim_" + sonresimno + uzanti;
            resimupload.SaveAs(Server.MapPath("urunimgs/") + resimadi);
            resimgoster.ImageUrl = "urunimgs/" + resimadi;
        }
        else
            resimadi = "-2";
        return resimadi;
    }
}