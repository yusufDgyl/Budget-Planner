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
    public partial class BP_DefterAyarlari : System.Web.UI.Page
    {
        DefterIsletme defterIsletme;
        Defterler defterler;
        Oturum oturum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VeritabaniIslemleri veritabaniIslemleri = new VeritabaniIslemleri();
                defterIsletme = new DefterIsletme();
                oturum = new Oturum();
                defterler = new Defterler(veritabaniIslemleri);

                defterIsletme = (DefterIsletme)Session["DefterIsletme"];
                defterler.Id = defterIsletme.Defter.Id;

                oturum = (Oturum)Session["Oturum"];
                lblIsim.Text = oturum.KulAdi;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);

                if (defterler.Doldur())
                {
                    dListBilgilerim.DataSource = DtDondur(defterler);
                    dListBilgilerim.DataBind();
                }

                veritabaniIslemleri.Bitir();
                
            }


        }

        protected void btnKaydet_Click(object sender , EventArgs e)
        {
            if (txtDefterAdi != null && txtDefterAciklamasi != null)
            {
                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];
                defterler = defterIsletme.Defter;

                VeritabaniIslemleri veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);

                defterler = new Defterler(veritabaniIslemleri);

                defterler.Adi = txtDefterAdi.Text;
                defterler.Aciklamasi = txtDefterAciklamasi.Text;
                defterler.Id = defterIsletme.Defter.Id;
                defterler.Musteriler_id = defterIsletme.Defter.Musteriler_id;


                if (defterler.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                    lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");
                    lblKaydetMesaj.Text = "Kaydetme İşlemi Başarılı! Yönlendiriyoruz...";

                    defterIsletme.Defter = defterler;
                    Session["DefterIsletme"] = defterIsletme;

                    System.Threading.Thread.Sleep(1000);
                    Response.Redirect("BP_DefterAyarlari.aspx");
                }
                else
                {
                    veritabaniIslemleri.GeriAl();
                    lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                    lblKaydetMesaj.Text = "Kaydetme İşlemi Başarısız!";
                }


            }
            else
            {
                lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "red");
                lblKaydetMesaj.Text = "Alanları Doldurunuz!";
            }
        }

        private DataTable DtDondur(Defterler defterler)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("adi", typeof(string));
            dt.Columns.Add("aciklamasi", typeof(string));

            dt.Rows.Add(defterler.Adi, defterler.Aciklamasi);

            return dt;

        }
    }
}