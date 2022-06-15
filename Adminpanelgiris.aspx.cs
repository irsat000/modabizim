using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adminpanelgiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void admingiris_Click(object sender, EventArgs e)
    {
        if (Session["uyeid"] != null)
            Session.Remove("uyeid");
        if (Session["adminid"] != null)
            goto girisatla;
        Admin admin = new AdminDao().admingiriskontrol(username.Text, password.Text);
        Session["adminadi"] = admin.Admin_username;
        if (Session["adminadi"] == null)
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Kullanıcı adı veya şifre hatalı*');}", true);
        else
        {
            Session["adminid"] = admin.Admin_id;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Giriş Başarılı*');}", true);
        }
    girisatla: { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Admin girişi zaten yapılmış!* Yapılı giriş => "+Session["adminadi"]+"');}", true); }
     }
    protected void admincikis_Click(object sender, EventArgs e)
    {
        if (Session["adminid"] != null)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('" + Session["adminadi"] + " adlı hesaptan çıkış yapıldı.');}", true);
            Session.Remove("adminid");
        }
    }
}