using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Admin.Pages
{
    public partial class KullaniciDuzenle : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Kullanicilar kullanicilar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    veritabaniIslemleri = new VeritabaniIslemleri();
                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                    kullanicilar = new Kullanicilar(veritabaniIslemleri);
                    kullanicilar.TumunuGetir();

                    dDownListKul.Items.Add("<--- Seçiniz --->");

                    for (int i = 0; i < kullanicilar.VeriTablosu.Rows.Count; i++)
                    {
                        dDownListKul.Items.Add(new ListItem(kullanicilar.VeriTablosu.Rows[i][1].ToString()));
                    }

                    dDownListKul.DataBind();
                    kullanicilar.Id = Convert.ToInt32(Request.QueryString["ID"]);

                    if (kullanicilar.Id > 0)
                    {
                        kullanicilar.Doldur();
                        lblId.Text = kullanicilar.Id.ToString();
                        txtKulAdi.Text = kullanicilar.Kul_adi;
                        txtSifre.Text = kullanicilar.Sifre;
                        if (kullanicilar.Durum == true)
                        {
                            rbAcik.Checked = true;
                        }
                        else
                        {
                            rbKapali.Checked = true;
                        }
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
        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtKulAdi.Text.Trim()) && !String.IsNullOrEmpty(txtSifre.Text.Trim()))
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                kullanicilar = new Kullanicilar(veritabaniIslemleri);
                kullanicilar.Kul_adi = txtKulAdi.Text;
                if (!kullanicilar.KulAdi_VarMi())
                {

                    kullanicilar.Kul_adi = txtKulAdi.Text;
                    kullanicilar.Sifre = txtSifre.Text;
                    if (rbAcik.Checked)
                    {
                        kullanicilar.Durum = true;
                    }
                    else
                    {
                        kullanicilar.Durum = false;
                    }
                    if (kullanicilar.Ekle())
                    {
                        veritabaniIslemleri.Uygula();
                        lblMesaj.Text = "İşlem Başarılı!";
                        lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                        txtKulAdi.Text = "";
                        txtSifre.Text = "";
                        lblId.Text = "";
                        txtTekrarSifre.Text = "";

                        rbAcik.Checked = false;
                        rbKapali.Checked = false;

                        dDownListKul.SelectedIndex = 0;

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

                    txtKulAdi.Text = "";
                    txtSifre.Text = "";
                    lblId.Text = "";
                    txtTekrarSifre.Text = "";

                    dDownListKul.SelectedIndex = 0;

                    kullanicilar.Kul_adi = "";
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
            if (!String.IsNullOrEmpty(txtKulAdi.Text.Trim()) && !String.IsNullOrEmpty(txtSifre.Text.Trim()))
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                kullanicilar = new Kullanicilar(veritabaniIslemleri);
                kullanicilar.Id = Convert.ToInt32(lblId.Text);
                kullanicilar.Kul_adi = txtKulAdi.Text;
                kullanicilar.Sifre = txtSifre.Text;
                if (rbAcik.Checked)
                {
                    kullanicilar.Durum = true;
                }
                else
                {
                    kullanicilar.Durum = false;
                }
                if (kullanicilar.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                    lblMesaj.Text = "İşlem Başarılı!";
                    lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                    txtKulAdi.Text = "";
                    txtSifre.Text = "";
                    lblId.Text = "";
                    txtTekrarSifre.Text = "";

                    rbAcik.Checked = false;
                    rbKapali.Checked = false;

                    dDownListKul.SelectedIndex = 0;

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
            kullanicilar = new Kullanicilar(veritabaniIslemleri);
            kullanicilar.Id = Convert.ToInt32(lblId.Text);
            if (kullanicilar.Sil())
            {
                veritabaniIslemleri.Uygula();
                lblMesaj.Text = "İşlem Başarılı!";
                lblMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");

                txtKulAdi.Text = "";
                txtSifre.Text = "";
                lblId.Text = "";
                txtTekrarSifre.Text = "";
                rbAcik.Checked = false;
                rbKapali.Checked = false;

                dDownListKul.SelectedIndex = 0;

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
        protected void dDownListKul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dDownListKul.SelectedIndex != 0)
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                kullanicilar = new Kullanicilar(veritabaniIslemleri);
                kullanicilar.Kul_adi = dDownListKul.Text;
                kullanicilar.DoldurKulAdi();

                lblId.Text = kullanicilar.Id.ToString();
                txtKulAdi.Text = kullanicilar.Kul_adi;
                txtSifre.Text = kullanicilar.Sifre;

                if (kullanicilar.Durum == true)
                {
                    rbAcik.Checked = true;
                    rbKapali.Checked = false;
                }
                else
                {
                    rbKapali.Checked = true;
                    rbAcik.Checked = true;
                }


                btnEkle.Visible = false;
                btnGuncelle.Visible = true;
                btnSil.Visible = true;

            }
            else
            {
                btnEkle.Visible = true;
                btnGuncelle.Visible = false;
                btnSil.Visible = false;

                txtKulAdi.Text = "";
                txtSifre.Text = "";
                lblId.Text = "";
                txtTekrarSifre.Text = "";
                rbAcik.Checked = false;
                rbKapali.Checked = false;
            }
        }

    }
}