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
    public class Musteriler : Ortak_Alanlar, IOrtak_Metotlar
    {
        public Musteriler(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }

        ~Musteriler()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.Musteriler";

        public const string C_Sp_Ekle = "dbo.SP_Musteriler_EKLE";
        public const string C_Sp_Sil = "dbo.SP_Musteriler_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_Musteriler_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_Musteriler_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_Musteriler_TUMUNU_GETIR";
        public const string C_Sp_MailAra = "dbo.SP_Musteriler_MAIL_ARA";
        public const string C_SP_KulAdiVarMi = "dbo.SP_Musteriler_KULADI_ARA";
        public const string C_SP_Doldur_KulAdina_Gore = "dbo.SP_Musteriler_DOLDUR_KULADINA_GORE";
        public const string C_SP_Doldur_Isletme_Defter_Bilgileri_Getir = "dbo.SP_Musteriler_ISLETME_DEFTER_BILGILERI ";



        public const string C_Sutun_adi = "adi";
        public const string C_Sutun_soyadi = "soyadi";
        public const string C_Sutun_mail = "mail";
        public const string C_Sutun_kul_adi = "kul_adi";
        public const string C_Sutun_sifre = "sifre";


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

        private string adi;
        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string soyadi;
        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }

        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }



        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_soyadi, Soyadi);
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_sifre, Sifre);

            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_adi, Adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_soyadi, Soyadi);
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            VeritabaniIslem.ParametreEkle(C_Sutun_sifre, Sifre);

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
                Soyadi = (string)SonucKayit[C_Sutun_soyadi];
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kul_adi = (string)SonucKayit[C_Sutun_kul_adi];
                Sifre = (string)SonucKayit[C_Sutun_sifre];

                return true;
            }
            else
                return false;
        }

        public bool MaileGoreDoldur()
        {
            VeritabaniIslem.SpAdi = C_Sp_MailAra;
            VeritabaniIslem.ParametreEkle(C_Sutun_mail, Mail);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Soyadi = (string)SonucKayit[C_Sutun_soyadi];
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kul_adi = (string)SonucKayit[C_Sutun_kul_adi];
                Sifre = (string)SonucKayit[C_Sutun_sifre];

                return true;
            }
            else
                return false;
        }

        public bool KulAdiVarMi()
        {
            VeritabaniIslem.SpAdi = C_SP_KulAdiVarMi;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool KulAdinaGoreDoldur()
        {
            VeritabaniIslem.SpAdi = C_SP_Doldur_KulAdina_Gore;
            VeritabaniIslem.ParametreEkle(C_Sutun_kul_adi, Kul_adi);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Adi = (string)SonucKayit[C_Sutun_adi];
                Soyadi = (string)SonucKayit[C_Sutun_soyadi];
                Mail = (string)SonucKayit[C_Sutun_mail];
                Kul_adi = (string)SonucKayit[C_Sutun_kul_adi];
                Sifre = (string)SonucKayit[C_Sutun_sifre];

                return true;
            }
            else
                return false;
        }

        public void MusteriDefterIsletmeBilgileriGetir()
        {
            VeritabaniIslem.SpAdi = C_SP_Doldur_Isletme_Defter_Bilgileri_Getir;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeriTablosu = VeritabaniIslem.TabloGetir();
        }

        #endregion

    }
}
