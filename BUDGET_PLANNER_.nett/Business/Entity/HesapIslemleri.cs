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
    public class HesapIslemleri : Ortak_Alanlar , IOrtak_Metotlar
    {
        public HesapIslemleri(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }
        ~HesapIslemleri()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.HesapIslemleri";

        public const string C_Sp_Ekle = "dbo.SP_HesapIslemleri_EKLE";
        public const string C_Sp_Sil = "dbo.SP_HesapIslemleri_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_HesapIslemleri_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_HesapIslemleri_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_HesapIslemleri_TUMUNU_GETIR";
        public const string C_Sp_Isletme_Hesap_Id_Gore_Doldur = "dbo.SP_HesapIslemleri_ISLETME_HESAP_ID_GORE_DOLDUR";
        public const string C_Sp_Tarihe_Gore_Doldur = "dbo.SP_HesapIslemleri_DOLDUR_TARİHE_GORE";
        public const string C_Sp_Isletme_Hesap_Id_Gore_Islemleri_Getir = "dbo.SP_HesapIslemleri_ISLETME_HESAP_ID_GORE_ISLEMLERI_GETIR";
        




        public const string C_Sutun_isletme_hesap_id = "isletmeHesap_id";
        public const string C_Sutun_islemTur_id = "islemTur_id";
        public const string C_Sutun_islem_adi = "islem_adi";
        public const string C_Sutun_islem_aciklamasi = "islem_aciklamasi";
        public const string C_Sutun_islem_tarihi = "islem_tarihi";
        public const string C_Sutun_islem_tutar = "islem_tutar";



        #endregion

        #region Nesneler 

        private int isletme_hesap_id;
        public int Isletme_hesap_id
        {
            get { return isletme_hesap_id; }
            set { isletme_hesap_id = value; }
        }

        private int islemTur_id;
        public int IslemTur_id
        {
            get { return islemTur_id; }
            set { islemTur_id = value; }
        }

        private string islem_adi;
        public string Islem_adi
        {
            get { return islem_adi; }
            set { islem_adi = value; }
        }

        private string islem_aciklamasi;
        public string Islem_aciklamasi
        {
            get { return islem_aciklamasi; }
            set { islem_aciklamasi = value; }
        }

        private DateTime islem_tarihi;
        public DateTime Islem_tarihi
        {
            get { return islem_tarihi; }
            set { islem_tarihi = value; }
        }
        private int islem_tutar;

        public int Islem_tutar
        {
            get { return islem_tutar; }
            set { islem_tutar = value; }
        }
        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_hesap_id, Isletme_hesap_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_islemTur_id, IslemTur_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_adi, Islem_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_aciklamasi, Islem_aciklamasi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_tarihi, Islem_tarihi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_tutar, Islem_tutar);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_hesap_id, Isletme_hesap_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_islemTur_id, IslemTur_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_adi, Islem_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_aciklamasi, Islem_aciklamasi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_tarihi, Islem_tarihi);
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_tutar, Islem_tutar);

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
        public void IsletmeHesapIdGoreIslemleriGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Isletme_Hesap_Id_Gore_Islemleri_Getir;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_hesap_id, Isletme_hesap_id);
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
                Isletme_hesap_id = (int)SonucKayit[C_Sutun_isletme_hesap_id];
                IslemTur_id = (int)SonucKayit[C_Sutun_islemTur_id];
                Islem_adi = (string)SonucKayit[C_Sutun_islem_adi];
                Islem_aciklamasi = (string)SonucKayit[C_Sutun_islem_aciklamasi];
                Islem_tarihi = (DateTime)SonucKayit[C_Sutun_islem_tarihi];
                Islem_tutar = (int)SonucKayit[C_Sutun_islem_tutar];
                return true;
            }
            else
                return false;
        }
        public bool TariheGoreDoldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_Tarihe_Gore_Doldur;
            VeritabaniIslem.ParametreEkle(C_Sutun_islem_tarihi, Islem_tarihi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Isletme_hesap_id = (int)SonucKayit[C_Sutun_isletme_hesap_id];
                IslemTur_id = (int)SonucKayit[C_Sutun_islemTur_id];
                Islem_adi = (string)SonucKayit[C_Sutun_islem_adi];
                Islem_aciklamasi = (string)SonucKayit[C_Sutun_islem_aciklamasi];
                Islem_tarihi = (DateTime)SonucKayit[C_Sutun_islem_tarihi];
                Islem_tutar = (int)SonucKayit[C_Sutun_islem_tutar];
                return true;
            }
            else
                return false;
        }


        // bunun procedure silindi..
        public void IsletmeHesapIdGoreDoldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_Isletme_Hesap_Id_Gore_Doldur;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_hesap_id, Isletme_hesap_id);
            VeriTablosu = VeritabaniIslem.TabloGetir(); 
        }
        

        #endregion


    }
}
