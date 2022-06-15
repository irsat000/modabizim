using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for UrunDao
/// </summary>
public class UrunDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    ArrayList urunlistesi = new ArrayList();
    public ArrayList kateurunlerinlistesi(int anakateno, int altkateno, int baslangic, int kacurungetir)
    {
        String sql = "";
        if (anakateno != -1)
        {
            sql = "select * FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no where anakategoriler.anakate_id = " + anakateno;
        }
        else if (altkateno != -1)
        {
            sql = "select * FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no where altkategoriler.altkate_id = " + altkateno;
        }
        if (sql != "")
            urunyazdir(sql, baslangic, kacurungetir);
        return urunlistesi;
    }
    public ArrayList tumurunlerinlistesi(int baslangic, int kacurungetir)
    {
        String sql = "select * FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no";
        urunyazdir(sql, baslangic, kacurungetir);
        return urunlistesi;
    }
    public ArrayList filtreliurunlerinlistesi(int anakateno, int altkateno, int baslangic, int kacurungetir, List<String> fmarkalar, double minfiyat, double maxfiyat, bool ucrtszkrg, List<String> fbedenler, List<String> frenkler, List<String> fkumaslar, List<String> fboylar, List<String> fnumaralar, List<String> fformlar, List<String> ftipler, List<String> fetkiler, List<String> fkozmetikboylar)
    {
        String sql = "select * FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no where urunler.urun_id > 0";
        if (altkateno != -1)
            sql += " and altkategoriler.altkate_id = " + altkateno;
        else if (anakateno != -1)
            sql += " and anakategoriler.anakate_id = " + anakateno;
        if (fmarkalar.Count != 0)
        {
            for (int i = 0; i < fmarkalar.Count; i++)
            {
                if (fmarkalar.Count == 1)
                    sql += " and (markalar.marka_ad = '" + fmarkalar[i] + "')";
                else
                {
                    if (i == 0)
                        sql += " and (markalar.marka_ad = '" + fmarkalar[i] + "'";
                    else if (i == fmarkalar.Count - 1)
                        sql += " or markalar.marka_ad = '" + fmarkalar[i] + "')";
                    else
                        sql += " or markalar.marka_ad = '" + fmarkalar[i] + "'";
                }
            }
        }
        if (minfiyat != -1)
        {
            sql += " and " + minfiyat + " <= CASE WHEN urunler.urun_gecicifiyat IS NULL THEN urunler.urun_fiyat " +
                "ELSE urunler.urun_gecicifiyat END";
        }
        if (maxfiyat != -1)
        {
            sql += " and " + maxfiyat + " >= CASE WHEN urunler.urun_gecicifiyat IS NULL THEN urunler.urun_fiyat " +
                "ELSE urunler.urun_gecicifiyat END";
        }
        if (ucrtszkrg == true)
        {
            sql += " and urunler.urun_ucretsizkargo = 1";
        }
        var wherefiltreyaz = new Action<String, List<String>>((filtreadi, liste) =>
        {
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste.Count == 1)
                    sql += " and (urunfiltre." + filtreadi + " = '" + liste[i] + "')";
                else
                {
                    if (i == 0)
                        sql += " and (urunfiltre." + filtreadi + " = '" + liste[i] + "'";
                    else if (i == liste.Count - 1)
                        sql += " or urunfiltre." + filtreadi + " = '" + liste[i] + "')";
                    else
                        sql += " or urunfiltre." + filtreadi + " = '" + liste[i] + "'";
                }
            }
        });
        if (fbedenler.Count != 0)
            wherefiltreyaz("beden", fbedenler);
        if (frenkler.Count != 0)
            wherefiltreyaz("renk", frenkler);
        if (fkumaslar.Count != 0)
            wherefiltreyaz("kumas", fkumaslar);
        if (fboylar.Count != 0)
            wherefiltreyaz("boy", fboylar);
        if (fnumaralar.Count != 0)
            wherefiltreyaz("numara", fnumaralar);
        if (fformlar.Count != 0)
            wherefiltreyaz("koz_form", fformlar);
        if (ftipler.Count != 0)
            wherefiltreyaz("koz_tip", ftipler);
        if (fkozmetikboylar.Count != 0)
            wherefiltreyaz("koz_boy", fkozmetikboylar);
        if (fetkiler.Count != 0)
            wherefiltreyaz("koz_etki", fetkiler);

        urunyazdir(sql, baslangic, kacurungetir);
        return urunlistesi;
    }

    void urunyazdir(String sql, int baslangic, int kacurungetir)
    {
        bag.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, bag);
        DataSet ds = new DataSet();
        adapter.Fill(ds, baslangic, kacurungetir, "urunler");
        foreach (DataRow gelenurun in ds.Tables["urunler"].Rows)
        {
            Urun urungetir = new Urun();
            urungetir.Urun_id = Convert.ToInt32(gelenurun["urun_id"]);
            urungetir.Urun_baslik = gelenurun["urun_baslik"].ToString();
            urungetir.Urun_altbaslik = gelenurun["urun_altbaslik"].ToString();
            urungetir.Urun_fiyat = Convert.ToDouble(gelenurun["urun_fiyat"]);
            urungetir.Urun_aciklama = gelenurun["urun_aciklama"].ToString();
            urungetir.Urun_puan = Convert.ToDouble(gelenurun["urun_puan"]);
            urungetir.Urun_resim = gelenurun["urun_resim"].ToString();
            urungetir.Urun_ucretsizkargo = Convert.ToBoolean(gelenurun["urun_ucretsizkargo"]);
            if (gelenurun["urun_gecicifiyat"] != DBNull.Value)
                urungetir.Urun_gecicifiyat = Convert.ToDouble(gelenurun["urun_gecicifiyat"]);
            else
                urungetir.Urun_gecicifiyat = -1;
            Marka urunmarka = new Marka();
            urunmarka.Markaid = Convert.ToInt32(gelenurun["marka_id"]);
            urunmarka.Markaad = gelenurun["marka_ad"].ToString();
            Altkategori markaaltkate = new Altkategori();
            markaaltkate.Altkateid = Convert.ToInt32(gelenurun["altkate_id"]);
            markaaltkate.Altkateadi = gelenurun["altkate_ad"].ToString();
            markaaltkate.Filtretip = Convert.ToInt32(gelenurun["filtre_no"]);
            Kategori altkateanakatesi = new Kategori();
            altkateanakatesi.Anakateid = Convert.ToInt32(gelenurun["anakate_id"]);
            altkateanakatesi.Anakateadi = gelenurun["anakate_ad"].ToString();
            markaaltkate.Anakate = altkateanakatesi;
            urunmarka.Altkate = markaaltkate;
            urungetir.Urun_marka = urunmarka;
            urunlistesi.Add(urungetir);
        }
        bag.Close();
    }

    public int toplamurunsayisi(int anakate, int altkate)
    {
        int urunsayisi = 0;
        if (anakate == -1 && altkate == -1)
            goto urunhesapatla;
        bag.Open();
        String sql = "select count(*) FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no where urunler.urun_id > 0";
        if (anakate != -1)
            sql += " and anakategoriler.anakate_id = " + anakate;
        else if (altkate != -1)
            sql += " and altkategoriler.altkate_id = " + altkate;
        SqlCommand komut = new SqlCommand(sql, bag);
        urunsayisi = Convert.ToInt32(komut.ExecuteScalar());
        bag.Close();
    urunhesapatla:
        return urunsayisi;
    }
    public int toplamurunsayisi(int anakate, int altkate, List<String> fmarkalar, double minfiyat, double maxfiyat, bool ucrtszkrg, List<String> fbedenler, List<String> frenkler, List<String> fkumaslar, List<String> fboylar, List<String> fnumaralar, List<String> fformlar, List<String> ftipler, List<String> fetkiler, List<String> fkozmetikboylar)
    {
        bag.Open();
        String sql = "select count(*) FROM urunler INNER JOIN " +
                "markalar ON urunler.urun_markano = markalar.marka_id INNER JOIN " +
                "altkategoriler ON markalar.altkate_no = altkategoriler.altkate_id INNER JOIN " +
                "anakategoriler ON altkategoriler.anakate_no = anakategoriler.anakate_id FULL OUTER JOIN " +
                "urunfiltre ON urunler.urun_id = urunfiltre.urun_no where urunler.urun_id > 0";
        if (anakate != -1)
            sql += " and anakategoriler.anakate_id = " + anakate;
        else if (altkate != -1)
            sql += " and altkategoriler.altkate_id = " + altkate;
        if (fmarkalar.Count != 0)
        {
            for (int i = 0; i < fmarkalar.Count; i++)
            {
                if (fmarkalar.Count == 1)
                    sql += " and (markalar.marka_ad = '" + fmarkalar[i] + "')";
                else
                {
                    if (i == 0)
                        sql += " and (markalar.marka_ad = '" + fmarkalar[i] + "'";
                    else if (i == fmarkalar.Count - 1)
                        sql += " or markalar.marka_ad = '" + fmarkalar[i] + "')";
                    else
                        sql += " or markalar.marka_ad = '" + fmarkalar[i] + "'";
                }
            }
        }
        if (minfiyat != -1)
        {
            sql += " and " + minfiyat + " <= CASE WHEN urunler.urun_gecicifiyat IS NULL THEN urunler.urun_fiyat " +
                "ELSE urunler.urun_gecicifiyat END";
        }
        if (maxfiyat != -1)
        {
            sql += " and " + maxfiyat + " >= CASE WHEN urunler.urun_gecicifiyat IS NULL THEN urunler.urun_fiyat " +
                "ELSE urunler.urun_gecicifiyat END";
        }
        if (ucrtszkrg == true)
        {
            sql += " and urunler.urun_ucretsizkargo = 1";
        }
        var wherefiltreyaz = new Action<String, List<String>>((filtreadi, liste) =>
        {
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste.Count == 1)
                    sql += " and (urunfiltre." + filtreadi + " = '" + liste[i] + "')";
                else
                {
                    if (i == 0)
                        sql += " and (urunfiltre." + filtreadi + " = '" + liste[i] + "'";
                    else if (i == liste.Count - 1)
                        sql += " or urunfiltre." + filtreadi + " = '" + liste[i] + "')";
                    else
                        sql += " or urunfiltre." + filtreadi + " = '" + liste[i] + "'";
                }
            }
        });
        if (fbedenler.Count != 0)
            wherefiltreyaz("beden", fbedenler);
        if (frenkler.Count != 0)
            wherefiltreyaz("renk", frenkler);
        if (fkumaslar.Count != 0)
            wherefiltreyaz("kumas", fkumaslar);
        if (fboylar.Count != 0)
            wherefiltreyaz("boy", fboylar);
        if (fnumaralar.Count != 0)
            wherefiltreyaz("numara", fnumaralar);
        if (fformlar.Count != 0)
            wherefiltreyaz("koz_form", fformlar);
        if (ftipler.Count != 0)
            wherefiltreyaz("koz_tip", ftipler);
        if (fkozmetikboylar.Count != 0)
            wherefiltreyaz("koz_boy", fkozmetikboylar);
        if (fetkiler.Count != 0)
            wherefiltreyaz("koz_etki", fetkiler);

        SqlCommand komut = new SqlCommand(sql, bag);
        int urunsayisi = Convert.ToInt32(komut.ExecuteScalar());
        bag.Close();
        return urunsayisi;
    }

    public ArrayList tumurunlerigetirsayfasiz() {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from urunler,markalar,altkategoriler,anakategoriler where " +
            "urunler.urun_markano = markalar.marka_id and markalar.altkate_no = altkategoriler.altkate_id and " +
            "altkategoriler.anakate_no = anakategoriler.anakate_id", bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Urun urungetir = new Urun();
            urungetir.Urun_id = Convert.ToInt32(oku["urun_id"]);
            urungetir.Urun_baslik = oku["urun_baslik"].ToString();
            urungetir.Urun_altbaslik = oku["urun_altbaslik"].ToString();
            urungetir.Urun_fiyat = Convert.ToDouble(oku["urun_fiyat"]);
            urungetir.Urun_aciklama = oku["urun_aciklama"].ToString();
            urungetir.Urun_puan = Convert.ToDouble(oku["urun_puan"]);
            urungetir.Urun_resim = oku["urun_resim"].ToString();
            urungetir.Urun_ucretsizkargo = Convert.ToBoolean(oku["urun_ucretsizkargo"]);
            if (oku["urun_gecicifiyat"] != DBNull.Value)
                urungetir.Urun_gecicifiyat = Convert.ToDouble(oku["urun_gecicifiyat"]);
            else
                urungetir.Urun_gecicifiyat = -1;
            Marka urunmarka = new Marka();
            urunmarka.Markaid = Convert.ToInt32(oku["marka_id"]);
            urunmarka.Markaad = oku["marka_ad"].ToString();
            Altkategori markaaltkate = new Altkategori();
            markaaltkate.Altkateid = Convert.ToInt32(oku["altkate_id"]);
            markaaltkate.Altkateadi = oku["altkate_ad"].ToString();
            markaaltkate.Filtretip = Convert.ToInt32(oku["filtre_no"]);
            Kategori altkateanakatesi = new Kategori();
            altkateanakatesi.Anakateid = Convert.ToInt32(oku["anakate_id"]);
            altkateanakatesi.Anakateadi = oku["anakate_ad"].ToString();
            markaaltkate.Anakate = altkateanakatesi;
            urunmarka.Altkate = markaaltkate;
            urungetir.Urun_marka = urunmarka;
            urunlistesi.Add(urungetir);
        }
        bag.Close();
        return urunlistesi;
    }

    public Urun tekurungetir(int urunid)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from urunler,markalar,altkategoriler,anakategoriler where " +
            "urunler.urun_markano = markalar.marka_id and markalar.altkate_no = altkategoriler.altkate_id and " +
            "altkategoriler.anakate_no = anakategoriler.anakate_id and urunler.urun_id = " + urunid, bag);
        SqlDataReader oku = komut.ExecuteReader();
        oku.Read();
        Urun urungetir = new Urun();
        urungetir.Urun_id = Convert.ToInt32(oku["urun_id"]);
        urungetir.Urun_baslik = oku["urun_baslik"].ToString();
        urungetir.Urun_altbaslik = oku["urun_altbaslik"].ToString();
        urungetir.Urun_fiyat = Convert.ToDouble(oku["urun_fiyat"]);
        urungetir.Urun_aciklama = oku["urun_aciklama"].ToString();
        urungetir.Urun_puan = Convert.ToDouble(oku["urun_puan"]);
        urungetir.Urun_resim = oku["urun_resim"].ToString();
        urungetir.Urun_ucretsizkargo = Convert.ToBoolean(oku["urun_ucretsizkargo"]);
        if (oku["urun_gecicifiyat"] != DBNull.Value)
            urungetir.Urun_gecicifiyat = Convert.ToDouble(oku["urun_gecicifiyat"]);
        else
            urungetir.Urun_gecicifiyat = -1;
        Marka urunmarka = new Marka();
        urunmarka.Markaid = Convert.ToInt32(oku["marka_id"]);
        urunmarka.Markaad = oku["marka_ad"].ToString();
        Altkategori markaaltkate = new Altkategori();
        markaaltkate.Altkateid = Convert.ToInt32(oku["altkate_id"]);
        markaaltkate.Altkateadi = oku["altkate_ad"].ToString();
        markaaltkate.Filtretip = Convert.ToInt32(oku["filtre_no"]);
        Kategori altkateanakatesi = new Kategori();
        altkateanakatesi.Anakateid = Convert.ToInt32(oku["anakate_id"]);
        altkateanakatesi.Anakateadi = oku["anakate_ad"].ToString();
        markaaltkate.Anakate = altkateanakatesi;
        urunmarka.Altkate = markaaltkate;
        urungetir.Urun_marka = urunmarka;
        oku.Close();
        bag.Close();
        return urungetir;
    }
    public Urun tekurungetirozellikli(int urunid)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from urunler,markalar,altkategoriler,anakategoriler,urunresimler,urunfiltre where " +
            "urunler.urun_markano = markalar.marka_id and markalar.altkate_no = altkategoriler.altkate_id and " +
            "altkategoriler.anakate_no = anakategoriler.anakate_id and urunler.urun_id = urunresimler.urun_no and urunler.urun_id = urunfiltre.urun_no and urunler.urun_id = " + urunid, bag);
        SqlDataReader oku = komut.ExecuteReader();
        oku.Read();
        Urun urungetir = new Urun();
        urungetir.Urun_id = Convert.ToInt32(oku["urun_id"]);
        urungetir.Urun_baslik = oku["urun_baslik"].ToString();
        urungetir.Urun_altbaslik = oku["urun_altbaslik"].ToString();
        urungetir.Urun_fiyat = Convert.ToDouble(oku["urun_fiyat"]);
        urungetir.Urun_aciklama = oku["urun_aciklama"].ToString();
        urungetir.Urun_puan = Convert.ToDouble(oku["urun_puan"]);
        urungetir.Urun_resim = oku["urun_resim"].ToString();
        urungetir.Urun_ucretsizkargo = Convert.ToBoolean(oku["urun_ucretsizkargo"]);
        if (oku["urun_gecicifiyat"] != DBNull.Value)
            urungetir.Urun_gecicifiyat = Convert.ToDouble(oku["urun_gecicifiyat"]);
        else
            urungetir.Urun_gecicifiyat = -1;
        Marka urunmarka = new Marka();
        urunmarka.Markaid = Convert.ToInt32(oku["marka_id"]);
        urunmarka.Markaad = oku["marka_ad"].ToString();
        Altkategori markaaltkate = new Altkategori();
        markaaltkate.Altkateid = Convert.ToInt32(oku["altkate_id"]);
        markaaltkate.Altkateadi = oku["altkate_ad"].ToString();
        markaaltkate.Filtretip = Convert.ToInt32(oku["filtre_no"]);
        Kategori altkateanakatesi = new Kategori();
        altkateanakatesi.Anakateid = Convert.ToInt32(oku["anakate_id"]);
        altkateanakatesi.Anakateadi = oku["anakate_ad"].ToString();
        markaaltkate.Anakate = altkateanakatesi;
        urunmarka.Altkate = markaaltkate;
        urungetir.Urun_marka = urunmarka;
        oku.Close();
        bag.Close();
        return urungetir;
    }
    public int sonurunno()
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select max(urunid) from urunler", bag);
        int sonurunid = Convert.ToInt32(komut.ExecuteScalar());
        bag.Close();
        return sonurunid;
    }
    public int urunekle(String baslik, String altbaslik, int fiyat, int indirimfiyati, int markano, bool ukargo, int adet, String aciklama, String urunanaresim, String urunresim1, String urunresim2, String urunresim3, String urunresim4, String urunresim5, int filtretip, int beden, String renk, String kumas, int boy, int numara, String form, String tip, String etki, int kozboy)
    {
        int kontrol = 1;
        try
        {
            int ucretsizkargo = 0;
            if (ukargo == true)
                ucretsizkargo = 1;
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into urunler (urun_baslik, urun_altbaslik," +
                " urun_fiyat, urun_aciklama, urun_puan, urun_resim, urun_ucretsizkargo, urun_markano," +
                " urun_gecicifiyat, urun_adet) values(@baslik, @altbaslik, @fiyat, @aciklama," +
                " @puan, @resim, @ucretsizkargo, @markano, @indirimfiyati, @adet)", bag);
            komut.Parameters.AddWithValue("@baslik", baslik);
            komut.Parameters.AddWithValue("@altbaslik", altbaslik);
            komut.Parameters.AddWithValue("@fiyat", fiyat);
            komut.Parameters.AddWithValue("@aciklama", aciklama);
            komut.Parameters.AddWithValue("@puan", 0);
            komut.Parameters.AddWithValue("@resim", urunanaresim);
            komut.Parameters.AddWithValue("@ucretsizkargo", ucretsizkargo);
            komut.Parameters.AddWithValue("@markano", markano);
            if (indirimfiyati == -1)
                komut.Parameters.AddWithValue("@indirimfiyati", DBNull.Value);
            else
                komut.Parameters.AddWithValue("@indirimfiyati", indirimfiyati);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.ExecuteNonQuery();

            komut = new SqlCommand("insert into urunresimler values(@resim1, @resim2, @resim3, @resim4, @resim5, (select max(urun_id) from urunler))", bag);
            if (urunresim1 != "-1")
                komut.Parameters.AddWithValue("@resim1", urunresim1);
            else
                komut.Parameters.AddWithValue("@resim1", DBNull.Value);
            if (urunresim2 != "-1")
                komut.Parameters.AddWithValue("@resim2", urunresim2);
            else
                komut.Parameters.AddWithValue("@resim2", DBNull.Value);
            if (urunresim3 != "-1")
                komut.Parameters.AddWithValue("@resim3", urunresim3);
            else
                komut.Parameters.AddWithValue("@resim3", DBNull.Value);
            if (urunresim4 != "-1")
                komut.Parameters.AddWithValue("@resim4", urunresim4);
            else
                komut.Parameters.AddWithValue("@resim4", DBNull.Value);
            if (urunresim5 != "-1")
                komut.Parameters.AddWithValue("@resim5", urunresim5);
            else
                komut.Parameters.AddWithValue("@resim5", DBNull.Value);
            komut.ExecuteNonQuery();
            
            
            komut = new SqlCommand("insert into urunfiltre values"+
                "(@filtretip, (select max(urun_id) from urunler), @beden, @renk, @kumas, @boy,"+
                " @numara, @form, @tip, @kozboy, @etki)", bag);
            komut.Parameters.AddWithValue("@filtretip", filtretip);
            if (beden != -1)
                komut.Parameters.AddWithValue("@beden", beden);
            else
                komut.Parameters.AddWithValue("@beden", DBNull.Value);
            if (renk != "-1")
                komut.Parameters.AddWithValue("@renk", renk);
            else
                komut.Parameters.AddWithValue("@renk", DBNull.Value);
            if (kumas != "-1")
                komut.Parameters.AddWithValue("@kumas", kumas);
            else
                komut.Parameters.AddWithValue("@kumas", DBNull.Value);
            if (boy != -1)
                komut.Parameters.AddWithValue("@boy", boy);
            else
                komut.Parameters.AddWithValue("@boy", DBNull.Value);
            if (numara != -1)
                komut.Parameters.AddWithValue("@numara", numara);
            else
                komut.Parameters.AddWithValue("@numara", DBNull.Value);
            if (form != "-1")
                komut.Parameters.AddWithValue("@form", form);
            else
                komut.Parameters.AddWithValue("@form", DBNull.Value);
            if (tip != "-1")
                komut.Parameters.AddWithValue("@tip", tip);
            else
                komut.Parameters.AddWithValue("@tip", DBNull.Value);
            if (kozboy != -1)
                komut.Parameters.AddWithValue("@kozboy", kozboy);
            else
                komut.Parameters.AddWithValue("@kozboy", DBNull.Value);
            if (etki != "-1")
                komut.Parameters.AddWithValue("@etki", etki);
            else
                komut.Parameters.AddWithValue("@etki", DBNull.Value);
            komut.ExecuteNonQuery();
            
            bag.Close();
        }
        catch (SqlException)
        {
            kontrol = -1;
        }
        catch (Exception)
        {
            kontrol = -2;
        }
        return kontrol;
    }


    public int urunguncelle(int urunid, String baslik, String altbaslik, int fiyat, int indirimfiyati, int markano, bool ukargo, int adet, String aciklama, String urunanaresim, String urunresim1, String urunresim2, String urunresim3, String urunresim4, String urunresim5, int filtretip, int beden, String renk, String kumas, int boy, int numara, String form, String tip, String etki, int kozboy)
    {
        int kontrol = 1;
        try
        {
            int ucretsizkargo = 0;
            if (ukargo == true)
                ucretsizkargo = 1;
            bag.Open();
            SqlCommand komut = new SqlCommand("update urunler set urun_baslik = @baslik, urun_altbaslik = @altbaslik," +
                " urun_fiyat = @fiyat, urun_aciklama = @aciklama, urun_puan = @puan, urun_resim = @resim, urun_ucretsizkargo = @ucretsizkargo,"+
                " urun_markano = @markano, urun_gecicifiyat = @indirimfiyati, urun_adet = @adet where urun_id = @urunid", bag);
            komut.Parameters.AddWithValue("@urunid", urunid);
            komut.Parameters.AddWithValue("@baslik", baslik);
            komut.Parameters.AddWithValue("@altbaslik", altbaslik);
            komut.Parameters.AddWithValue("@fiyat", fiyat);
            komut.Parameters.AddWithValue("@aciklama", aciklama);
            komut.Parameters.AddWithValue("@puan", 0);
            komut.Parameters.AddWithValue("@resim", urunanaresim);
            komut.Parameters.AddWithValue("@ucretsizkargo", ucretsizkargo);
            komut.Parameters.AddWithValue("@markano", markano);
            if (indirimfiyati == -1)
                komut.Parameters.AddWithValue("@indirimfiyati", DBNull.Value);
            else
                komut.Parameters.AddWithValue("@indirimfiyati", indirimfiyati);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.ExecuteNonQuery();

            komut = new SqlCommand("update urunresimler set urunresim_1 = @resim1, urunresim_2 = @resim2, urunresim_3 = @resim3, urunresim_4 = @resim4, urunresim_5 = @resim5 where urun_no = @urunid", bag);
            komut.Parameters.AddWithValue("@urunid", urunid);
            if (urunresim1 != "-1")
                komut.Parameters.AddWithValue("@resim1", urunresim1);
            else
                komut.Parameters.AddWithValue("@resim1", DBNull.Value);
            if (urunresim2 != "-1")
                komut.Parameters.AddWithValue("@resim2", urunresim2);
            else
                komut.Parameters.AddWithValue("@resim2", DBNull.Value);
            if (urunresim3 != "-1")
                komut.Parameters.AddWithValue("@resim3", urunresim3);
            else
                komut.Parameters.AddWithValue("@resim3", DBNull.Value);
            if (urunresim4 != "-1")
                komut.Parameters.AddWithValue("@resim4", urunresim4);
            else
                komut.Parameters.AddWithValue("@resim4", DBNull.Value);
            if (urunresim5 != "-1")
                komut.Parameters.AddWithValue("@resim5", urunresim5);
            else
                komut.Parameters.AddWithValue("@resim5", DBNull.Value);
            komut.ExecuteNonQuery();


            komut = new SqlCommand("update urunfiltre set filtre_tipi = @filtretip, urun_no = @urunid, beden = @beden, renk = @renk, "+
                "kumas = @kumas, boy = @boy, numara = @numara, koz_form = @form, koz_tip = @tip, koz_boy = @kozboy, koz_etki = @etki)", bag);
            komut.Parameters.AddWithValue("@filtretip", filtretip);
            komut.Parameters.AddWithValue("@urunid", urunid);
            if (beden != -1)
                komut.Parameters.AddWithValue("@beden", beden);
            else
                komut.Parameters.AddWithValue("@beden", DBNull.Value);
            if (renk != "-1")
                komut.Parameters.AddWithValue("@renk", renk);
            else
                komut.Parameters.AddWithValue("@renk", DBNull.Value);
            if (kumas != "-1")
                komut.Parameters.AddWithValue("@kumas", kumas);
            else
                komut.Parameters.AddWithValue("@kumas", DBNull.Value);
            if (boy != -1)
                komut.Parameters.AddWithValue("@boy", boy);
            else
                komut.Parameters.AddWithValue("@boy", DBNull.Value);
            if (numara != -1)
                komut.Parameters.AddWithValue("@numara", numara);
            else
                komut.Parameters.AddWithValue("@numara", DBNull.Value);
            if (form != "-1")
                komut.Parameters.AddWithValue("@form", form);
            else
                komut.Parameters.AddWithValue("@form", DBNull.Value);
            if (tip != "-1")
                komut.Parameters.AddWithValue("@tip", tip);
            else
                komut.Parameters.AddWithValue("@tip", DBNull.Value);
            if (kozboy != -1)
                komut.Parameters.AddWithValue("@kozboy", kozboy);
            else
                komut.Parameters.AddWithValue("@kozboy", DBNull.Value);
            if (etki != "-1")
                komut.Parameters.AddWithValue("@etki", etki);
            else
                komut.Parameters.AddWithValue("@etki", DBNull.Value);
            komut.ExecuteNonQuery();

            bag.Close();
        }
        catch (SqlException)
        {
            kontrol = -1;
        }
        catch (Exception)
        {
            kontrol = -2;
        }
        return kontrol;
    }

    public UrunDao()
    {

    }
}