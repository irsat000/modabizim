using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uye
/// </summary>
public class Uye
{
    int uye_id;

    public int Uye_id
    {
        get { return uye_id; }
        set { uye_id = value; }
    }
    String uye_kullaniciadi;

    public String Uye_kullaniciadi
    {
        get { return uye_kullaniciadi; }
        set { uye_kullaniciadi = value; }
    }
    String uye_eposta;

    public String Uye_eposta
    {
        get { return uye_eposta; }
        set { uye_eposta = value; }
    }
    String uye_sifre;

    public String Uye_sifre
    {
        get { return uye_sifre; }
        set { uye_sifre = value; }
    }
    int uye_cinsiyet;

    public int Uye_cinsiyet
    {
        get { return uye_cinsiyet; }
        set { uye_cinsiyet = value; }
    }
    String uye_ad;

    public String Uye_ad
    {
        get { return uye_ad; }
        set { uye_ad = value; }
    }
    String uye_soyad;

    public String Uye_soyad
    {
        get { return uye_soyad; }
        set { uye_soyad = value; }
    }
    String uye_adres;

    public String Uye_adres
    {
        get { return uye_adres; }
        set { uye_adres = value; }
    }
    Ilce uye_ilce;

    public Ilce Uye_ilce
    {
        get { return uye_ilce; }
        set { uye_ilce = value; }
    }

	public Uye()
	{

	}
}