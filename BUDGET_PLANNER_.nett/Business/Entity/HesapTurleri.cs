﻿using Business.Interface;
using Business.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class HesapTurleri : Ortak_Alanlar, IOrtak_Metotlar
    {
        public HesapTurleri(VeritabaniIslemleri _veritabaniIslemleri)
        {
            VeritabaniIslem = _veritabaniIslemleri;
        }
        ~HesapTurleri()
        {
            VeriTablosu = new DataTable();
            VeriTablosu = null;
        }

        #region Sabitler  

        public const string C_Tablo = "dbo.HesapTurleri";

        public const string C_Sp_Ekle = "dbo.SP_HesapTurleri _EKLE";
        public const string C_Sp_Sil = "dbo.SP_HesapIslemleri_SIL";
        public const string C_Sp_Guncelle = "dbo.SP_HesapTurleri_GUNCELLE";
        public const string C_Sp_Doldur = "dbo.SP_HesapTurleri_DOLDUR";
        public const string C_Sp_TumunuGetir = "dbo.SP_HesapTurleri_TUMUNU_GETIR";
        public const string C_Sp_Doldur_Ture_Gore = "dbo.SP_HesapTurleri_DOLDUR_TURE_GORE";


        public const string C_Sutun_tur = "tur";



        #endregion

        #region Nesneler 

        private string tur;
        public string Tur
        {
            get { return tur; }
            set { tur = value; }
        }

        #endregion

        #region Metotlar 

        public bool Ekle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Ekle;
            VeritabaniIslem.ParametreEkle(C_Sutun_tur, Tur);
            return VeritabaniIslem.Calistir();
        }

        public bool Guncelle()
        {
            VeritabaniIslem.SpAdi = C_Sp_Guncelle;
            VeritabaniIslem.ParametreEkle(C_Sutun_id, Id);
            VeritabaniIslem.ParametreEkle(C_Sutun_tur, Tur);
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
                Tur = (string)SonucKayit[C_Sutun_tur];
                return true;
            }
            else
                return false;
        }
        public bool DoldurTureGore()
        {
            VeritabaniIslem.SpAdi = C_Sp_Doldur_Ture_Gore;
            VeritabaniIslem.ParametreEkle(C_Sutun_tur, Tur);
            SonucKayit = VeritabaniIslem.SatirGetir();

            if (SonucKayit != null)
            {
                Id = (int)SonucKayit[C_Sutun_id];
                Tur = (string)SonucKayit[C_Sutun_tur];
                return true;
            }
            else
                return false;
        }

        #endregion

    }
}
