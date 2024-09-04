using Business.Work;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGirisYap_Click(object sender , EventArgs e)
        {
            Oturum oturum = new Oturum();
            VeritabaniIslemleri veritabaniIslemleri = new VeritabaniIslemleri();
            Kullanicilar kullanicilar = new Kullanicilar(veritabaniIslemleri);
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            kullanicilar.Kul_adi = txtKulAdi.Text;
            kullanicilar.Sifre = txtParola.Text;
            if (kullanicilar.Login())
            {
                oturum.Id = kullanicilar.Id;
                oturum.KulAdi = kullanicilar.Kul_adi;
                oturum.LoginMi = true;
                Session["OTURUM"] = oturum;
                if (chkHatirla.Checked)
                {
                    try
                    {
                        Response.Cookies["AD"].Value = txtKulAdi.Text;
                        Response.Cookies["SIFRE"].Value = txtParola.Text;

                        Response.Cookies["AD"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["SIFRE"].Expires = DateTime.Now.AddDays(10);
                    }
                    catch
                    {
                    }

                }
                Response.Redirect("Pages/Default.aspx");
            }
            else
            {
                lblMesaj.Text = "Bilgiler Hatalı";
            }
            veritabaniIslemleri.Bitir();
        }
    }
}