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
    public partial class OrtakSayfalar : System.Web.UI.Page
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
                        lblIcerik.Text = sayfalar.Icerik;
                        
                    }
                    else
                    {
                        sayfalar.Id = 2;
                        sayfalar.Doldur();
                        lblIcerik.Text = sayfalar.Icerik;
                    }
                }
                catch
                {

                }

            }
        }
    }
}