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
    public partial class KayitOl : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Musteriler musteriler;
        Oturum oturum;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            musteriler = new Musteriler(veritabaniIslemleri);


            musteriler.Kul_adi = txtKulAdi.Text;
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            if (!musteriler.KulAdiVarMi())
            {

                musteriler.Mail = txtMail.Text;

                // Mail benzersiz kontrolü
                if (!musteriler.MaileGoreDoldur())
                {
                    musteriler.Adi = txtAd.Text;
                    musteriler.Soyadi = txtSurname.Text;
                    musteriler.Mail = txtMail.Text;
                    musteriler.Kul_adi = txtKulAdi.Text;
                    musteriler.Sifre = txtSifre.Text;

                    veritabaniIslemleri.Bitir();

                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                    if (musteriler.Ekle())
                    {
                        lblMesaj.Text = "";
                        veritabaniIslemleri.Uygula();
                        veritabaniIslemleri.Bitir();


                        veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                        if (musteriler.KulAdinaGoreDoldur())
                        {
                            oturum = new Oturum();

                            oturum.KulAdi = musteriler.Kul_adi;
                            oturum.Id = musteriler.Id;
                            oturum.LoginMi = true;

                            Session["Oturum"] = oturum;


                            System.Threading.Thread.Sleep(2000);
                            Response.Redirect("BP_DefterIsletmeKayit.aspx");
                        }
                        else
                        {
                            lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                            lblMesaj.Text = "Bir şeyler ters gitti!";
                        }
                    }
                    else
                    {
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                        lblMesaj.Text = "Bir şeyler ters gitti!";
                        veritabaniIslemleri.GeriAl();
                    }
                    veritabaniIslemleri.Bitir();


                }
                else
                {
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblMesaj.Text = "Girdiğiniz E-Posta Adresi Kullanılmaktadır!";
                }
            }
            else
            {
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                lblMesaj.Text = "Girdiğiniz Kullanıcı Adı Kullanılmaktadır!";
            }


            
        }
    }
}