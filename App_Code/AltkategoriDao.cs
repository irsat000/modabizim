using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for AltkategoriDao
/// </summary>
public class AltkategoriDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public ArrayList altkategoritorbasi = new ArrayList();
    public ArrayList tumaltkategoriler(int anakateno)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from altkategoriler, anakategoriler where " +
            "anakategoriler.anakate_id = altkategoriler.anakate_no and altkategoriler.anakate_no = " + anakateno, bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Altkategori yenikate = new Altkategori();
            yenikate.Altkateid = Convert.ToInt32(oku["altkate_id"]);
            yenikate.Altkateadi = oku["altkate_ad"].ToString();
            yenikate.Filtretip = Convert.ToInt32(oku["filtre_no"]);
            Kategori yenikateninanakatesi = new Kategori();
            yenikateninanakatesi.Anakateid = Convert.ToInt32(oku["anakate_id"]);
            yenikateninanakatesi.Anakateadi = oku["anakate_ad"].ToString();
            yenikate.Anakate = yenikateninanakatesi;
            altkategoritorbasi.Add(yenikate);
        }
        oku.Close();
        bag.Close();
        return altkategoritorbasi;
    }
    public Altkategori tekaltkategori(int altkateno)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from altkategoriler, anakategoriler where " +
            "anakategoriler.anakate_id = altkategoriler.anakate_no and altkategoriler.altkate_id = " + altkateno, bag);
        SqlDataReader oku = komut.ExecuteReader();
        oku.Read();
        Altkategori istenenaltkate = new Altkategori();
        istenenaltkate.Altkateid = Convert.ToInt32(oku["altkate_id"]);
        istenenaltkate.Altkateadi = oku["altkate_ad"].ToString();
        istenenaltkate.Filtretip = Convert.ToInt32(oku["filtre_no"]);
        Kategori yenikateninanakatesi = new Kategori();
        yenikateninanakatesi.Anakateid = Convert.ToInt32(oku["anakate_id"]);
        yenikateninanakatesi.Anakateadi = oku["anakate_ad"].ToString();
        istenenaltkate.Anakate = yenikateninanakatesi;
        oku.Close();
        bag.Close();
        return istenenaltkate;
    }

	public AltkategoriDao()
	{

	}
}