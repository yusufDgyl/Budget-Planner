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
    public partial class BP_HesapSec : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        HesapTurleri hesapTurleri;
        DefterIsletme defterIsletme;
        Isletme isletme;
        protected void Page_Load(object sender, EventArgs e)
        {
            // id = 3 küçük işletme

            if (!IsPostBack)
            {
                veritabaniIslemleri = new VeritabaniIslemleri();
                defterIsletme = new DefterIsletme();
                defterIsletme = (DefterIsletme)Session["DefterIsletme"];

                if (defterIsletme.Isletme.Isletme_turleri_id == 4) // id = 4 büyük işletme
                {
                    hesapTurleri = new HesapTurleri(veritabaniIslemleri);
                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                    hesapTurleri.TumunuGetir();

                    dListNakit.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[0]);
                    dListNakit.DataBind();

                    dListBanka.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[1]);
                    dListBanka.DataBind();

                    dListKredi.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[2]);
                    dListKredi.DataBind();

                    dListBirikim.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[4]);
                    dListBirikim.DataBind();

                    dListCari.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[3]);
                    dListCari.DataBind();

                    dListPersonel.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[5]);
                    dListPersonel.DataBind();

                    dListStok.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[6]);
                    dListStok.DataBind();

                    veritabaniIslemleri.Bitir();
                }
                else
                {
                    pnlIsletmeTur.CssClass = "none";

                    hesapTurleri = new HesapTurleri(veritabaniIslemleri);
                    veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                    hesapTurleri.TumunuGetir();

                    dListNakit.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[0]);
                    dListNakit.DataBind();

                    dListBanka.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[1]);
                    dListBanka.DataBind();

                    dListKredi.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[2]);
                    dListKredi.DataBind();

                    dListBirikim.DataSource = DtDondur(hesapTurleri.VeriTablosu.Rows[4]);
                    dListBirikim.DataBind();

                    veritabaniIslemleri.Bitir();
                }
            }

        }
        private DataTable DtDondur(DataRow dataRow)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("tur", typeof(string));

            dt.Rows.Add(dataRow[0],dataRow[1]);
            return dt;
        }
    }
}