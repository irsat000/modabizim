using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConnectionYapici
/// </summary>
public class ConnectionYapici
{
    public SqlConnection baglantiyagec()
    {
        SqlConnection bag = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename='|DataDirectory|\\Modabizim.mdf';Integrated Security=True;User Instance=True");

        return bag;
    }
	public ConnectionYapici()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}