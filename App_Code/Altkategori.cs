using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Altkategori
/// </summary>
public class Altkategori
{
    int altkateid;
    public int Altkateid
    {
        get { return altkateid; }
        set { altkateid = value; }
    }

    String altkateadi;
    public String Altkateadi
    {
        get { return altkateadi; }
        set { altkateadi = value; }
    }

    Kategori anakate;
    public Kategori Anakate
    {
        get { return anakate; }
        set { anakate = value; }
    }

    int filtretip;
    public int Filtretip
    {
        get { return filtretip; }
        set { filtretip = value; }
    }

	public Altkategori()
	{

	}
}