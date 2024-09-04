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
    public class Kullanicilar : Ortak_Alanlar , IOrtak_Metotlar
    {
        public Kullanicilar(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~Kullanicilar()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.Kullanicilar";

        public const string C_Sp_Ekle = "dbo.SP_Kullanicilar_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Kullanicilar_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Kullanicilar_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Kullanicilar_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Kullanicilar_TUMUNU_GETIR";
        public const string C_Sp_Login = "dbo.SP_Kullanicilar_LOGIN";
        public const string C_Sp_Doldur_KulAdi = "dbo.SP_Kullanicilar_DOLDUR_KULADI";

        public const string C_Sutun_kul_adi = "kul_adi";
        public const string C_Sutun_sifre = "sifre";
        public const string C_Sutun_durum = "durum";


        #endregion

        #region Nesneler 


        private string kul_adi;
        public string Kul_adi
        {
            get { return kul_adi; }
            set { kul_adi = value; }
        }

        private string sifre;
        public string Sifre
        {
            get { return sifre; }
            set { sifre = value; }
        }

        private bool durum;
        public bool Durum
        {
            get { return durum; }
            set { durum = value; }
        }


        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_sifre, Sifre);
            VeritabaniIslem.ParametreEkle(C_Sutun_durum, Durum);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_sifre, Sifre);
            VeritabaniIslem.ParametreEkle(C_Sutun_durum, Durum);
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
                Kul_adi = (string)SonucKayit[C_Sutun_kul_adi];
                Sifre = (string)SonucKayit[C_Sutun_sifre];
                Durum = (bool)SonucKayit[C_Sutun_durum];
                return true;
            }
            else
                return false;
        }
        public bool DoldurKulAdi()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_KulAdi;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Kul_adi = (string)SonucKayit[C_Sutun_kul_adi];
                Sifre = (string)SonucKayit[C_Sutun_sifre];
                Durum = (bool)SonucKayit[C_Sutun_durum];
                return true;
            }
            else
                return false;
        }
        public bool Login()
        {
            VeritabaniIslem.SpAdi = C_Sp_Login;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_sifre, Sifre);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                return true;
            }
            else
                return false;
        }
        public bool KulAdi_VarMi()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_KulAdi;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

    }
}
