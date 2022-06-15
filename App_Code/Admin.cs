using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
    int admin_id;

    public int Admin_id
    {
        get { return admin_id; }
        set { admin_id = value; }
    }
    String admin_username;

    public String Admin_username
    {
        get { return admin_username; }
        set { admin_username = value; }
    }
    String admin_password;

    public String Admin_password
    {
        get { return admin_password; }
        set { admin_password = value; }
    }

	public Admin()
	{

	}
}