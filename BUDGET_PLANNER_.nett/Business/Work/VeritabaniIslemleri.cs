using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Work
{
    public class VeritabaniIslemleri
    {

        public enum IslemTip
        {
            BAGLI,
            BAGIMSIZ
        }

        public string SpAdi { get; set; }
        public string FonksyionAdi { get; set; }

        private static string conStr;

        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private SqlTransaction sqlTransaction;
        private List<SqlParameter> sqlParameterList;

        private bool exe;

        public bool Exe
        {
            get { return exe; }
            set { exe = value; }
        }

        private int etkilenenKayitSayisi;

        public int EtkilenenKayitSayisi
        {
            get { return etkilenenKayitSayisi; }
            set { etkilenenKayitSayisi = value; }
        }
        private string sqlError;

        public string SqlError
        {
            get { return sqlError; }
            set { sqlError = value; }
        }

        private int sqlErrorCode;

        public int SqlErrorCode
        {
            get { return sqlErrorCode; }
            set { sqlErrorCode = value; }
        }


        private string sqlErrorDetail;

        public string SqlErrorDetail
        {
            get { return sqlErrorDetail; }
            set { sqlErrorDetail = value; }
        }

        private static void setConStr()
        {
            conStr = "Data Source=YUSUFLAPTOP\\SQLEXPRESS;Initial Catalog=BUTCE_PLANLAMA_WEB;Integrated Security=True";
        }
        public static string BaglantiMetni
        {
            get { return conStr; }
        }
        public VeritabaniIslemleri()
        {
            exe = true;
        }
        LogIslemleri logIslemleri;

        public bool Baslat(IslemTip tip)
        {
            try
            {
                setConStr();

                sqlParameterList = new List<SqlParameter>();
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(conStr);
                }
                if (sqlConnection.State == System.Data.ConnectionState.Closed || sqlConnection.State == System.Data.ConnectionState.Broken)
                {
                    sqlConnection.ConnectionString = conStr;
                    sqlConnection.Open();
                }
                if (sqlTransaction == null && IslemTip.BAGLI == tip)
                {
                    sqlTransaction = sqlConnection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                }
                if (sqlCommand == null)
                {
                    sqlCommand = sqlConnection.CreateCommand();
                    if (tip == IslemTip.BAGLI)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                sqlError = "Veritabanı bağlantı hatası : " + ex.Message;
                sqlErrorDetail = "Veritabanı bağlantı hatası.BeginSql rutininde. ";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                if (exe)
                {
                    logIslemleri = new LogIslemleri();
                    logIslemleri.LogKaydet(hataTumu, "Veritabanı BEGIN İşlemi Yapılırken Hata Aldı", "SQL");
                }
                return false;
            }
        }

        public void ParametreEkle(string parametreAdi, object parametreDegeri)
        {
            if (sqlParameterList == null)
            {
                sqlParameterList = new List<SqlParameter>();
            }

            if (parametreAdi[0] != '@')
                parametreAdi = "@" + parametreAdi;
            sqlParameterList.Add(new SqlParameter(parametreAdi, parametreDegeri));
        }

        public DataTable TabloGetir()
        {

            DataTable dt = new DataTable();
            HatalariSil();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = SpAdi;
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
            for (int i = 0; i < sqlParameterList.Count; i++)
                sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);
            sqlDA.Fill(dt);
            ParametreleriSil();
            return dt;

            try
            {
                HatalariSil();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = SpAdi;
                SqlDataAdapter sqlDqA = new SqlDataAdapter(sqlCommand);
                for (int i = 0; i < sqlParameterList.Count; i++)
                    sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);
                sqlDA.Fill(dt);
                ParametreleriSil();
                return dt;
            }
            catch (Exception ex)
            {
                sqlError = "Tablo TabloGetir hatası" + ex.Message;
                sqlErrorDetail = "Tablo TabloGetir Hatası";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                if (exe)
                {
                    logIslemleri = new LogIslemleri();
                    string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                    logIslemleri.LogKaydet(hataTumu, "Veritabanı TABLO_GETIR İşlemi Yapılırken Hata Aldı", "SQL");
                }
                ParametreleriSil();
                return null;
            }
        }
        public DataRow SatirGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                HatalariSil();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = SpAdi;
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
                for (int i = 0; i < sqlParameterList.Count; i++)
                    sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);
                sqlDA.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ParametreleriSil();
                    return dt.Rows[0];
                }
                else
                {
                    ParametreleriSil();
                    return null;
                }
            }
            catch (Exception ex)
            {
                sqlError = "Tablo TabloGetir hatası" + ex.Message;
                sqlErrorDetail = "Tablo TabloGetir Hatası";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı SATIR_GETIR İşlemi Yapılırken Hata Aldı", "SQL");
                ParametreleriSil();
                return null;
            }
        }

        public string TekDegerGetir()
        {
            string res = "";
            DataTable dt = new DataTable();
            try
            {
                HatalariSil();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = SpAdi;
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
                for (int i = 0; i < sqlParameterList.Count; i++)
                    sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);
                sqlDA.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    res = dt.Rows[0][0].ToString();
                }
            }
            catch (SqlException ex)
            {
                sqlError = "Tek Deger TabloGetir hatası" + ex.Message;
                sqlErrorDetail = "Tek Değer TabloGetir Hatası";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı TEK_DEGER_GETIR İşlemi Yapılırken Hata Aldı", "SQL");

                res = ex.Message;
            }
            catch (Exception ex)
            {
                sqlError = "Tek Değer TabloGetir hatası " + ex.Message;
                sqlErrorCode = -1;
                logIslemleri = new LogIslemleri();
                logIslemleri.LogKaydet(sqlError, "Veritabanı TEK_DEGER_GETIR İşlemi Yapılırken Hata Aldı", "C#");
                res = ex.Message;
            }
            ParametreleriSil();
            return res;
        }

        public string TekDegerGetirFonksiyonla()
        {
            string res = "";
            DataTable dt = new DataTable();
            try
            {
                HatalariSil();
                sqlCommand.CommandType = CommandType.Text;
                string paramsStr = "[params]";
                string degisenParamsStr = "";
                sqlCommand.CommandText = "Select " + FonksyionAdi + "(" + paramsStr + ")";
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);



                for (int i = 0; i < sqlParameterList.Count; i++)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);


                    string ekle = sqlParameterList[i].Value.ToString();

                    if (String.IsNullOrEmpty(degisenParamsStr))
                        degisenParamsStr = ekle;
                    else
                        degisenParamsStr += "," + ekle;
                }


                sqlCommand.CommandText = sqlCommand.CommandText.Replace(paramsStr, degisenParamsStr);

                sqlDA.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    res = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                sqlError = "Tek Deger TabloGetir hatası" + ex.Message;
                sqlErrorDetail = "Tek Değer TabloGetir Hatası";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı TEK_DEGER_GETIR İşlemi Yapılırken Hata Aldı", "SQL");

                res = ex.Message;
            }
            ParametreleriSil();
            return res;
        }

        public bool Calistir()
        {

            try
            {
                HatalariSil();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = SpAdi;
                for (int i = 0; i < sqlParameterList.Count; i++)
                    sqlCommand.Parameters.AddWithValue(sqlParameterList[i].ParameterName, sqlParameterList[i].Value);
                etkilenenKayitSayisi = sqlCommand.ExecuteNonQuery();
                ParametreleriSil();
                return true;
            }
            catch (Exception ex)
            {
                sqlError = "Komut çalıştırılırken hata aldı " + ex.Message;
                sqlErrorDetail = "Komut çalıştırılırken ExecuteSql rutininde hata aldı  ";
                sqlErrorDetail += SpAdi + "\n";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı EXECUTE İşlemi Yapılırken Hata Aldı", "SQL");

                ParametreleriSil();
                return false;
            }
        }

        public bool Uygula()
        {
            try
            {
                HatalariSil();
                if (sqlTransaction != null)
                {
                    sqlTransaction.Commit();
                    return true;
                }
                else
                {
                    sqlError = "Transaction başlatılmadı.Commit atılamaz";
                    logIslemleri = new LogIslemleri();

                    logIslemleri.LogKaydet(sqlError, "Veritabanı COMMIT İşlemi Yapılırken TRANSACTION BAŞLAMADIĞINDAN Hata Aldı", "SQL");

                    return false;
                }

            }
            catch (SqlException ex)
            {
                sqlError = "Commit çalıştırılırken hata aldı " + ex.Message;

                sqlErrorDetail = "Commit çalıştırılırken hata aldı.CommitSql rutininde. ";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı COMMIT İşlemi Yapılırken Hata Aldı", "SQL");

                return false;
            }
            catch (Exception ex)
            {
                sqlError = "Commit çalıştırılırken hata aldı " + ex.Message;
                sqlErrorCode = -1;
                logIslemleri = new LogIslemleri();
                logIslemleri.LogKaydet(sqlError, "Veritabanı COMMIT İşlemi Yapılırken Hata Aldı", "C#");
                return false;

            }


        }

        public bool GeriAl()
        {
            try
            {
                HatalariSil();

                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                    return true;
                }
                else
                {
                    sqlError = "Transaction başlatılmadı.Rollback yapılmaz";

                    logIslemleri = new LogIslemleri();
                    logIslemleri.LogKaydet(sqlError, "Veritabanı ROLBACK İşlemi Yapılırken TRANSACTION BAŞLAMADIĞINDAN Hata Aldı", "SQL");
                    return false;
                }
            }
            catch (SqlException ex)
            {

                sqlError = "Rollback çalıştırılırken hata aldı " + ex.Message;

                sqlErrorDetail = "Rollback çalıştırılırken hata aldı.RollbackSql rutininde.";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();

                logIslemleri = new LogIslemleri();
                string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                logIslemleri.LogKaydet(hataTumu, "Veritabanı ROLBACK İşlemi Yapılırken Hata Aldı", "SQL");
                return false;
            }

            catch (Exception ex)
            {
                sqlError = "Rollback çalıştırılırken hata aldı " + ex.Message;
                sqlErrorCode = -1;

                logIslemleri = new LogIslemleri();
                logIslemleri.LogKaydet(sqlError, "Veritabanı ROLBACK İşlemi Yapılırken Hata Aldı", "C#");
                return false;
            }

        }

        public bool Bitir()
        {
            try
            {
                HatalariSil();
                ParametreleriSil();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                    sqlTransaction = null;
                }
                if (sqlDataAdapter != null)
                {
                    sqlDataAdapter.Dispose();
                    sqlDataAdapter = null;
                }
                return true;

            }
            catch (SqlException ex)
            {
                sqlError = "EndSql çalıştırılırken hata aldı " + ex.Message;

                sqlErrorDetail = "EndSql çalıştırılırken hata aldı.EndSql rutininde.";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                if (exe)
                {
                    logIslemleri = new LogIslemleri();
                    string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                    logIslemleri.LogKaydet(hataTumu, "Veritabanı END_SQL İşlemi Yapılırken Hata Aldı", "SQL");
                }
                return false;

            }

            catch (Exception ex)
            {
                sqlError = "EndSql çalıştırılırken hata aldı " + ex.Message;
                sqlErrorCode = -1;
                if (exe)
                {
                    logIslemleri = new LogIslemleri();
                    logIslemleri.LogKaydet(sqlError, "Veritabanı END_SQL İşlemi Yapılırken Hata Aldı", "C#");
                }
                return false;

            }

        }

        public void ParametreleriSil()
        {
            try
            {


                if (sqlParameterList != null)
                {
                    sqlCommand.Parameters.Clear();
                    sqlParameterList.Clear();
                }
            }
            catch (Exception ex)
            {
                sqlError = "ParametreleriSil çalıştırılırken hata aldı " + ex.Message;

                sqlErrorDetail = "ParametreleriSil çalıştırılırken hata aldı.EndSql rutininde.";
                sqlErrorCode = ((System.Data.SqlClient.SqlException)(ex)).Number;
                sqlErrorDetail += ((System.Data.SqlClient.SqlException)(ex)).ToString();
                if (exe)
                {
                    logIslemleri = new LogIslemleri();
                    string hataTumu = sqlErrorCode + " : " + sqlError + " ---  " + sqlErrorDetail;
                    logIslemleri.LogKaydet(hataTumu, "Veritabanı ParametreleriSil İşlemi Yapılırken Hata Aldı", "SQL");
                }

            }

        }
        private void HatalariSil()
        {
            sqlErrorDetail = "";
            sqlErrorCode = 0;
            sqlError = "";
            etkilenenKayitSayisi = 0;
        }
    }
}
