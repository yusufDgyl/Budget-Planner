using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Work
{
    class LogIslemleri
    {

        private string logPath = "";
        public Boolean LogOnlyActive = false;
        string ip_adres, url;
        DateTime today;

        public void LogKaydet(string hataMetni, string islemAciklamasi, string hataTip)
        {
            today = DateTime.Now;
            ip_adres = Utility.IpGetir();
            try
            {
                //   url = System.Web.HttpContext.Current.Request.Url.ToString();
                string servername = ConfigurationSettings.AppSettings["servername"];
                string dbname = ConfigurationSettings.AppSettings["dbname"];
                string userid = ConfigurationSettings.AppSettings["username"];
                string password = ConfigurationSettings.AppSettings["pass"];
                var scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = servername;
                scsb.InitialCatalog = dbname;
                scsb.UserID = userid;
                scsb.Password = password;
                scsb.ConnectTimeout = 60;


                string conStr = scsb.ConnectionString;

                SqlConnection baglanti = new SqlConnection(conStr);
                baglanti.Open();
                string sorgu = "insert into Hatalar(aciklama,url,hata_tip,hata,ip_adres,tarih) values('" + islemAciklamasi + "','" + url + "','" + hataTip + "','" + hataMetni + "','" + ip_adres + "',getdate())";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Yaz(hataMetni, islemAciklamasi, hataTip);
                baglanti.Close();

            }
            catch
            {
                Yaz(hataMetni, islemAciklamasi, hataTip);
            }
        }

        private void Yaz(string hataMetni, string islemAciklamasi, string hataTip)
        {
            string metin = "";
            metin = "---------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;
            metin += Environment.NewLine + "Saat       = " + today.ToString();
            metin += Environment.NewLine + "İşlem      = " + islemAciklamasi;
            metin += Environment.NewLine + "Hata Tipi  = " + hataTip;
            metin += Environment.NewLine + "Url        = " + url;
            metin += Environment.NewLine + "Ip Adres   = " + ip_adres;
            metin += Environment.NewLine + "Hata Metni = " + hataMetni + Environment.NewLine + Environment.NewLine;
            metin += "---------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;
            hataMetni = metin;
            try
            {
                logPath = ConfigurationSettings.AppSettings["logPath"];
                string yil = today.Year.ToString();
                string ay = today.Month.ToString().PadLeft(2, '0');
                string klasorAdi = yil + "_" + ay;
                logPath += klasorAdi;
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);
                logPath += "\\";

                string logFileName = logPath + today.Year.ToString() + today.Month.ToString().PadLeft(2, '0') + today.Day.ToString().PadLeft(2, '0') + ".txt";
                if (!System.IO.File.Exists(logFileName))
                {
                    using (StreamWriter streamWriter = File.CreateText(logFileName))
                    {
                        streamWriter.WriteLine(hataMetni);
                        streamWriter.Close();
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(logFileName))
                    {
                        streamWriter.WriteLine(hataMetni);
                        streamWriter.Close();
                    }
                }
            }
            catch
            {
            }
        }

        public void HataNesnesiyleLogKaydet(string hataMetni, Exception exceptionNesnesi, bool detayliAciklamaYaz)
        {
            string aciklama = exceptionNesnesi.Message;
            if (detayliAciklamaYaz)
            {
                if (exceptionNesnesi.InnerException != null)
                    aciklama += " " + exceptionNesnesi.InnerException.Message;
            }
            LogKaydet(hataMetni, aciklama, "C#");
        }
    }
}
