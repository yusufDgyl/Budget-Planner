using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class BP_DefterIsletmeKayıt : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Oturum oturum;
        Defterler defterler;
        Isletme isletme;
        IsletmeTurleri isletmeTurleri;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Click(object sender, EventArgs e)
        {

            if (!(dListIsletmeTuru.Text == "Seçiniz")) // combo box seçim kontrolü
            {
                oturum = new Oturum();
                oturum = (Oturum)Session["Oturum"];

                veritabaniIslemleri = new VeritabaniIslemleri();
                defterler = new Defterler(veritabaniIslemleri);
                isletme = new Isletme(veritabaniIslemleri);

                defterler.Musteriler_id = oturum.Id;
                defterler.Adi = txtDefterAdi.Text;
                defterler.Aciklamasi = txtDefterAciklamasi.Text;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                if (defterler.Ekle()) 
                {
                    veritabaniIslemleri.Uygula();


                    veritabaniIslemleri.Bitir();

                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                    if (defterler.MaxIdGetir())
                    {
                        veritabaniIslemleri.Bitir();


                        isletmeTurleri = new IsletmeTurleri(veritabaniIslemleri);
                        isletmeTurleri.Tur = dListIsletmeTuru.SelectedItem.Value;
                        

                        veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                        if (isletmeTurleri.DoldurIsmeGore())
                        {
                            isletme.Defter_id = defterler.Id;
                            isletme.Isletme_turleri_id = isletmeTurleri.Id;
                            isletme.Adi = txtIsletmeAdi.Text;
                            isletme.Aciklamasi = txtIsletmeAciklamasi.Text;
                            veritabaniIslemleri.Bitir();

                            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                            if (isletme.Ekle())
                            {
                                veritabaniIslemleri.Uygula();


                                if (isletme.MaxIdGetir())
                                {
                                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");
                                    lblMesaj.Text = "Bilgileriniz başarıyla kaydedilmiştir! Yönlendiriyoruz..";
                                    veritabaniIslemleri.Bitir();

                                    Response.Redirect("BP_Anasayfa.aspx?ID=" + isletme.Id.ToString());
                                }
                                else
                                {
                                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                                    lblMesaj.Text = "Bilgilerinizi kaydedemedik!";
                                    veritabaniIslemleri.Bitir();

                                }

                            }
                            else
                            {
                                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                                lblMesaj.Text = "Bilgilerinizi kaydedemedik!";
                                veritabaniIslemleri.GeriAl();
                                veritabaniIslemleri.Bitir();

                            }
                        }                      
                    }
                    else
                    {
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                        lblMesaj.Text = "Bilgilerinizi kaydedemedik!";
                    }

                }
                else
                {
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblMesaj.Text = "Bilgilerinizi kaydedemedik!";
                    veritabaniIslemleri.GeriAl();
                }
                

            }
            else
            {
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                lblMesaj.Text = "Lütfen bir işletme türü seçiniz.";
            }
        }


    }
}