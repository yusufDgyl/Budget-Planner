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
    public class Defterler : Ortak_Alanlar, IOrtak_Metotlar 
    {
        public Defterler(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }
        ~Defterler()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.Defterler";

        public const string C_Sp_Ekle = "dbo.SP_Defterler_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Defterler_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Defterler_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Defterler_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Defterler_TUMUNU_GETIR";
        public const string C_Sp_Max_id = "dbo.SP_Defterler_MAX_ID";
        public const string C_Sp_Doldur_Musteri_Id_Gore = "SP_Defterler_DOLDUR_MUSTERI_ID_GORE";

        public const string C_Sutun_musteriler_id = "musteriler_id";
        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_aciklamasi = "aciklamasi";


        #endregion

        #region Nesneler 

        private int musteriler_id;
        public int Musteriler_id
        {
            get { return musteriler_id; }
            set { musteriler_id = value; }
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
            VeritabaniIslem.ParametreEkle(C_Sutun_musteriler_id, Musteriler_id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_aciklamasi, Aciklamasi);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_musteriler_id, Musteriler_id);
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
                Musteriler_id = (int)SonucKayit[C_Sutun_musteriler_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Aciklamasi = (string)SonucKayit[C_Sutun_aciklamasi];
                return true;
            }
            else
                return false;
        }
        public void DoldurKuldTabloGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_Musteri_Id_Gore;
            VeritabaniIslem.ParametreEkle(C_Sutun_musteriler_id, Musteriler_id);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }
        public bool MaxIdGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_Max_id;
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
