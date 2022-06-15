using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for UrunresimDao
/// </summary>
public class UrunresimDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public UrunResimler resimlerigetir(int urunno)
    {
        bag.Open();
        SqlCommand komut = new SqlCommand("select * from urunresimler where urun_no = " + urunno, bag);
        SqlDataReader oku = komut.ExecuteReader();
        oku.Read();
        UrunResimler pic = new UrunResimler();
        pic.Urunno = urunno;
        if (oku["urunresim_1"] != DBNull.Value)
            pic.Urunresim1 = oku["urunresim_1"].ToString();
        if (oku["urunresim_2"] != DBNull.Value)
            pic.Urunresim2 = oku["urunresim_2"].ToString();
        if (oku["urunresim_3"] != DBNull.Value)
            pic.Urunresim3 = oku["urunresim_3"].ToString();
        if (oku["urunresim_4"] != DBNull.Value)
            pic.Urunresim4 = oku["urunresim_4"].ToString();
        if (oku["urunresim_5"] != DBNull.Value)
            pic.Urunresim5 = oku["urunresim_5"].ToString();
        oku.Close();
        bag.Close();
        return pic;
    }

    public int sonurunresimno()
    {
        String imgpath = HttpContext.Current.Server.MapPath("~/urunimgs");
        DirectoryInfo d = new DirectoryInfo(imgpath);
        FileInfo[] resimler = d.GetFiles();
        List<int> resimnolari = new List<int>();
        foreach (FileInfo resim in resimler)
        {
            String resimad = Path.GetFileNameWithoutExtension(resim.Name);
            resimnolari.Add(Convert.ToInt32(resimad.Replace("urunresim_", "")));
        }
        return resimnolari.Max();
    }


    public UrunresimDao()
    {

    }
}