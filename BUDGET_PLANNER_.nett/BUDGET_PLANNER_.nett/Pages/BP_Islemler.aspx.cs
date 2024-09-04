using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class BP_Islemler : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        IsletmeHesap isletmeHesap;
        DefterIsletme defterIsletme;
        HesapIslemleri hesapIslemleri;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Request.QueryString["IDislem"]) != 0) // eğerki anasayfadan işlem yap butonuna tıklanıp bu sayfaya yönlendirildiyse
            { // isletme hesap id sini çekiyoruz ve txtlere işlem yapılan hesabın adı ve açıklamasını yazdırıyoruz.
                veritabaniIslemleri = new VeritabaniIslemleri();
                isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                isletmeHesap.Id = Convert.ToInt32(Request.QueryString["IDislem"]);

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                if (isletmeHesap.Doldur())
                {
                    txtHesapAdi.Text = isletmeHesap.Adi;
                    txtHesapAciklamasi.Text = isletmeHesap.Aciklamasi;

                    txtHesapAdi.Enabled = false;
                    txtHesapAciklamasi.Enabled = false;


                }
                veritabaniIslemleri.Bitir();

            }
        }
        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtHesapAdi.Enabled) // işlemler menusune tıklayarak gelmek
            {
                if (txtHesapAdi.Text != "" && txtHesapAciklamasi.Text != "")
                {
                    if (txtIslemAdi.Text != "" && txtIslemAciklamasi.Text != "" && txtIslemTutar.Text != "")
                    {
                        if (pnlIslem.CssClass.Contains("green-box-shadow") || pnlIslem.CssClass.Contains("red-box-shadow") || pnlIslem.CssClass.Contains("blue-box-shadow"))
                        {
                            veritabaniIslemleri = new VeritabaniIslemleri();

                            defterIsletme = new DefterIsletme();
                            defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                            isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                            isletmeHesap.Adi = txtHesapAdi.Text;
                            isletmeHesap.Aciklamasi = txtHesapAciklamasi.Text;
                            isletmeHesap.Isletme_id = defterIsletme.Isletme.Id;
                            isletmeHesap.HesapTurleri_id = Convert.ToInt32(Request.QueryString["ID"]);

                            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                            if (!isletmeHesap.HesapVarmıKontrol()) // eğerki yeni hesap açılmışsa ve ilk defa bu hesapta işlem yapıyorsa
                            {
                                veritabaniIslemleri.Bitir();

                                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                                if (isletmeHesap.Ekle())
                                {
                                    veritabaniIslemleri.Uygula();
                                }
                                else
                                {
                                    veritabaniIslemleri.GeriAl();
                                }
                                veritabaniIslemleri.Bitir();

                                // IsletmeHesap tablosuna ekledik hesabı


                                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                                if (isletmeHesap.MaxIdDoldur()) // hesabın id'sine erişebilmek için son satırdaki hesabı çekiyoruz.
                                {
                                    hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
                                    hesapIslemleri.Isletme_hesap_id = isletmeHesap.Id;
                                    hesapIslemleri.Islem_adi = txtIslemAdi.Text;
                                    hesapIslemleri.Islem_aciklamasi = txtIslemAciklamasi.Text;
                                    hesapIslemleri.Islem_tutar = Convert.ToInt32(txtIslemTutar.Text);
                                    hesapIslemleri.Islem_tarihi = DateTime.Now;


                                    if (pnlIslem.CssClass.Contains("green-box-shadow"))
                                    { // 1
                                        hesapIslemleri.IslemTur_id = 1;
                                    }
                                    else if (pnlIslem.CssClass.Contains("red-box-shadow"))
                                    { // 2
                                        hesapIslemleri.IslemTur_id = 2;
                                    }
                                    else if (pnlIslem.CssClass.Contains("blue-box-shadow"))
                                    { // 3
                                        hesapIslemleri.IslemTur_id = 3;
                                    }


                                    veritabaniIslemleri.Bitir();

                                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                                    if (hesapIslemleri.Ekle())
                                    {
                                        veritabaniIslemleri.Uygula();
                                    }
                                    else
                                    {
                                        veritabaniIslemleri.GeriAl();
                                    }
                                    veritabaniIslemleri.Bitir();
                                    lblMesaj.Text = "";


                                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                                    hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();
                                    dListIslemleriGoruntule.DataSource = hesapIslemleri.VeriTablosu;
                                    dListIslemleriGoruntule.DataBind();

                                    TxtTemizle();



                                    if (!pnlIslemleriGoruntule.CssClass.Contains("visible"))
                                    {
                                        pnlIslemleriGoruntule.CssClass = "visible";
                                    }


                                }


                            }
                            else // 2. işlemini yapıyorsa yeni bir hesap oluşumunu engelliyoruz. aynı hesap üzerinden işlem yapması için.
                            {
                                veritabaniIslemleri.Bitir();

                                hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
                                hesapIslemleri.Isletme_hesap_id = isletmeHesap.Id;
                                hesapIslemleri.Islem_adi = txtIslemAdi.Text;
                                hesapIslemleri.Islem_aciklamasi = txtIslemAciklamasi.Text;
                                hesapIslemleri.Islem_tutar = Convert.ToInt32(txtIslemTutar.Text);
                                hesapIslemleri.Islem_tarihi = DateTime.Now;

                                if (pnlIslem.CssClass.Contains("green-box-shadow"))
                                { // 1
                                    hesapIslemleri.IslemTur_id = 1;
                                }
                                else if (pnlIslem.CssClass.Contains("red-box-shadow"))
                                { // 2
                                    hesapIslemleri.IslemTur_id = 2;
                                }
                                else if (pnlIslem.CssClass.Contains("blue-box-shadow"))
                                { // 3
                                    hesapIslemleri.IslemTur_id = 3;
                                }


                                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                                if (hesapIslemleri.Ekle())
                                {
                                    veritabaniIslemleri.Uygula();
                                }
                                else
                                {
                                    veritabaniIslemleri.GeriAl();
                                }
                                veritabaniIslemleri.Bitir();
                                lblMesaj.Text = "";



                                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                                hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();
                                dListIslemleriGoruntule.DataSource = hesapIslemleri.VeriTablosu;
                                dListIslemleriGoruntule.DataBind();

                                TxtTemizle();

                                if (!pnlIslemleriGoruntule.CssClass.Contains("visible"))
                                {
                                    pnlIslemleriGoruntule.CssClass = "visible";
                                }



                            }


                        }
                        else
                        {
                            lblMesaj.Text = "Bir işlem türü seçiniz!";
                        }
                    }
                    else
                    {
                        lblMesaj.Text = "İşlem bilgilerini doldurunuz!";
                    }
                }
                else
                {
                    lblMesaj.Text = "Hesap bilgilerini doldurunuz!";
                }
            }
            else // anasayfadaki işlem yap butonuna tıklayarak gelmek
            {
                if (txtIslemAdi.Text != "" && txtIslemTutar.Text != "" && txtIslemTutar.Text != "")
                {
                    veritabaniIslemleri = new VeritabaniIslemleri();
                    isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                    isletmeHesap.Id = Convert.ToInt32(Request.QueryString["IDislem"]);

                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                    if (isletmeHesap.Doldur())
                    {
                        hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
                        hesapIslemleri.Isletme_hesap_id = isletmeHesap.Id;
                        hesapIslemleri.Islem_adi = txtIslemAdi.Text;
                        hesapIslemleri.Islem_aciklamasi = txtIslemAciklamasi.Text;
                        hesapIslemleri.Islem_tutar = Convert.ToInt32(txtIslemTutar.Text);
                        hesapIslemleri.Islem_tarihi = DateTime.Now;

                        if (pnlIslem.CssClass.Contains("green-box-shadow"))
                        { // 1
                            hesapIslemleri.IslemTur_id = 1;
                        }
                        else if (pnlIslem.CssClass.Contains("red-box-shadow"))
                        { // 2
                            hesapIslemleri.IslemTur_id = 2;
                        }
                        else if (pnlIslem.CssClass.Contains("blue-box-shadow"))
                        { // 3
                            hesapIslemleri.IslemTur_id = 3;
                        }
                        veritabaniIslemleri.Bitir();


                        veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                        if (hesapIslemleri.Ekle())
                        {
                            veritabaniIslemleri.Uygula();
                        }
                        else
                        {
                            veritabaniIslemleri.GeriAl();
                        }
                        veritabaniIslemleri.Bitir();
                        lblMesaj.Text = "";



                        veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                        hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();
                        dListIslemleriGoruntule.DataSource = hesapIslemleri.VeriTablosu;
                        dListIslemleriGoruntule.DataBind();

                        TxtTemizle();

                        if (!pnlIslemleriGoruntule.CssClass.Contains("visible"))
                        {
                            pnlIslemleriGoruntule.CssClass = "visible";
                        }

                    }
                }
            }
        }
        protected void IslemTurGelir_Click(object sender, EventArgs e)
        {
            pnlIslem.CssClass = "green-box-shadow";

        }
        protected void IslemTurGider_Click(object sender, EventArgs e)
        {
            pnlIslem.CssClass = "red-box-shadow";
        }
        protected void IslemTurBaslangicBakiye_Click(object sender, EventArgs e)
        {
            pnlIslem.CssClass = "blue-box-shadow";
        }
        protected void btnDuzenleKaydet_Click(object sender, EventArgs e)
        {
            string islemAdi = "", islemAciklamasi = "", hesapIslemId = "";
            int islemTutar = 0;

            veritabaniIslemleri = new VeritabaniIslemleri();
            hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);

            foreach (DataListItem item in dListIslemleriGoruntule.Items)
            {
                hesapIslemId = ((TextBox)(item.FindControl("txtHesapIslemId"))).Text;
                islemAdi = ((TextBox)(item.FindControl("txtDuzenleIslemAdi"))).Text;
                islemAciklamasi = ((TextBox)(item.FindControl("txtDuzenleIslemAciklamasi"))).Text;
                islemTutar = Convert.ToInt32(((TextBox)(item.FindControl("txtDuzenleIslemTutar"))).Text);
            }
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            hesapIslemleri.Id = Convert.ToInt32(hesapIslemId);

            if (hesapIslemleri.Doldur())
            {
                veritabaniIslemleri.Bitir();
                hesapIslemleri.Islem_adi = islemAdi;
                hesapIslemleri.Islem_aciklamasi = islemAciklamasi;
                hesapIslemleri.Islem_tutar = islemTutar;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                if (hesapIslemleri.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }
                veritabaniIslemleri.Bitir();

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();
                dListIslemleriGoruntule.DataSource = hesapIslemleri.VeriTablosu;
                dListIslemleriGoruntule.DataBind();
                veritabaniIslemleri.Bitir();
            }



        }
        protected void btnYinedeSil_Click(object sender, EventArgs e)
        {
            string hesapIslemId = "";
            int isletmeHesapId;
            foreach (DataListItem item in dListIslemleriGoruntule.Items)
            {
                hesapIslemId = ((TextBox)(item.FindControl("txtHesapIslemId"))).Text;
            }


            veritabaniIslemleri = new VeritabaniIslemleri();
            hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
            hesapIslemleri.Id = Convert.ToInt32(hesapIslemId);

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            if (hesapIslemleri.Doldur()) // isletme hesap id sini çekmek için dolduuruyoruz.
            {

                isletmeHesapId = hesapIslemleri.Isletme_hesap_id;
                veritabaniIslemleri.Bitir();

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                if (hesapIslemleri.Sil())
                {
                    veritabaniIslemleri.Uygula();
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }
                veritabaniIslemleri.Bitir();


                hesapIslemleri.Isletme_hesap_id = isletmeHesapId;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();
                dListIslemleriGoruntule.DataSource = hesapIslemleri.VeriTablosu;
                dListIslemleriGoruntule.DataBind();
                veritabaniIslemleri.Bitir();


            }

        }
        protected void Box_Shadow_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }
        private void TxtTemizle()
        {
            txtIslemAciklamasi.Text = "";
            txtIslemAdi.Text = "";
            txtIslemTutar.Text = "";

            if (pnlIslem.CssClass.Contains("green-box-shadow"))
            { // 1
                pnlIslem.CssClass = pnlIslem.CssClass.Replace("green-box-shadow", "box-shadow-none");
            }
            else if (pnlIslem.CssClass.Contains("red-box-shadow"))
            { // 2
                pnlIslem.CssClass = pnlIslem.CssClass.Replace("red-box-shadow", "box-shadow-none");
            }
            else if (pnlIslem.CssClass.Contains("blue-box-shadow"))
            { // 3
                pnlIslem.CssClass = pnlIslem.CssClass.Replace("blue-box-shadow", "box-shadow-none");
            }
        }


        protected bool EnableOrDisable(object str)
        {
            if (str.ToString() != string.Empty)
                return false;
            else
                return true;
        }
    }
}