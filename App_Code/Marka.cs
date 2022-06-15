using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Marka
/// </summary>
public class Marka
{
    int markaid;
    public int Markaid
    {
        get { return markaid; }
        set { markaid = value; }
    }

    String markaad;
    public String Markaad
    {
        get { return markaad; }
        set { markaad = value; }
    }

    Altkategori altkate;
    public Altkategori Altkate
    {
        get { return altkate; }
        set { altkate = value; }
    }

	public Marka()
	{

	}
}