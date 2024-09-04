using Business.Work;
using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business.Entity
{
    public class Sayfalar : Ortak_Alanlar, IOrtak_Metotlar
    {
        public Sayfalar(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~Sayfalar()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }
        #region Sabitler  

        public const string C_Tablo = "dbo.Sayfalar";

        public const string C_Sp_Ekle = "dbo.SP_Sayfalar_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Sayfalar_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Sayfalar_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Sayfalar_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Sayfalar_TUMUNU_GETIR";

        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_icerik = "icerik";


        #endregion

        #region Nesneler 


        private string adi;
        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string icerik;
        public string Icerik
        {
            get { return icerik; }
            set { icerik = value; }
        }


        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_icerik, Icerik);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_icerik, Icerik);
            return VeritabaniIslem.Calistir();
        }

        public bool Sil()
        {
            VeritabaniIslem.SpAdi = C_Sp_Sil;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            return VeritabaniIslem.Calistir();
        }

        public void TumunuGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_TumunuGetir;
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public bool Doldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Icerik = (string)SonucKayit[C_Sutun_icerik];
                return true;
            }
            else
                return false;
        }

        #endregion

    }
}
