using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class maintemplate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList ayakkabialtkateler = new AltkategoriDao().tumaltkategoriler(10);
        int ayakkabilisteindex = 0;
        foreach (Altkategori gelenaltkateler in ayakkabialtkateler)
        {
            if (ayakkabilisteindex < 6)
            {
                AyakkabiListe.Text += "<li><a href='ProductSale.aspx?altkateno=" + gelenaltkateler.Altkateid + "&filtretip=" + gelenaltkateler.Filtretip + "'>" + gelenaltkateler.Altkateadi + "</a></li>";
            }
            else
            {
                AyakkabiListe2.Text += "<li><a href='ProductSale.aspx?altkateno=" + gelenaltkateler.Altkateid + "&filtretip=" + gelenaltkateler.Filtretip + "'>" + gelenaltkateler.Altkateadi + "</a></li>";
            }
            ayakkabilisteindex++;
        }
        if (Session["uyeid"] != null)
        {
            header_login_button.Visible = false;
            header_register_button.Visible = false;
            header_profile_button.Visible = true;
        }
        else
        {
            header_login_button.Visible = true;
            header_register_button.Visible = true;
            header_profile_button.Visible = false;
        }
    }
    protected void login_button_Click(object sender, EventArgs e)
    {
        if (Session["adminid"] != null)
            Session.Remove("adminid");
        Uye kullanici = new UyeDao().uyegiriskontrol(login_username.Text, login_password.Text);
        Session["kullaniciadi"] = kullanici.Uye_kullaniciadi;
        if (Session["kullaniciadi"] == null)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('*Kullanıcı adı veya şifre hatalı*');}", true);
        }
        else
        {
            Session["uyeid"] = kullanici.Uye_id;
            header_login_button.Visible = false;
            header_register_button.Visible = false;
            header_profile_button.Visible = true;
        }
    }
    protected void register_button_Click(object sender, EventArgs e)
    {
        int cins = 0;
        if (register_male.Checked) cins = 1;
        else if (register_female.Checked) cins = 0;
        if (Page.IsValid == true)
        {
            int kayitkontrol = new UyeDao().uyeekle(register_username.Text, register_email.Text, register_password.Text, cins);
            if (kayitkontrol > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt başarılı!');}", true);
            }
            else if (kayitkontrol == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt işlemi yapılırken bir hata oluştu!');}", true);
            }
            else if (kayitkontrol == -2)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Message", "window.onload = function(){alert('Kayıt başarısız oldu!');}", true);
            }
        }
    }
    protected void hesapcikis_Click(object _sender, EventArgs _args)
    {
        if (Session["uyeid"] != null)
        {
            Session.Remove("uyeid");
            Response.Redirect(Request.RawUrl);
        }
    }
}
