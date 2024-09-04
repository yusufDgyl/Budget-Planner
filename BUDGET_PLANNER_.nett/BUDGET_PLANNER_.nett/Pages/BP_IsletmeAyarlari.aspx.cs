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
    public partial class BP_IsletmeAyarlari : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Isletme isletme;
        DefterIsletme defterIsletme;
        Oturum oturum;
        IsletmeTurleri isletmeTurleri;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oturum = new Oturum();
                oturum = (Oturum)Session["Oturum"];
                lblIsim.Text = oturum.KulAdi;

                veritabaniIslemleri = new VeritabaniIslemleri();
                isletme = new Isletme(veritabaniIslemleri);

                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                isletme.Id = defterIsletme.Isletme.Id;

                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                if (isletme.Doldur())
                {
                    dListBilgilerim.DataSource = DtDondur(isletme);
                    dListBilgilerim.DataBind();
                }
            }

        }
        protected void btnKaydet_Click(object sender ,EventArgs e)
        {
            if (txtIsletmeAdi.Text != "" && txtIsletmeAciklamasi.Text != "")
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGLI);
                isletme = new Isletme(veritabaniIslemleri);
                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];
                isletme.Id = defterIsletme.Isletme.Id;
                isletme.Defter_id = defterIsletme.Isletme.Defter_id;
                isletme.Adi = txtIsletmeAdi.Text;
                isletme.Aciklamasi = txtIsletmeAciklamasi.Text;
                isletme.Isletme_turleri_id = defterIsletme.Isletme.Isletme_turleri_id;


                if (isletme.Guncelle())
                {
                    veritabaniIslemleri.Uygula();
                    lblKaydetMesaj.Style.Add(HtmlTextWriterStyle.Color, "green");
                    lblKaydetMesaj.Text = "Kaydetme İşlemi Başarılı! Yönlendiriyoruz...";

                    defterIsletme.Isletme = isletme;
                    Session["DefterIsletme"] = defterIsletme;


                    System.Threading.Thread.Sleep(1000);
                    Response.Redirect("BP_IsletmeAyarlari.aspx");
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
        private DataTable DtDondur(Isletme isletme)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("adi", typeof(string));
            dt.Columns.Add("aciklamasi", typeof(string));
            dt.Columns.Add("tur", typeof(string));

            veritabaniIslemleri = new VeritabaniIslemleri();
            isletmeTurleri = new IsletmeTurleri(veritabaniIslemleri);
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            isletmeTurleri.Id = isletme.Isletme_turleri_id;
            isletmeTurleri.Doldur();

            veritabaniIslemleri.Bitir();

            dt.Rows.Add(isletme.Adi, isletme.Aciklamasi, isletmeTurleri.Tur);

            return dt;
        }
    }
    
}