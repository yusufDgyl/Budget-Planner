using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Musteriler musteriler;
        Oturum oturum;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGirisYap_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            musteriler = new Musteriler(veritabaniIslemleri);
            oturum = new Oturum();

            musteriler.Kul_adi = txtKulAdi.Text;

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            lblMesaj.Text = "";



            if (musteriler.KulAdinaGoreDoldur())
            {
                if (musteriler.Sifre == txtSifre.Text)
                {
                    oturum.Id = musteriler.Id;
                    oturum.KulAdi = musteriler.Kul_adi;
                    oturum.LoginMi = true;
                    Session["Oturum"] = oturum;


                    System.Threading.Thread.Sleep(2000);
                    Response.Redirect("BP_IsletmeGecisYap.aspx");    
                }
                else
                {
                    lblMesaj.Text = "Hatalı Kullanıcı Adı veya Şifre!";
                }
            }
            else
            {
                lblMesaj.Text = "Hatalı Kullanıcı Adı veya Şifre!";
            }


        }
    }
}