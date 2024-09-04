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
    public class MailOnayKodlari : Ortak_Alanlar , IOrtak_Metotlar
    {
        public MailOnayKodlari(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~MailOnayKodlari()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.MailOnayKodlari";

        public const string C_Sp_Ekle = "dbo.SP_MailOnayKodlari_EKLE";
        public const string C_Sp_Sil = "dbo.SP_MailOnayKodlari_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_MailOnayKodlari_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_MailOnayKodlari_DOLDUR";
        public const string C_Sp_DoldurMail = "dbo.SP_MailOnayKodlari_DOLDUR_MAILE_GORE";
        public const string C_Sp_SonSatirGetir = "dbo.SP_MailOnayKodlari_SON_SATIR_GETIR";


        public const string C_Sp_TumunuGetir = "dbo.SP_MailOnayKodlari_TUMUNU_GETIR";

        public const string C_Sutun_mail = "mail";
        public const string C_Sutun_kod = "kod";

        #endregion

        #region Nesneler 


        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string kod;
        public string Kod
        {
            get { return kod; }
            set { kod = value; }
        }

        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            VeritabaniIslem.ParametreEkle(C_Sutun_kod, Kod);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            VeritabaniIslem.ParametreEkle(C_Sutun_kod, Kod);
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
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kod = (string)SonucKayit[C_Sutun_kod];
                return true;
            }
            else
                return false;
        }
        public bool DoldurMaileGore()
        {
            VeritabaniIslem.SpAdi = C_Sp_DoldurMail;
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kod = (string)SonucKayit[C_Sutun_kod];
                return true;
            }
            else
                return false;
        }
        public bool SonSatirGetir()
        {
            VeritabaniIslem.SpAdi = C_Sp_SonSatirGetir;
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kod = (string)SonucKayit[C_Sutun_kod];
                return true;
            }
            else
                return false;
        }

        #endregion

    }
}
