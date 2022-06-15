using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for SiparisDao
/// </summary>
public class SiparisDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public int siparisekle(ArrayList siparisistegi, int uyeid)
    {
        int fisno = 0;
        bag.Open();
        SqlCommand komut = new SqlCommand("select max(fis_no) from siparis", bag);
        try
        {
            fisno = Convert.ToInt32(komut.ExecuteScalar());
        }
        catch (Exception){}
        fisno++;
        SqlCommand komut2 = new SqlCommand();
        foreach (Sepet urn in siparisistegi)
        {
            komut2 = new SqlCommand("insert into siparis(adet,siparis_tarihi,urun_no,uye_no,fis_no) " +
                "values(@adet,@siptarihi,@urunno,@uye_no,@fis_no)", bag);
            komut2.Parameters.AddWithValue("@adet", urn.Adet);
            komut2.Parameters.AddWithValue("@siptarihi", DateTime.Now);
            komut2.Parameters.AddWithValue("@urunno", urn.Urun.Urun_id);
            komut2.Parameters.AddWithValue("@uye_no", uyeid);
            komut2.Parameters.AddWithValue("@fis_no", fisno);
            komut2.ExecuteNonQuery();
        }
        bag.Close();
        return fisno;
    }

	public SiparisDao()
	{

	}
}