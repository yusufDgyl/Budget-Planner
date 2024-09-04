using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Admin.Pages
{
    public partial class PaketDuzenle : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Paketlerr paketler;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    veritabaniIslemleri = new VeritabaniIslemleri();
                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                    paketler = new Paketlerr(veritabaniIslemleri);
                    paketler.TumunuGetir();

                    dDownList.Items.Add("<--- Seçiniz --->");

                    for (int i = 0; i < paketler.VeriTablosu.Rows.Count; i++)
                    {
                        dDownList.Items.Add(new ListItem(paketler.VeriTablosu.Rows[i][1].ToString()));
                    }

                    dDownList.DataBind();

                    paketler.Id = Convert.ToInt32(Request.QueryString["ID"]);

                    if (paketler.Id > 0)
                    {
                        lblID.Text = paketler.Id.ToString();
                        paketler.Doldur();
                        txtPaketAdi.Text = paketler.Adi;
                        txtPaketFiyat.Text = paketler.Fiyat;
                        txtListItem1.Text = paketler.Liste_item1;
                        txtListItem2.Text = paketler.Liste_item2;
                        txtListItem3.Text = paketler.Liste_item3;
                        txtListItem4.Text = paketler.Liste_item4;
                        txtListItem5.Text = paketler.Liste_item5;
                        txtBtnIcerik.Text = paketler.Buton_icerik;
                        txtHakkindaBaslik.Text = paketler.Paket_hakkinda_baslik;
                        txtHakkindaIcerik.Text = paketler.Paket_hakkinda_icerik;

                        TextsChanged(sender, e);

                        btnGuncelle.Visible = true;
                        btnSil.Visible = true;
                        btnEkle.Visible = false;
                    }
                    else
                    {
                        btnGuncelle.Visible = false;
                        btnSil.Visible = false;
                        btnEkle.Visible = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        protected void dDownListPaketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dDownList.SelectedIndex != 0)
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                paketler = new Paketlerr(veritabaniIslemleri);
                paketler.Adi = dDownList.Text;
                paketler.DoldurPaketAdi();

                lblID.Text = paketler.Id.ToString();

                txtPaketAdi.Text = paketler.Adi;
                txtPaketFiyat.Text = paketler.Fiyat;
                txtListItem1.Text = paketler.Liste_item1;
                txtListItem2.Text = paketler.Liste_item2;
                txtListItem3.Text = paketler.Liste_item3;
                txtListItem4.Text = paketler.Liste_item4;
                txtListItem5.Text = paketler.Liste_item5;
                txtBtnIcerik.Text = paketler.Buton_icerik;
                txtHakkindaBaslik.Text = paketler.Paket_hakkinda_baslik;
                txtHakkindaIcerik.Text = paketler.Paket_hakkinda_icerik;


                TextsChanged(sender, e);

                btnEkle.Visible = false;
                btnGuncelle.Visible = true;
                btnSil.Visible = true;

            }
            else
            {
                btnEkle.Visible = true;
                btnGuncelle.Visible = false;
                btnSil.Visible = false;

                Temizle();

            }
        }

        protected void TextsChanged(object sender, EventArgs e)
        {
            lblAdi.Text = txtPaketAdi.Text;
            lblFiyat.Text = txtPaketFiyat.Text;
            lblListItem1.Text = txtListItem1.Text;
            lblListItem2.Text = txtListItem2.Text;
            lblListItem3.Text = txtListItem3.Text;
            lblListItem4.Text = txtListItem4.Text;
            lblListItem5.Text = txtListItem5.Text;
            lblButonIcerik.Text = txtBtnIcerik.Text;
            lblButonIcerik2.Text = txtBtnIcerik.Text;
            lblHakkindaBaslik.Text = txtHakkindaBaslik.Text;
            lblHakkindaIcerik.Text = txtHakkindaIcerik.Text;
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPaketAdi.Text.Trim()) && !String.IsNullOrEmpty(txtPaketFiyat.Text.Trim()))
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                paketler = new Paketlerr(veritabaniIslemleri);
                paketler.Adi = txtPaketAdi.Text;
                if (!paketler.PaketAdi_VarMi())
                {

                    paketler.Adi = txtPaketAdi.Text;
                    paketler.Fiyat = txtPaketFiyat.Text;
                    paketler.Liste_item1 = txtListItem1.Text;
                    paketler.Liste_item2 = txtListItem2.Text;
                    paketler.Liste_item3 = txtListItem3.Text;
                    paketler.Liste_item4 = txtListItem4.Text;
                    paketler.Liste_item5 = txtListItem5.Text;
                    paketler.Buton_icerik = txtBtnIcerik.Text;
                    paketler.Paket_hakkinda_baslik = txtHakkindaBaslik.Text;
                    paketler.Paket_hakkinda_icerik = txtHakkindaIcerik.Text;


                    if (paketler.Ekle())
                    {
                        veritabaniIslemleri.Uygula();
                        lblMesaj.Text = "İşlem Başarılı!";
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                        Temizle();

                        dDownList.SelectedIndex = 0;

                    }
                    else
                    {
                        veritabaniIslemleri.GeriAl();
                    }
                }
                else
                {
                    lblMesaj.Text = "Girilen kullanıcı adı kullanılmaktadır!";
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");

                    Temizle();

                    dDownList.SelectedIndex = 0;

                    paketler.Adi = "";
                }
                veritabaniIslemleri.Bitir();

            }
            else
            {
                lblMesaj.Text = "İşlem Başarısız!";
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");

            }
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPaketAdi.Text.Trim()) && !String.IsNullOrEmpty(txtPaketFiyat.Text.Trim()))
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                paketler = new Paketlerr(veritabaniIslemleri);
                paketler.Id = Convert.ToInt32(lblID.Text);
                paketler.Adi = txtPaketAdi.Text;
                paketler.Fiyat = txtPaketFiyat.Text;
                paketler.Liste_item1 = txtListItem1.Text;
                paketler.Liste_item2 = txtListItem2.Text;
                paketler.Liste_item3 = txtListItem3.Text;
                paketler.Liste_item4 = txtListItem4.Text;
                paketler.Liste_item5 = txtListItem5.Text;
                paketler.Buton_icerik = txtBtnIcerik.Text;
                paketler.Paket_hakkinda_baslik = txtHakkindaBaslik.Text;
                paketler.Paket_hakkinda_icerik = txtHakkindaIcerik.Text;


                if (paketler.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                    lblMesaj.Text = "İşlem Başarılı!";
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                    Temizle();

                    dDownList.SelectedIndex = 0;

                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }
                veritabaniIslemleri.Bitir();
            }
            else
            {
                lblMesaj.Text = "İşlem Başarısız!";
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
            }
        }
        protected void btnSil_Click(object sender, EventArgs e)
        {
            veritabaniIslemleri = new VeritabaniIslemleri();
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
            paketler = new Paketlerr(veritabaniIslemleri);
            paketler.Id = Convert.ToInt32(lblID.Text);

            if (paketler.Sil())
            {
                veritabaniIslemleri.Uygula();
                lblMesaj.Text = "İşlem Başarılı!";
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                Temizle();

                dDownList.SelectedIndex = 0;

                Page_Load(sender, e);


            }
            else
            {
                veritabaniIslemleri.GeriAl();
                lblMesaj.Text = "İşlem Başarısız!";
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
            }
            veritabaniIslemleri.Bitir();
        }

        public void Temizle()
        {
            txtPaketAdi.Text = "";
            txtPaketFiyat.Text = "";
            txtListItem1.Text = "";
            txtListItem2.Text = "";
            txtListItem3.Text = "";
            txtListItem4.Text = "";
            txtListItem5.Text = "";
            txtBtnIcerik.Text = "";
            txtHakkindaBaslik.Text = "";
            txtHakkindaIcerik.Text = "";

            lblAdi.Text = "";
            lblFiyat.Text = "";
            lblListItem1.Text = "";
            lblListItem2.Text = "";
            lblListItem3.Text = "";
            lblListItem4.Text = "";
            lblListItem5.Text = "";
            lblButonIcerik.Text = "";
            lblButonIcerik2.Text = "";
            lblHakkindaBaslik.Text = "";
            lblHakkindaIcerik.Text = "";
        }
    }
}