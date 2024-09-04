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
    public partial class BP_Notlar : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Notlar notlar;
        DefterIsletme defterIsletme;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                veritabaniIslemleri = new VeritabaniIslemleri();
                notlar = new Notlar(veritabaniIslemleri);
                notlar.Isletme_id = defterIsletme.Isletme.Id;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                notlar.IsletmeIdGoreNotlariGetir();

                dListNotlar.DataSource = notlar.VeriTablosu;
                dListNotlar.DataBind();

            }

            if (dListNotlar.Items.Count > 0)
            {
                pnlNotBulunamadi.Visible = false;
            }
            else
            {
                pnlNotBulunamadi.Visible = true;
            }

        }
        protected void btnNotOlustur_Click(object sender , EventArgs e)
        {
            if (txtAdi.Text != "" && txtAciklamasi.Text != "")
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                notlar = new Notlar(veritabaniIslemleri);
                notlar.Adi = txtAdi.Text;
                notlar.Aciklamasi = txtAciklamasi.Text;
                notlar.Tarih = DateTime.Now;

                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                notlar.Isletme_id = defterIsletme.Isletme.Id;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                if (notlar.Ekle())
                {
                    veritabaniIslemleri.Uygula();
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];
                notlar.Isletme_id = defterIsletme.Isletme.Id;


                notlar.IsletmeIdGoreNotlariGetir();
                dListNotlar.DataSource = notlar.VeriTablosu;
                dListNotlar.DataBind();
                veritabaniIslemleri.Bitir();

                if (dListNotlar.Items.Count > 0)
                {
                    pnlNotBulunamadi.Visible = false;
                }
                else
                {
                    pnlNotBulunamadi.Visible = true;
                }

                txtAdi.Text = "";
                txtAciklamasi.Text = "";
            }
            else
            {
                lblMesaj.Text = "Lütfen alanları doldurunuz!";
            }
        }
        protected void btnYinedeSil_Click(object sender , EventArgs e)
        {

            veritabaniIslemleri = new VeritabaniIslemleri();
            notlar = new Notlar(veritabaniIslemleri);

            notlar.Id = Convert.ToInt32(txtNotlarID.Text);


            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

            if (notlar.Sil())
            {
                veritabaniIslemleri.Uygula();
            }
            else
            {
                veritabaniIslemleri.GeriAl();
            }


            defterIsletme = (DefterIsletme)Session["DefterIsletme"];
            notlar.Isletme_id = defterIsletme.Isletme.Id;

            notlar.IsletmeIdGoreNotlariGetir();
            dListNotlar.DataSource = notlar.VeriTablosu;
            dListNotlar.DataBind();

            if (dListNotlar.Items.Count > 0)
            {
                pnlNotBulunamadi.Visible = false;
            }
            else
            {
                pnlNotBulunamadi.Visible = true;
            }

            veritabaniIslemleri.Bitir();

        }
        protected void btnNotDuzenleKaydet_Click(object sender , EventArgs e)
        {
            if (txtDuzenleNotAdi.Text != "" && txtDuzenleNotAciklamasi.Text != "")
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                notlar = new Notlar(veritabaniIslemleri);
                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                notlar.Id = Convert.ToInt32(txtNotlarID.Text);
                notlar.Isletme_id = defterIsletme.Isletme.Id;
                notlar.Adi = txtDuzenleNotAdi.Text;
                notlar.Aciklamasi = txtDuzenleNotAciklamasi.Text;
                notlar.Tarih = Convert.ToDateTime(txtDuzenleNotTarih.Text);

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                if (notlar.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                }
                veritabaniIslemleri.Bitir();

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                notlar.Isletme_id = defterIsletme.Isletme.Id;

                notlar.IsletmeIdGoreNotlariGetir();
                dListNotlar.DataSource = notlar.VeriTablosu;
                dListNotlar.DataBind();

                veritabaniIslemleri.Bitir();
            }
            else
            {
                lblDuzenleMesaj.Text = "Lütfen Alanları Doldurunuz!";
            }


        }
    }
}