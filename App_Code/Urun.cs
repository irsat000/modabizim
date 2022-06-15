using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Urun
/// </summary>
public class Urun
{
    int urun_id;
    public int Urun_id
    {
        get { return urun_id; }
        set { urun_id = value; }
    }

    String urun_baslik;
    public String Urun_baslik
    {
        get { return urun_baslik; }
        set { urun_baslik = value; }
    }

    String urun_altbaslik;
    public String Urun_altbaslik
    {
        get { return urun_altbaslik; }
        set { urun_altbaslik = value; }
    }

    double urun_fiyat;
    public double Urun_fiyat
    {
        get { return urun_fiyat; }
        set { urun_fiyat = value; }
    }

    String urun_aciklama;
    public String Urun_aciklama
    {
        get { return urun_aciklama; }
        set { urun_aciklama = value; }
    }

    double urun_puan;
    public double Urun_puan
    {
        get { return urun_puan; }
        set { urun_puan = value; }
    }

    String urun_resim;
    public String Urun_resim
    {
        get { return urun_resim; }
        set { urun_resim = value; }
    }

    bool urun_ucretsizkargo;
    public bool Urun_ucretsizkargo
    {
        get { return urun_ucretsizkargo; }
        set { urun_ucretsizkargo = value; }
    }

    double urun_gecicifiyat;
    public double Urun_gecicifiyat
    {
        get { return urun_gecicifiyat; }
        set { urun_gecicifiyat = value; }
    }

    Marka urun_marka;
    public Marka Urun_marka
    {
        get { return urun_marka; }
        set { urun_marka = value; }
    }

    public Urun()
    {

    }
}