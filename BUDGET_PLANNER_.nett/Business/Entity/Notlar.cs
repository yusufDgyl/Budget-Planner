using Business.Interface;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Notlar : Ortak_Alanlar , IOrtak_Metotlar
    {
        public Notlar(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~Notlar()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.Notlar";

        public const string C_Sp_Ekle = "dbo.SP_Notlar_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Notlar_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Notlar_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Notlar_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Notlar_TUMUNU_GETIR";
        public const string C_Sp_Isletme_Id_Gore_Notlari_Getir = "dbo.SP_Notlar_ISLETME_ID_GORE_NOTLARI_GETIR";


        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_aciklamasi = "aciklamasi";
        public const string C_Sutun_tarih = "tarih";
        public const string C_Sutun_isletme_id = "isletme_id";



        #endregion

        #region Nesneler 


        private string adi;
        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string aciklamasi;
        public string Aciklamasi
        {
            get { return aciklamasi; }
            set { aciklamasi = value; }
        }

        private int isletme_id;
        public int Isletme_id
        {
            get { return isletme_id; }
            set { isletme_id = value; }
        }
        private DateTime tarih;
        public DateTime Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }


        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);
            VeritabaniIslem.ParametreEkle(C_Sutun_tarih, Tarih);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);
            VeritabaniIslem.ParametreEkle(C_Sutun_tarih, Tarih);
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
        public void IsletmeIdGoreNotlariGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Isletme_Id_Gore_Notlari_Getir;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
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
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                Tarih = (DateTime)SonucKayit[C_Sutun_tarih];
                Isletme_id = (int)SonucKayit[C_Sutun_isletme_id];

                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
