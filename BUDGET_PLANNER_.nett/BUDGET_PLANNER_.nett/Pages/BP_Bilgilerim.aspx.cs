using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class BP_Bilgilerim : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        MailOnayKodlari mailOnayKodlari;
        Musteriler musteriler;
        Oturum oturum;
        int kod;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                oturum = new Oturum();
                oturum = (Oturum)Session["Oturum"];
                veritabaniIslemleri = new VeritabaniIslemleri();
                musteriler = new Musteriler(veritabaniIslemleri);
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                musteriler.Id = oturum.Id;

                musteriler.Doldur();
                dListBilgilerim.DataSource = DtDondur(musteriler);
                dListBilgilerim.DataBind();
                veritabaniIslemleri.Bitir();

                lblIsim.Text = musteriler.Adi;
                lblMail.Text = musteriler.Mail;

                txtAdSoyad.Text = musteriler.Adi.ToUpper() + " " + musteriler.Soyadi.ToUpper();
                txtKulAdi.Text = musteriler.Kul_adi;
            }



        }
        protected void btnKodGonder_Click(object sender, EventArgs e)
        {
            if (txtYeniMail.Text != null || txtYeniMail.Text != "")
            {
                Random rnd = new Random();
                veritabaniIslemleri = new VeritabaniIslemleri();
                musteriler = new Musteriler(veritabaniIslemleri);
                mailOnayKodlari = new MailOnayKodlari(veritabaniIslemleri);
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                kod = rnd.Next(100000, 1000000);
                musteriler.Mail = txtYeniMail.Text;
                mailOnayKodlari.Mail = txtYeniMail.Text;
                mailOnayKodlari.Kod = kod.ToString();

                if (mailOnayKodlari.Ekle())
                {
                    veritabaniIslemleri.Uygula();
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }


                if (!musteriler.MaileGoreDoldur())
                {
                    lblMesaj.Text = "Gönderiliyor...";
                    MailMessage ePosta = new MailMessage("yusuf70.doguyel@gmail.com", txtYeniMail.Text, "Mail Yenileme",
                    "Mail yenilemek için onay kodunuz :" + kod);

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

                        btnKodGonder.Style.Add(HtmlTextWriterStyle.Display, "none");
                        btnDegistir.Style.Add(HtmlTextWriterStyle.Display, "inline-block");

                        pnlKod.Style.Add(HtmlTextWriterStyle.Display, "block");
                        txtYeniMail.Attributes.Add("disabled", "disabled");

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
                    lblMesaj.Text = "Lütfen farklı bir mail adresi girin!";
                }

            }
        }
        protected void btnDegistir_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            mailOnayKodlari = new MailOnayKodlari(veritabaniIslemleri);

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);


            if (mailOnayKodlari.SonSatirGetir())
            {
                if (txtKod.Text != null || txtKod.Text != "")
                {
                    if (mailOnayKodlari.Kod == txtKod.Text)
                    {
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");
                        lblMesaj.Text = "Mail adresi başarıyla değiştirildi!";
                        txtKod.Attributes.Add("disabled", "disabled");
                        lblMail.Text = mailOnayKodlari.Mail;
                        System.Threading.Thread.Sleep(1000);

                        btnDegistir.Style.Add(HtmlTextWriterStyle.Display, "none");
                        btnTamamla.Style.Add(HtmlTextWriterStyle.Display, "inline-block");

                    }
                    else
                    {
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                        lblMesaj.Text = "Geçersiz kod!";
                    }
                }

            }

        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            oturum = new Oturum();
            oturum = (Oturum)Session["Oturum"];
            veritabaniIslemleri = new VeritabaniIslemleri();
            musteriler = new Musteriler(veritabaniIslemleri);
            musteriler.Id = oturum.Id;
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            if (musteriler.Doldur())
            {
                if (txtMevcutParola.Text != null && txtMevcutParola.Text == musteriler.Sifre)
                {
                    if ((txtYeniParola != null && txtYeniParolaTekrar != null) && (txtYeniParola.Text == txtYeniParolaTekrar.Text))
                    {

                        veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);


                        try
                        {
                            musteriler.Adi = txtAdSoyad.Text.Split(' ')[0];
                            musteriler.Soyadi = txtAdSoyad.Text.Split(' ')[1];
                            musteriler.Kul_adi = txtKulAdi.Text;
                            musteriler.Mail = lblMail.Text;
                            musteriler.Sifre = txtYeniParola.Text;
                            veritabaniIslemleri.Bitir();
                            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                            if (musteriler.Guncelle())
                            {
                                veritabaniIslemleri.Uygula();
                                lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "Kaydet");
                                lblKaydetMesaj.Text = "Kaydetme İşlemi Başarılı! Yönlendiriyoruz...";
                                System.Threading.Thread.Sleep(1000);
                                Response.Redirect("BP_Bilgilerim.aspx");
                            }
                            else
                            {
                                veritabaniIslemleri.GeriAl();
                                lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                                lblKaydetMesaj.Text = "Kaydetme İşlemi Başarısız!";

                            }

                            veritabaniIslemleri.Bitir();

                        }
                        catch (Exception)
                        {
                            Response.Redirect("BP_Bilgilerim.aspx");
                        }

                    }
                    else
                    {
                        lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                        lblKaydetMesaj.Text = "Girdiğiniz parolalar uyuşmuyor!";
                    }

                }
                else
                {
                    lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblKaydetMesaj.Text = "Geçersiz parola";
                }
            }


        }
        public DataTable DtDondur(Musteriler musteriler)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("adi", typeof(string));
            dt.Columns.Add("soyadi", typeof(string));
            dt.Columns.Add("mail", typeof(string));
            dt.Columns.Add("kul_adi", typeof(string));
            dt.Columns.Add("sifre", typeof(string));


            dt.Rows.Add(musteriler.Id, musteriler.Adi, musteriler.Soyadi, musteriler.Mail, musteriler.Kul_adi, musteriler.Sifre);

            return dt;
        }
    }
}