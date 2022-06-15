using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AdminDao
/// </summary>
public class AdminDao
{
    SqlConnection bag = new ConnectionYapici().baglantiyagec();
    public Admin admingiriskontrol(String username, String pass)
    {
        Admin admin = new Admin();
        try
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("select * from adminler where admin_username = @kullaniciadi and admin_password = @sifre", bag);
            komut.Parameters.AddWithValue("@kullaniciadi", username);
            komut.Parameters.AddWithValue("@sifre", pass);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            admin.Admin_username = oku["admin_username"].ToString();
            admin.Admin_id = Convert.ToInt32(oku["admin_id"]);
            oku.Close();
            bag.Close();
        }
        catch (Exception)
        {

        }
        return admin;
    }

	public AdminDao()
	{

	}
}