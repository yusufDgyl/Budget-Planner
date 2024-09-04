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
    public partial class SayfaDetay : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Sayfalar sayfalar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    veritabaniIslemleri = new VeritabaniIslemleri();
                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                    sayfalar = new Sayfalar(veritabaniIslemleri);
                    sayfalar.Id = Convert.ToInt32(Request.QueryString["ID"]);
                    if (sayfalar.Id > 0)
                    {
                        sayfalar.Doldur();
                        lblSayfaId.Text = sayfalar.Id.ToString();
                        lblSayfaAdi.Text = sayfalar.Adi;
                        txtIcerik.Text = sayfalar.Icerik;
                    }
                    else
                    {
                        Response.Redirect("SayfaListeleme.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("SayfaListeleme.aspx");
                }

            }

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

            veritabaniIslemleri = new VeritabaniIslemleri();
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
            sayfalar = new Sayfalar(veritabaniIslemleri);
            sayfalar.Id = Convert.ToInt32(lblSayfaId.Text);
            sayfalar.Adi = lblSayfaAdi.Text;
            sayfalar.Icerik = txtIcerik.Text;
            if (sayfalar.Guncelle())
            {
                veritabaniIslemleri.Uygula();
            }
            else
            {
                veritabaniIslemleri.GeriAl();
            }
            veritabaniIslemleri.Bitir();

        }
    }
}