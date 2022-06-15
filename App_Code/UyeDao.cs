using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for UyeDao
/// </summary>
public class UyeDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public ArrayList uyelistesi = new ArrayList();
    public ArrayList tumuyelerigetir()
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from uyeler, ilceler, iller where uyeler.uye_ilceno = ilceler.id"+
            " and ilceler.sehir = iller.id", bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Uye uyegetir = new Uye();
            uyegetir.Uye_id = Convert.ToInt32(oku["uye_id"]);
            uyegetir.Uye_kullaniciadi = oku["uye_kullaniciadi"].ToString();
            uyegetir.Uye_eposta = oku["uye_eposta"].ToString();
            uyegetir.Uye_sifre = oku["uye_sifre"].ToString();
            uyegetir.Uye_cinsiyet = Convert.ToInt32(oku["uye_cinsiyet"]);
            uyegetir.Uye_ad = oku["uye_ad"].ToString();
            uyegetir.Uye_soyad = oku["uye_soyad"].ToString();
            uyegetir.Uye_adres = oku["uye_adres"].ToString();
            Ilce ilcegetir = new Ilce();
            ilcegetir.Ilceno = Convert.ToInt32(oku["ilceler.id"]);
            ilcegetir.Ilceadi = oku["ilce"].ToString();
            Il ilgetir = new Il();
            ilgetir.Plaka = Convert.ToInt32(oku["iller.id"]);
            ilgetir.Sehiradi = oku["sehir"].ToString();
            ilcegetir.Sehir = ilgetir;
            uyegetir.Uye_ilce = ilcegetir;
            uyelistesi.Add(uyegetir);
        }
        oku.Close();
        bag.Close();
        return uyelistesi;
    }

    public int uyeekle(String u_kullaniciadi, String u_sifre, String u_eposta, int u_cinsiyet)
    {
        int kontrol = 1;
        try
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into uyeler (uye_kullaniciadi, uye_eposta, uye_sifre, uye_cinsiyet)" +
                " values(@kullaniciadi, @sifre, @eposta, @cinsiyet)", bag);
            komut.Parameters.AddWithValue("@kullaniciadi", u_kullaniciadi);
            komut.Parameters.AddWithValue("@sifre", u_sifre);
            komut.Parameters.AddWithValue("@eposta", u_eposta);
            komut.Parameters.AddWithValue("@cinsiyet", u_cinsiyet);
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

    public Uye uyegiriskontrol(String username, String pass)
    {
        Uye uye = new Uye();
        try
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("select * from uyeler where uye_kullaniciadi = @kullaniciadi and uye_sifre = @sifre", bag);
            komut.Parameters.AddWithValue("@kullaniciadi", username);
            komut.Parameters.AddWithValue("@sifre", pass);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            uye.Uye_kullaniciadi = oku["uye_kullaniciadi"].ToString();
            uye.Uye_id = Convert.ToInt32(oku["uye_id"]);
            oku.Close();
            bag.Close();
        }
        catch (Exception)
        {

        }
        return uye;
    }

	public UyeDao()
	{

	}
}