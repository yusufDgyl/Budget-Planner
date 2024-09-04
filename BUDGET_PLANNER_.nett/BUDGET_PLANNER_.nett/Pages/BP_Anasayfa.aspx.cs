using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class BP_Anasayfa : System.Web.UI.Page
    {
        Oturum oturum;
        VeritabaniIslemleri veritabaniIslemleri;
        Defterler defterler;
        Isletme isletme;
        Musteriler musteriler;
        DefterIsletme defterIsletme;
        IsletmeHesap isletmeHesap;
        HesapTurleri hesapTurleri;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                pnlHesapBulunamadi.Visible = false;

                veritabaniIslemleri = new VeritabaniIslemleri();


                oturum = new Oturum();
                oturum = (Oturum)Session["Oturum"];

                defterIsletme = new DefterIsletme();


                veritabaniIslemleri = new VeritabaniIslemleri();
                musteriler = new Musteriler(veritabaniIslemleri);
                isletme = new Isletme(veritabaniIslemleri);
                defterler = new Defterler(veritabaniIslemleri);

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                musteriler.Id = oturum.Id;
                musteriler.Doldur();




                // seçilen isletmenin bilgilerini ve ait olduğu defter bilgilerini session'a atayacağız. isletme idsini querystring'den alacağız.

                if (Convert.ToInt16(Request.QueryString["ID"]) == 0) // 0 olma durumu gecis yap sayfası dışındaki sayfalardan anasayfaya tıklandığında olur.
                                                                     // Bu durumda müsterinin isletme bilgilerini zaten önceden almıs oldugumuz icin direk sessiondan cekiyoruz.
                {
                    defterIsletme = (DefterIsletme)Session["DefterIsletme"];
                    isletme = defterIsletme.Isletme;
                    defterler = defterIsletme.Defter;

                    hesapTurleri = new HesapTurleri(veritabaniIslemleri);
                    hesapTurleri.TumunuGetir();

                    if (isletme.Isletme_turleri_id == 3) // küçük işletme
                    {
                        dDownListHesaplar.Items.Add("Hepsi");
                        for (int i = 0; i < hesapTurleri.VeriTablosu.Rows.Count; i++)
                        {
                            if (i == 0 || i == 1 || i == 2 || i == 4)
                            {
                                dDownListHesaplar.Items.Add(hesapTurleri.VeriTablosu.Rows[i][1].ToString());
                            }
                        }
                    }
                    else // büyük işletme
                    {

                        dDownListHesaplar.Items.Add("Hepsi");
                        for (int i = 0; i < hesapTurleri.VeriTablosu.Rows.Count; i++)
                        {
                            dDownListHesaplar.Items.Add(hesapTurleri.VeriTablosu.Rows[i][1].ToString());
                        }
                    }


                }
                else
                { // anasayfaya ilk girişi veya işletme geçiş yap ekranından sonraki girişi!

                    isletme.Id = Convert.ToInt16(Request.QueryString["ID"]);
                    isletme.Doldur();

                    hesapTurleri = new HesapTurleri(veritabaniIslemleri);


                    hesapTurleri.TumunuGetir();

                    if (isletme.Isletme_turleri_id == 3) // küçük işletme
                    {
                        dDownListHesaplar.Items.Add("Hepsi");
                        for (int i = 0; i < hesapTurleri.VeriTablosu.Rows.Count; i++)
                        {
                            if (i == 0 || i == 1 || i == 2 || i == 4)
                            {
                                dDownListHesaplar.Items.Add(hesapTurleri.VeriTablosu.Rows[i][1].ToString());
                            }
                        }
                    }
                    else // büyük işletme
                    {

                        dDownListHesaplar.Items.Add("Hepsi");
                        for (int i = 0; i < hesapTurleri.VeriTablosu.Rows.Count; i++)
                        {
                            dDownListHesaplar.Items.Add(hesapTurleri.VeriTablosu.Rows[i][1].ToString());
                        }
                    }

                    defterler.Id = isletme.Defter_id;
                    defterler.Doldur();


                    defterIsletme.Defter = defterler;
                    defterIsletme.Isletme = isletme;

                    Session["DefterIsletme"] = defterIsletme;
                }
                veritabaniIslemleri.Bitir();


                lblMesaj.Text = "Hoşgeldin " + musteriler.Kul_adi + ", " + defterler.Adi + " defterinin " + isletme.Adi + " işletmesini yönetiyorsun!";

                List<TextBox> aylarTexts = new List<TextBox>();
                aylarTexts.Add(txtOcakValues);
                aylarTexts.Add(txtSubatValues);
                aylarTexts.Add(txtMartValues);
                aylarTexts.Add(txtNisanValues);
                aylarTexts.Add(txtMayisValues);
                aylarTexts.Add(txtHaziranValues);
                aylarTexts.Add(txtTemmuzValues);
                aylarTexts.Add(txtAgustosValues);
                aylarTexts.Add(txtEylulValues);
                aylarTexts.Add(txtEkimValues);
                aylarTexts.Add(txtKasimValues);
                aylarTexts.Add(txtAralikValues);


                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                for (int i = 1; i <= 12; i++)
                {
                    isletme.IsletmeAylıkGelirGider(i);

                    DataTable dt = new DataTable();
                    dt = dtDondurTekSatir(isletme);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        aylarTexts[i - 1].Text += dt.Rows[0][j] + " ";
                    }
                    aylarTexts[i - 1].Text = aylarTexts[i - 1].Text.Trim();

                }
                veritabaniIslemleri.Bitir();


                // işletmenin hesaplarını getiricez (ad,açıklama) ve o hesabın toplam gelir giderlerini getiricz

                isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                isletmeHesap.Isletme_id = isletme.Id;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                isletmeHesap.IsletmeHesaplariniGetir();
                dListHesaplar.DataSource = dtDondurTablo(isletmeHesap);
                dListHesaplar.DataBind();
                veritabaniIslemleri.Bitir();


            }





        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void dDownListHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            defterIsletme = new DefterIsletme();
            defterIsletme = (DefterIsletme)Session["DefterIsletme"];

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            if (dDownListHesaplar.Text == "Hepsi")
            {
                isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                isletmeHesap.Isletme_id = defterIsletme.Isletme.Id;

                isletmeHesap.IsletmeHesaplariniGetir();
                dListHesaplar.DataSource = dtDondurTablo(isletmeHesap);
                dListHesaplar.DataBind();

                if (dListHesaplar.Items.Count > 0)
                {
                    pnlHesapBulunamadi.Visible = false;

                }
                else
                {
                    pnlHesapBulunamadi.Visible = true;

                }

            }
            else
            {
                hesapTurleri = new HesapTurleri(veritabaniIslemleri);
                hesapTurleri.Tur = dDownListHesaplar.Text;
                hesapTurleri.DoldurTureGore();

                isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
                isletmeHesap.Isletme_id = defterIsletme.Isletme.Id;
                isletmeHesap.HesapTurleri_id = hesapTurleri.Id;
                isletmeHesap.IsletmeHesaplariniGetirHesapTuruneGore();

                dListHesaplar.DataSource = dtDondurTablo(isletmeHesap);
                dListHesaplar.DataBind();

                if (dListHesaplar.Items.Count > 0)
                {
                    pnlHesapBulunamadi.Visible = false;

                }
                else
                {
                    pnlHesapBulunamadi.Visible = true;

                }



            }

            veritabaniIslemleri.Bitir();



        }
        private DataTable dtDondurTekSatir(Isletme isletme)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Gelir", typeof(int));
            dt.Columns.Add("Gider", typeof(int));
            dt.Columns.Add("Başlangıç Bakiyesi", typeof(int));

            string gelir="0", gider="0", baslangicBakiyesi="0";

            if (isletme.VeriTablosu != null)
            {
                if (isletme.VeriTablosu.Rows.Count < 1)
                {
                    isletme.VeriTablosu.Rows.Add(0,0);
                    isletme.VeriTablosu.Rows.Add(0,0);
                    isletme.VeriTablosu.Rows.Add(0,0);
                }
                else if (isletme.VeriTablosu.Rows.Count < 2)
                {
                    isletme.VeriTablosu.Rows.Add(0,0);
                    isletme.VeriTablosu.Rows.Add(0,0);
                }
                else if (isletme.VeriTablosu.Rows.Count < 3)
                {
                    isletme.VeriTablosu.Rows.Add(0,0);
                }
            }
            for (int i = 0; i < isletme.VeriTablosu.Rows.Count; i++)
            {
                if (isletme.VeriTablosu.Rows[i][1].ToString() == "1") // gelir
                {
                    gelir = isletme.VeriTablosu.Rows[i][0].ToString();
                }
                else if (isletme.VeriTablosu.Rows[i][1].ToString() == "2") // gider 
                {
                    gider = isletme.VeriTablosu.Rows[i][0].ToString();

                }
                else if (isletme.VeriTablosu.Rows[i][1].ToString()== "3") // başlangıç bakiyesi
                {
                    baslangicBakiyesi = isletme.VeriTablosu.Rows[i][0].ToString();

                }
            }

            dt.Rows.Add(gelir, gider, baslangicBakiyesi);
            return dt;

        }

        private DataTable dtDondurTablo(IsletmeHesap isletmeHesap)
        {
            int gelir = 0, gider = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("adi", typeof(string));
            dt.Columns.Add("aciklamasi", typeof(string));
            dt.Columns.Add("tur", typeof(string));
            dt.Columns.Add("gelir", typeof(int));
            dt.Columns.Add("gider", typeof(int));

            veritabaniIslemleri = new VeritabaniIslemleri();
            HesapIslemleri hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

            for (int i = 0; i < isletmeHesap.VeriTablosu.Rows.Count; i++)
            {
                hesapIslemleri.Isletme_hesap_id = Convert.ToInt16(isletmeHesap.VeriTablosu.Rows[i][0]);
                hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir();

                for (int j = 0; j < hesapIslemleri.VeriTablosu.Rows.Count; j++)
                {
                    if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // Gelir
                    {
                        gelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                    }
                    else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // Gider
                    {
                        gider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                    }
                    else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // Başlangıç bakiyesi
                    {
                        gelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                    }
                }

                dt.Rows.Add(isletmeHesap.VeriTablosu.Rows[i][0], isletmeHesap.VeriTablosu.Rows[i][1], isletmeHesap.VeriTablosu.Rows[i][2], isletmeHesap.VeriTablosu.Rows[i][3], gelir, gider);

                gelir = 0;
                gider = 0;
            }



            return dt;





        }

        protected void btnYinedeSil_Click(object sender , EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
            isletme = new Isletme(veritabaniIslemleri);

            defterIsletme = new DefterIsletme();

            defterIsletme = (DefterIsletme)Session["DefterIsletme"];

            isletme.Id = defterIsletme.Isletme.Id;

            isletmeHesap.Id = Convert.ToInt32(hFHesapId.Value);

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

            if (isletmeHesap.Sil())
            {
                veritabaniIslemleri.Uygula();
            }
            else
            {
                veritabaniIslemleri.GeriAl();
            }

            veritabaniIslemleri.Bitir();


            isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
            isletmeHesap.Isletme_id = isletme.Id;

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            isletmeHesap.IsletmeHesaplariniGetir();
            dListHesaplar.DataSource = dtDondurTablo(isletmeHesap);
            dListHesaplar.DataBind();
            veritabaniIslemleri.Bitir();


        }
    }
}