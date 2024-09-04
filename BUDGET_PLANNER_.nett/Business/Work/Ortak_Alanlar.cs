using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Work
{
    public class Ortak_Alanlar
    {
        public const string C_Sutun_id = "id";
        public const string C_Sutun_aktif_mi = "aktif_mi";

        int id;
        private string kullaniciAdSoyad = "";

        public string KullaniciAdSoyad
        {
            get { return kullaniciAdSoyad; }
        }



        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        VeritabaniIslemleri veritabaniIslem;

        public VeritabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }

        DataRow sonucKayit;

        protected DataRow SonucKayit
        {
            get { return sonucKayit; }
            set { sonucKayit = value; }
        }

        DataTable veriTablosu;

        public DataTable VeriTablosu
        {
            get { return veriTablosu; }
            set { veriTablosu = value; }
        }
    }
}
