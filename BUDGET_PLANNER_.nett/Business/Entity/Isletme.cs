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
    public class Isletme : Ortak_Alanlar, IOrtak_Metotlar
    {
        public Isletme(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }
        ~Isletme()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }
        public enum Aylar
        {
            OCAK,
            SUBAT,
            MART,
            NISAN,
            MAYIS,
            HAZIRAN,
            TEMMUZ,
            AGUSTOS,
            EYLUL,
            EKIM,
            KASIM,
            ARALIK
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.Isletme";

        public const string C_Sp_Ekle = "dbo.SP_Isletme_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Isletme_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Isletme_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Isletme_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Isletme_TUMUNU_GETIR";
        public const string C_Sp_Doldur_Defter_Id_Gore = "dbo.SP_Isletme_DOLDUR_DEFTER_ID_GORE";
        public const string C_Sp_Aylik_Gelir_Gider = "dbo.SP_Isletme_AYLIK_GELIR_GIDER";
        public const string C_Sp_Max_Id_Getir = "dbo.SP_Isletme_MAX_ID_GETIR";

        public const string C_Sutun_defter_id = "defter_id";
        public const string C_Sutun_isletme_turleri_id = "isletme_turleri_id";
        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_aciklamasi = "aciklamasi";
        public const string C_Sutun_ay = "ay";



        #endregion

        #region Nesneler 

        private int defter_id;
        public int Defter_id
        {
            get { return defter_id; }
            set { defter_id = value; }
        }

        private int isletme_turleri_id;

        public int Isletme_turleri_id
        {
            get { return isletme_turleri_id; }
            set { isletme_turleri_id = value; }
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
            VeritabaniIslem.ParametreEkle(C_Sutun_defter_id, Defter_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_turleri_id, Isletme_turleri_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_defter_id, Defter_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_isletme_turleri_id, Isletme_turleri_id);
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
        public bool Doldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);  
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Defter_id = (int)SonucKayit[C_Sutun_defter_id];
                Isletme_turleri_id = (int)SonucKayit[C_Sutun_isletme_turleri_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                return true;
            }
            else
                return false;
        }
        public void DoldurDefterIdGoreTabloGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_Defter_Id_Gore;
            VeritabaniIslem.ParametreEkle(C_Sutun_defter_id, Defter_id);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public void IsletmeAylıkGelirGider(Aylar aylar)
        {
            VeritabaniIslem.SpAdi = C_Sp_Aylik_Gelir_Gider;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_ay, (int)aylar+1);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public void IsletmeAylıkGelirGider(int aylar)
        {
            VeritabaniIslem.SpAdi = C_Sp_Aylik_Gelir_Gider;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_ay, aylar);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public bool MaxIdGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Max_Id_Getir;
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
