using Business.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Admin.MasterPages
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Oturum oturum = new Oturum();
            try
            {
                oturum = (Oturum)Session["OTURUM"];
                if (!oturum.LoginMi)
                {
                    Response.Redirect("../Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("../Login.aspx");
            }
            lblKullanici.Text = "Hoşgeldiniz " + oturum.KulAdi;
        }
    }
}