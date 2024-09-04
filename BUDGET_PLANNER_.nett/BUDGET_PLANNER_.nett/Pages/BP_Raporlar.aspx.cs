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
    public partial class Raporlar : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        DefterIsletme defterIsletme;
        IsletmeTurleri isletmeTurleri;
        IsletmeHesap isletmeHesap;
        HesapIslemleri hesapIslemleri;

        int nakitGelir = 0, NakitGider = 0, bankaGelir = 0, bankaGider = 0, krediKartiGelir = 0, krediKartiGider = 0, 
            birikimGelir = 0, birikimGider = 0, cariGelir = 0, cariGider = 0, personelGelir = 0, personelGider = 0, stokGelir = 0, stokGider = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            defterIsletme = new DefterIsletme();
            defterIsletme = (DefterIsletme)Session["DefterIsletme"];

            isletmeTurleri = new IsletmeTurleri(veritabaniIslemleri);
            isletmeTurleri.Id = defterIsletme.Isletme.Isletme_turleri_id;

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                

            // işletme türüne göre chart göstericem. büyük işletme ise stok ve personel alanlarını da göstereceğiz.
            if (isletmeTurleri.Doldur())
            {
                if (isletmeTurleri.Tur == "Küçük İşletme")
                {
                    pnlBuyukIsletme.Style.Add(HtmlTextWriterStyle.Display, "none");
                    pnlBuyukIsletmeRapor.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    pnlKucukIsletme.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }

            veritabaniIslemleri.Bitir();

            isletmeHesap = new IsletmeHesap(veritabaniIslemleri);
            isletmeHesap.Isletme_id = defterIsletme.Isletme.Id;

            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            isletmeHesap.IsletmeHesaplariniGetir(); // işletme hesap tablosundaki işletmeye ait bütün hesapları getirdik

            for (int i = 0; i < isletmeHesap.VeriTablosu.Rows.Count; i++)
            {
                hesapIslemleri = new HesapIslemleri(veritabaniIslemleri);
                hesapIslemleri.Isletme_hesap_id = Convert.ToInt32(isletmeHesap.VeriTablosu.Rows[i][0]);
                hesapIslemleri.IsletmeHesapIdGoreIslemleriGetir(); // işletme hesap id sini hesap işlemleri verdik ve o hesaptaki işlemleri tek tek çekeceğiz.

                string hesapTur = isletmeHesap.VeriTablosu.Rows[i][3].ToString();

                for (int j = 0; j < hesapIslemleri.VeriTablosu.Rows.Count; j++)
                {
                    switch (hesapTur)
                    {
                        case "Nakit":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    nakitGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    NakitGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    nakitGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Banka":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    bankaGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    bankaGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    bankaGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Kredi Kartı":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    krediKartiGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    krediKartiGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    krediKartiGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Birikim":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    birikimGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    birikimGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    birikimGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Cari":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    cariGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    cariGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    cariGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Personel":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    personelGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    personelGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    personelGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                        case "Stok":
                            {
                                if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "1") // gelir
                                {
                                    stokGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "2") // gider
                                {
                                    stokGider += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                else if (hesapIslemleri.VeriTablosu.Rows[j][2].ToString() == "3") // başlangıç bakiyesi
                                {
                                    stokGelir += Convert.ToInt32(hesapIslemleri.VeriTablosu.Rows[j][6]);
                                }
                                break;
                            }
                    }
                }

            }

            veritabaniIslemleri.Bitir();

            txtNakit.Text = nakitGelir.ToString() + " " + NakitGider.ToString();
            txtBanka.Text = bankaGelir.ToString() + " " + bankaGider.ToString();
            txtKrediKarti.Text = krediKartiGelir.ToString() + " " + krediKartiGider.ToString();
            txtBirikim.Text = birikimGelir.ToString() + " " + birikimGider.ToString();
            txtCari.Text = cariGelir.ToString() + " " + cariGider.ToString();
            txtPersonel.Text = personelGelir.ToString() + " " + personelGider.ToString();
            txtStok.Text = stokGelir.ToString() + " " + stokGider.ToString();

            lblNakit.Text = (nakitGelir - NakitGider).ToString();
            lblBanka.Text = (bankaGelir - bankaGider).ToString();
            lblKrediKarti.Text = (krediKartiGelir - krediKartiGider).ToString();
            lblBirikim.Text = (birikimGelir - birikimGider).ToString();
            lblCari.Text = (cariGelir - cariGider).ToString();
            lblPersonel.Text = (personelGelir - personelGider).ToString();
            lblStok.Text = (stokGelir - stokGider).ToString();

            List<Label> lbls = new List<Label>();
            lbls.Add(lblNakit);
            lbls.Add(lblBanka);
            lbls.Add(lblKrediKarti);
            lbls.Add(lblBirikim);
            lbls.Add(lblCari);
            lbls.Add(lblPersonel);
            lbls.Add(lblStok);

            LblRenkAyarla(lbls);
            ParaBirimi(lbls);
        }

        private void LblRenkAyarla( List<Label> lbls)
        {
            for (int i = 0; i < lbls.Count; i++)
            {
                if (Convert.ToInt16(lbls[i].Text) < 0)
                {
                    lbls[i].ForeColor = System.Drawing.Color.Red;
                }
                else if(Convert.ToInt16(lbls[i].Text) > 0)
                {
                    lbls[i].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbls[i].ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
        private void ParaBirimi (List<Label> lbls)
        {
            for (int i = 0; i < lbls.Count; i++)
            {
                lbls[i].Text = Convert.ToDecimal(lbls[i].Text).ToString("C");
            }
        }

    }
}