using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for KategoriDao
/// </summary>
public class KategoriDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public ArrayList anakategoritorbasi = new ArrayList();
    public ArrayList tumanakategoriler()
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from anakategoriler order by anakate_ad", bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Kategori yenikate = new Kategori();
            yenikate.Anakateid = Convert.ToInt32(oku["anakate_id"]);
            yenikate.Anakateadi = oku["anakate_ad"].ToString();
            anakategoritorbasi.Add(yenikate);
        }
        oku.Close();
        bag.Close();
        return anakategoritorbasi;
    }
    public Kategori tekanakategori(int kategorino)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from anakategoriler where " +
            "anakategoriler.anakate_id = " + kategorino, bag);
        SqlDataReader oku = komut.ExecuteReader();
        oku.Read();
        Kategori istenenanakate = new Kategori();
        istenenanakate.Anakateid = Convert.ToInt32(oku["anakate_id"]);
        istenenanakate.Anakateadi = oku["anakate_ad"].ToString();
        oku.Close();
        bag.Close();
        return istenenanakate;
    }

	public KategoriDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}