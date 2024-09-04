﻿using Business.Entity;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUDGET_PLANNER_.nett.Admin.Pages
{
    public partial class KullaniciListeleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VeritabaniIslemleri veritabaniIslemleri = new VeritabaniIslemleri();
            veritabaniIslemleri.Baslat(VeritabaniIslemleri.IslemTip.BAGIMSIZ);
            Kullanicilar kullanicilar = new Kullanicilar(veritabaniIslemleri);
            kullanicilar.TumunuGetir();

            dataList1.DataSource = kullanicilar.VeriTablosu;
            dataList1.DataBind();

            veritabaniIslemleri.Bitir();
        }
    }
}