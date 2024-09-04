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
    public class PaketlerSayfaTekrarsizMetinler : Ortak_Alanlar, IOrtak_Metotlar
    {
        public PaketlerSayfaTekrarsizMetinler(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~PaketlerSayfaTekrarsizMetinler()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler

        public const string C_Tablo = "dbo.PaketlerSayfaTekrarsizMetinler";

        public const string C_Sp_Ekle = "dbo.SP_PaketlerTekrarsiz_EKLE";
        public const string C_Sp_Sil = "dbo.SP_PaketlerTekrarsiz_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_PaketlerTekrarsiz_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_PaketlerTekrarsiz_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_PaketlerTekrarsiz_TUMUNU_GETIR";

        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_etiket = "etiket";
        public const string C_Sutun_icerik = "icerik";
        
        #endregion

        #region Nesneler


        private string adi;
        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string etiket;
        public string Etiket
        {
            get { return etiket; }
            set { etiket = value; }
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
            VeritabaniIslem.ParametreEkle(C_Sutun_etiket, Etiket);
            VeritabaniIslem.ParametreEkle(C_Sutun_icerik, Icerik);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_etiket, Etiket);
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
                Etiket = (string)SonucKayit[C_Sutun_etiket];
                Icerik = (string)SonucKayit[C_Sutun_icerik];
                return true;
            }
            else
                return false;
        }

        #endregion
    }
}
