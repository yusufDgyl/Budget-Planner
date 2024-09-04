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
    public class Paketlerr : Ortak_Alanlar,IOrtak_Metotlar 
    {
        public Paketlerr(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~Paketlerr()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler

        public const string C_Tablo = "dbo.Paketler";

            public const string C_Sp_Ekle = "dbo.SP_Paketler_EKLE";
            public const string C_Sp_Sil = "dbo.SP_Paketler_SIL";
            public const string C_Sp_Guncelle = "dbo.SP_Paketler_GUNCELLE";
            public const string C_Sp_Doldur = "dbo.SP_Paketler_DOLDUR";
            public const string C_Sp_TumunuGetir = "dbo.SP_Paketler_TUMUNU_GETIR";
            public const string C_Sp_Doldur_Paket_Adi = "dbo.SP_Paketler_DOLDUR_PAKET_ADI";


            public const string C_Sutun_adi = "adi";
            public const string C_Sutun_fiyat = "fiyat";
            public const string C_Sutun_liste_item1 = "liste_item1";
            public const string C_Sutun_liste_item2 = "liste_item2";
            public const string C_Sutun_liste_item3 = "liste_item3";
            public const string C_Sutun_liste_item4 = "liste_item4";
            public const string C_Sutun_liste_item5 = "liste_item5";
            public const string C_Sutun_buton_icerik = "buton_icerik";
            public const string C_Sutun_paket_hakkinda_baslik = "paket_hakkinda_baslik";
            public const string C_Sutun_paket_hakkinda_icerik = "paket_hakkinda_icerik";

        #endregion

        #region Nesneler


        private string adi;
        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string fiyat;

        public string Fiyat
        {
            get { return fiyat; }
            set { fiyat = value; }
        }
        public string liste_item1;

        public string Liste_item1
        {
            get { return liste_item1; }
            set { liste_item1 = value; }
        }

        public string liste_item2;

        public string Liste_item2
        {
            get { return liste_item2; }
            set { liste_item2 = value; }
        }

        public string liste_item3;

        public string Liste_item3
        {
            get { return liste_item3; }
            set { liste_item3 = value; }
        }

        public string liste_item4;

        public string Liste_item4
        {
            get { return liste_item4; }
            set { liste_item4 = value; }
        }

        public string liste_item5;

        public string Liste_item5
        {
            get { return liste_item5; }
            set { liste_item5 = value; }
        }

        public string buton_icerik;

        public string Buton_icerik
        {
            get { return buton_icerik; }
            set { buton_icerik = value; }
        }

        public string paket_hakkinda_baslik;

        public string Paket_hakkinda_baslik
        {
            get { return paket_hakkinda_baslik; }
            set { paket_hakkinda_baslik = value; }
        }

        public string paket_hakkinda_icerik;

        public string Paket_hakkinda_icerik
        {
            get { return paket_hakkinda_icerik; }
            set { paket_hakkinda_icerik = value; }
        }

        #endregion

        #region Metotlar

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_fiyat, Fiyat);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item1, Liste_item1);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item2, Liste_item2);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item3, Liste_item3);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item4, Liste_item4);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item5, Liste_item5);
            VeritabaniIslem.ParametreEkle(C_Sutun_buton_icerik, Buton_icerik);
            VeritabaniIslem.ParametreEkle(C_Sutun_paket_hakkinda_baslik, Paket_hakkinda_baslik);
            VeritabaniIslem.ParametreEkle(C_Sutun_paket_hakkinda_icerik, Paket_hakkinda_icerik);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_fiyat, Fiyat);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item1, Liste_item1);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item2, Liste_item2);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item3, Liste_item3);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item4, Liste_item4);
            VeritabaniIslem.ParametreEkle(C_Sutun_liste_item5, Liste_item5);
            VeritabaniIslem.ParametreEkle(C_Sutun_buton_icerik, Buton_icerik);
            VeritabaniIslem.ParametreEkle(C_Sutun_paket_hakkinda_baslik, Paket_hakkinda_baslik);
            VeritabaniIslem.ParametreEkle(C_Sutun_paket_hakkinda_icerik, Paket_hakkinda_icerik);
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
                Fiyat = (string)SonucKayit[C_Sutun_fiyat];
                Liste_item1 = (string)SonucKayit[C_Sutun_liste_item1];
                Liste_item2 = (string)SonucKayit[C_Sutun_liste_item2];
                Liste_item3 = (string)SonucKayit[C_Sutun_liste_item3];
                Liste_item4 = (string)SonucKayit[C_Sutun_liste_item4];
                Liste_item5 = (string)SonucKayit[C_Sutun_liste_item5];
                Buton_icerik = (string)SonucKayit[C_Sutun_buton_icerik];
                Paket_hakkinda_baslik = (string)SonucKayit[C_Sutun_paket_hakkinda_baslik];
                Paket_hakkinda_icerik = (string)SonucKayit[C_Sutun_paket_hakkinda_icerik];

                return true;
            }
            else
                return false;
        }

        public bool DoldurPaketAdi()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_Paket_Adi;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Fiyat = (string)SonucKayit[C_Sutun_fiyat];
                Liste_item1 = (string)SonucKayit[C_Sutun_liste_item1];
                Liste_item2 = (string)SonucKayit[C_Sutun_liste_item2];
                Liste_item3 = (string)SonucKayit[C_Sutun_liste_item3];
                Liste_item4 = (string)SonucKayit[C_Sutun_liste_item4];
                Liste_item5 = (string)SonucKayit[C_Sutun_liste_item5];
                Buton_icerik = (string)SonucKayit[C_Sutun_buton_icerik];
                Paket_hakkinda_baslik = (string)SonucKayit[C_Sutun_paket_hakkinda_baslik];
                Paket_hakkinda_icerik = (string)SonucKayit[C_Sutun_paket_hakkinda_icerik];

                return true;
            }
            else
                return false;
        }

        public bool PaketAdi_VarMi()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_Paket_Adi;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
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
