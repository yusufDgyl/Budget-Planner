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
    public partial class BP_IsletmeGecisYapp : System.Web.UI.Page
    {
        VeritabaniIslemleri veritabaniIslemleri;
        Musteriler musteriler;
        Oturum oturum;
        DefterIsletme defterIsletme;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                defterIsletme = new DefterIsletme();
                oturum = new Oturum();
                oturum = (Oturum)Session["Oturum"];
                veritabaniIslemleri = new VeritabaniIslemleri();
                veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
                musteriler = new Musteriler(veritabaniIslemleri);
                musteriler.Id = oturum.Id;
                // müşteri id sine göre isletme ve defter bilgilerini join kullanarak getiriyorum.
                musteriler.MusteriDefterIsletmeBilgileriGetir();
                //isletme-id, isletme-Tur ,isletme-adi , isletme-aciklamasi , defter-adi , defter-aciklamasi bilgilerini çekiyorum
                dListIsletme.DataSource = musteriler.VeriTablosu;
                dListIsletme.DataBind();               


                veritabaniIslemleri.Bitir();



            }
        }
    }
}