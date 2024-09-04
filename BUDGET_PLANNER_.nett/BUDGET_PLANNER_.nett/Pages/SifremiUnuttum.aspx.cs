using Business.Work;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Threading;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Musteriler musteriler;
        MailOnayKodlari kodlar;
        Random rnd = new Random();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlSecondArea.Style.Add(HtmlTextWriterStyle.Display, "none");
                pnlPasswordArea.Style.Add(HtmlTextWriterStyle.Display, "none");
                btnKod.Style.Add(HtmlTextWriterStyle.Display, "none");
                btnSifreDegistir.Style.Add(HtmlTextWriterStyle.Display, "none"); 
            }
        }
        protected void btnGonder_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            musteriler = new Musteriler(veritabaniIslemleri);
            kodlar = new MailOnayKodlari(veritabaniIslemleri);
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

            musteriler.Mail = txtMail.Text;
            kodlar.Mail = txtMail.Text;
            kodlar.Kod = rnd.Next(100000, 1000000).ToString();

            if (kodlar.Ekle())
            {
                veritabaniIslemleri.Uygula();
            }
            else
            {
                veritabaniIslemleri.GeriAl();
            }
            veritabaniIslemleri.Bitir();


            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            if (musteriler.MaileGoreDoldur())
            {
                MailMessage ePosta = new MailMessage("yusuf70.doguyel@gmail.com", kodlar.Mail, "Şifre Yenileme",
                    "Şifre yenilemek için onay kodunuz :" + kodlar.Kod.ToString());

                SmtpClient client = new SmtpClient();

                client.Credentials = new System.Net.NetworkCredential("yusuf70.doguyel@gmail.com", "tzhcaibcjxhayqqi");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;

                try
                {
                    client.Send(ePosta);
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");
                    lblMesaj.Text = "Kod Başarıyla Gönderildi!";

                    pnlFirstArea.Style.Add(HtmlTextWriterStyle.Display, "none");
                    pnlSecondArea.Style.Add(HtmlTextWriterStyle.Display, "block");
                    btnGonder.Style.Add(HtmlTextWriterStyle.Display, "none");
                    btnKod.Style.Add(HtmlTextWriterStyle.Display, "block");

                }
                catch (Exception)
                {
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblMesaj.Text = "Kod gönderilemedi!";
                }

            }
            else
            {
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                lblMesaj.Text = "Girdiğiniz mail bulunmamaktadır!";
            }

        }
        protected void btnKod_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            kodlar = new MailOnayKodlari(veritabaniIslemleri);
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            if (kodlar.SonSatirGetir())
            {
                if (kodlar.Kod == txtKod.Text.Trim())
                {
                    pnlSecondArea.Style.Add(HtmlTextWriterStyle.Display, "none");
                    pnlPasswordArea.Style.Add(HtmlTextWriterStyle.Display, "block");
                    btnKod.Style.Add(HtmlTextWriterStyle.Display, "none");
                    btnSifreDegistir.Style.Add(HtmlTextWriterStyle.Display, "block");

                    lblMesaj.Text = "";
                }
                else
                {
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblMesaj.Text = "Girdiğiniz kod geçersiz!";
                }
            }
            veritabaniIslemleri.Bitir();
            
            
        }
        protected void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text.ToString() == txtTekrarSifre.Text.ToString())
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                musteriler = new Musteriler(veritabaniIslemleri);
                kodlar = new MailOnayKodlari(veritabaniIslemleri);
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                if (kodlar.SonSatirGetir())
                {
                    musteriler.Mail = kodlar.Mail;
                    veritabaniIslemleri.Bitir();
                }


                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                if (musteriler.MaileGoreDoldur())
                {
                    veritabaniIslemleri.Bitir();

                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                    musteriler.Sifre = txtSifre.Text;

                    if (musteriler.Guncelle())
                    {
                        veritabaniIslemleri.Uygula();

                        lblMesaj.Text = "Şifre başarıyla Değiştirldi! Yönlendiriyoruz...";

                        Thread.Sleep(2000);

                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        veritabaniIslemleri.GeriAl();
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                        lblMesaj.Text = "Bir şeyler ters gitti!";
                    }
                }

            }
        }
    }

}