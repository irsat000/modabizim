using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

public partial class APUrunListele : System.Web.UI.Page
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    ArrayList urunlistesi = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        urunlistesi = new UrunDao().tumurunlerigetirsayfasiz();
        foreach (Urun product in urunlistesi)
        {
            TableRow satir = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell hucre = new TableCell();
                hucre.BorderWidth = 1;
                hucre.BorderStyle = BorderStyle.Solid;
                switch (i)
                {
                    case 0:
                        Label baslik = new Label();
                        baslik.ID = "urunabaslik_" + product.Urun_id;
                        baslik.Text = product.Urun_baslik;
                        hucre.Controls.Add(baslik);
                        break;
                    case 1:
                        Label altbaslik = new Label();
                        altbaslik.ID = "urunaltbaslik_" + product.Urun_id;
                        altbaslik.Text = product.Urun_altbaslik;
                        hucre.Controls.Add(altbaslik);
                        break;
                    case 2:
                        Label fiyat = new Label();
                        fiyat.ID = "urunfiyat_" + product.Urun_id;
                        fiyat.Text = product.Urun_fiyat.ToString();
                        hucre.Controls.Add(fiyat);
                        break;
                    case 3:
                        Label marka = new Label();
                        marka.ID = "urunmarka_" + product.Urun_id;
                        marka.Text = product.Urun_marka.Markaad;
                        hucre.Controls.Add(marka);
                        break;
                    case 4:
                        HyperLink guncelle = new HyperLink();
                        guncelle.ID = "urunguncelle_" + product.Urun_id;
                        guncelle.Text = "Guncelle";
                        guncelle.NavigateUrl = "APUrunGuncelle.aspx?urunid=" + product.Urun_id;
                        hucre.Controls.Add(guncelle);
                        break;
                    case 5:
                        LinkButton sil = new LinkButton();
                        sil.ID = "urunsil_" + product.Urun_id;
                        sil.Text = "Sil";
                        sil.Click += (sender2, e2) => sil_Click(sender2, e2, product.Urun_id);
                        hucre.Controls.Add(sil);
                        break;
                    default:
                        break;
                }
                satir.Cells.Add(hucre);
            }
            urunlisteletable.Rows.Add(satir);
        }
    }
    protected void sil_Click(object _sender, EventArgs _args, int urunid)
    {
        bag.Open();
        try
        {
            SqlCommand komut = new SqlCommand("delete from urunler where urun_id = " + urunid, bag);
            komut.ExecuteNonQuery();
            komut = new SqlCommand("delete from urunfiltre where urun_no = " + urunid, bag);
            komut.ExecuteNonQuery();
            komut = new SqlCommand("delete from urunresimler where urun_no = " + urunid, bag);
            komut.ExecuteNonQuery();
            Response.Redirect("APUrunListele.aspx");
        }
        catch (SqlException)
        {
            Response.Redirect("APUrunListele.aspx");
        }
        catch (Exception)
        {
            Response.Write("alert('Urun silme hata ile sonuçlandı');");
            Response.Redirect("APUrunListele.aspx");
        }
        bag.Close();
    }
}