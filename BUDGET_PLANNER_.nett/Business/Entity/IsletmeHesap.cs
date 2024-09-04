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
    public class IsletmeHesap : Ortak_Alanlar , IOrtak_Metotlar
    {
        public IsletmeHesap(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }
        ~IsletmeHesap()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.IsletmeHesap";

        public const string C_Sp_Ekle = "dbo.SP_IsletmeHesap_EKLE";
        public const string C_Sp_Sil = "dbo.SP_IsletmeHesap_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_IsletmeHesap_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_IsletmeHesap_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_IsletmeHesap_TUMUNU_GETIR";
        public const string C_Sp_Max_Id_Doldur = "dbo.SP_IsletmeHesap_MAX_ID_DOLDUR";
        public const string C_Sp_Hesap_Varmı_Kontrol = "dbo.SP_IsletmeHesap_HESAP_VARMI_KONTROL";
        public const string C_Sp_Isletme_Hesaplarini_Getir = "dbo.SP_IsletmeHesap_ISLETME_ID_GORE_HESAPLARI_GETIR";
        public const string C_Sp_Isletme_Hesaplarini_Getir_Hesap_Turune_Gore = "dbo.SP_IsletmeHesap_HESAP_TURUNE_GORE_ISLETME_BILGILERINI_GETIR";





        public const string C_Sutun_isletme_id = "isletme_id";
        public const string C_Sutun_hesapTurleri_id = "hesapTurleri_id";
        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_aciklamasi = "aciklamasi";



        #endregion

        #region Nesneler 

        private int isletme_id;
        public int Isletme_id
        {
            get { return isletme_id; }
            set { isletme_id = value; }
        }

        private int hesapTurleri_id;
        public int HesapTurleri_id
        {
            get { return hesapTurleri_id; }
            set { hesapTurleri_id = value; }
        }

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

        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_hesapTurleri_id, HesapTurleri_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_hesapTurleri_id, HesapTurleri_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);

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
        public void IsletmeHesaplariniGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Isletme_Hesaplarini_Getir;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public void IsletmeHesaplariniGetirHesapTuruneGore()
        {
            VeritabaniIslem.SpAdi = C_Sp_Isletme_Hesaplarini_Getir_Hesap_Turune_Gore;
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_hesapTurleri_id, HesapTurleri_id);
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
                Isletme_id = (int)SonucKayit[C_Sutun_isletme_id];
                HesapTurleri_id = (int)SonucKayit[C_Sutun_hesapTurleri_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                return true;
            }
            else
                return false;
        }
        public bool MaxIdDoldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_Max_Id_Doldur;
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Isletme_id = (int)SonucKayit[C_Sutun_isletme_id];
                HesapTurleri_id = (int)SonucKayit[C_Sutun_hesapTurleri_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                return true;
            }
            else
                return false;
        }
        public bool HesapVarmıKontrol()
        {
            VeritabaniIslem.SpAdi = C_Sp_Hesap_Varmı_Kontrol;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_id, Isletme_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_hesapTurleri_id, HesapTurleri_id);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Isletme_id = (int)SonucKayit[C_Sutun_isletme_id];
                HesapTurleri_id = (int)SonucKayit[C_Sutun_hesapTurleri_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                return true;
            }
            else
                return false;
        }


        #endregion
    }
}
