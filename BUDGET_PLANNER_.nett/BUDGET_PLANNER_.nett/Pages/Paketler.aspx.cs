using Business.Work;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BUDGET_PLANNER_.nett.Pages
{
    public partial class Paketler : System.Web.UI.Page
    {
        List<string> dataLists = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataLists.Add("dtHomeH1");
            dataLists.Add("dtHomeP");
            dataLists.Add("dtPlansH1");
            dataLists.Add("dtMain");



            if (!IsPostBack)
            {
                VeritabaniIslemleri veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                Paketlerr paketler = new Paketlerr(veritabaniIslemleri);
                paketler.TumunuGetir();
                dtMain.DataSource = paketler.VeriTablosu;
                dtMain.DataBind();

                PaketlerSayfaTekrarsizMetinler paketlerTekrarsiz = new PaketlerSayfaTekrarsizMetinler(veritabaniIslemleri);
                paketlerTekrarsiz.Id = 1;
                paketlerTekrarsiz.Doldur();
                dtHomeH1.DataSource= DtDondur(paketlerTekrarsiz);
                dtHomeH1.DataBind();

                paketlerTekrarsiz.Id = 2;
                paketlerTekrarsiz.Doldur();
                dtHomeP.DataSource = DtDondur(paketlerTekrarsiz);
                dtHomeP.DataBind();

                paketlerTekrarsiz.Id = 3;
                paketlerTekrarsiz.Doldur();
                dtPlansH1.DataSource = DtDondur(paketlerTekrarsiz);
                dtPlansH1.DataBind();

                DataListStyle();
                
                veritabaniIslemleri.Bitir();
            }
        }
        public DataTable DtDondur(PaketlerSayfaTekrarsizMetinler paketler)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("adi", typeof(string));
            dt.Columns.Add("etiket", typeof(string));
            dt.Columns.Add("icerik", typeof(string));

            dt.Rows.Add(paketler.Id, paketler.Adi, paketler.Etiket, paketler.Icerik);

            return dt;
        }
        public void DataListStyle()
        {
            ContentPlaceHolder contentPlaceHolder = Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;

            if (contentPlaceHolder != null)
            {
                foreach (string item in dataLists)
                { // burada her bir datalistimize text align ve width veriyoruz ki css güzel gözüksün
                    DataList dt = (DataList)contentPlaceHolder.FindControl(item);

                    if (dt != null)
                    {
                        dt.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                        dt.Style.Add(HtmlTextWriterStyle.Width, "100%");
                        dt.DataBind();
                    }


                }
            }
        }
    }
}