using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MarkaDao
/// </summary>
public class MarkaDao
{
    ArrayList markalistesi = new ArrayList();
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public ArrayList kateyegoremarkalar(int altkate, int anakate)
    {
        bag.Open();
        String sql;
        if (altkate != -1 && anakate == -1)
            sql = "select * from markalar where markalar.altkate_no = " + altkate;
        else if (anakate != -1 && altkate == -1)
        {
            sql = "select * from markalar, altkategoriler where markalar.altkate_no = altkategoriler.altkate_id and " +
            "altkategoriler.anakate_no = " + anakate;
        }
        else
            sql = "select * from markalar";
        SqlCommand komut = new SqlCommand(sql, bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Marka mrk = new Marka();
            mrk.Markaad = oku["marka_ad"].ToString();
            mrk.Markaid = Convert.ToInt32(oku["marka_id"]);
            markalistesi.Add(mrk);
        }
        oku.Close();
        bag.Close();
        return markalistesi;
    }
    public ArrayList altkateyegoremarkalar(int altkate)
    {
        bag.Open();
        String sql;
        if (altkate != -1)
            sql = "select * from markalar where markalar.altkate_no = " + altkate;
        else
            sql = "select * from markalar";
        SqlCommand komut = new SqlCommand(sql, bag);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Marka mrk = new Marka();
            mrk.Markaad = oku["marka_ad"].ToString();
            mrk.Markaid = Convert.ToInt32(oku["marka_id"]);
            markalistesi.Add(mrk);
        }
        oku.Close();
        bag.Close();
        return markalistesi;
    }

    public MarkaDao()
    {

    }
}