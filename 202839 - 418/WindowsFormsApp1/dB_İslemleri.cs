using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class dB_İslemleri
    {
        public static string adres = System.IO.File.ReadAllText(@"C:\Adres.txt");
        //Bağlantımızın yolu
        SqlConnection con = new SqlConnection(dB_İslemleri.adres);
        //Köprümüzü tanımladık(Tabloya çekiyorsak)
        public SqlDataAdapter da;
        //Komutlarımız için nesnemiz
        public SqlCommand cmd;
        //Verileri tutmak için bir nesne ürettik.
        public DataSet ds;
        //Veri okumak için
        public SqlDataReader dr;



        public void dB_Kayit_Olustur(string x, string y, string z, string k)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    string k_Ekle_Sorgu = "INSERT INTO k_Bilgileri (ad_Soyad,e_Posta,k_Adi,sifre)values(@ad_Soyad,@e_Posta,@k_Adi,@sifre)";
                    cmd = new SqlCommand(k_Ekle_Sorgu, con);
                    cmd.Parameters.AddWithValue("@ad_Soyad", x);
                    cmd.Parameters.AddWithValue("@e_Posta", y);
                    cmd.Parameters.AddWithValue("@k_Adi", z);
                    cmd.Parameters.AddWithValue("@sifre", k);
                    cmd.ExecuteNonQuery();
                    k_Adi_DB = z;
                    con.Close();
                }
            }
            catch (Exception)
            {
                
            }
        }

        public bool durum_Sifre;
        public void sifre_Cek(string x)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    //cmd = new SqlCommand("SELECT * From k_Bilgileri Where k_Adi='" + x + "' and sifre = '" + y + "'", con);
                    con.Open();
                    cmd = new SqlCommand("SELECT * From k_Bilgileri WHERE sifre ='" + x + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        durum_Sifre = true;
                    }
                    else
                    {
                        durum_Sifre = false;
                    }
                    con.Close();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void dB_Sil()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    string k_Sil_Sorgu = "DELETE From k_Bilgileri WHERE k_Adi = @k_Adi";
                    cmd = new SqlCommand(k_Sil_Sorgu, con);
                    cmd.Parameters.AddWithValue("@k_Adi", k_Adi_DB);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                
            }
        }


        public void dB_Güncelle(string x, string y, string z, string k)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string k_Ekle_Sorgu = "UPDATE k_Bilgileri SET ad_Soyad = @ad_Soyad, e_Posta = @e_Posta, k_Adi = @k_Adi, sifre = @sifre WHERE k_Adi = '"+dB_İslemleri.k_Adi_DB+"'";
                    cmd = new SqlCommand(k_Ekle_Sorgu, con);
                    cmd.Parameters.AddWithValue("@ad_Soyad", x);
                    cmd.Parameters.AddWithValue("@e_Posta", y);
                    cmd.Parameters.AddWithValue("@k_Adi", z);
                    cmd.Parameters.AddWithValue("@sifre", k);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception )
            {
                
            }
        }

        public bool durum_Giris_Dogrula;
        public static string k_Adi_DB;
        public void dB_Giris_Dogrula(string x, string y)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * From k_Bilgileri Where k_Adi='" + x + "' and sifre = '" + y + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        
                        durum_Giris_Dogrula = true;
                        k_Adi_DB = dr[2].ToString();
                    }
                    else
                    {
                        durum_Giris_Dogrula = false;
                    }
                    con.Close();

                }
            }
            catch (Exception)
            {

            }
        }



        public bool durum_Kayit;
        public void dB_Kayit_Dogrula(string x)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                cmd = new SqlCommand("SELECT * From k_Bilgileri Where k_Adi='" + x + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    durum_Kayit = true;
                }
                else
                {
                    durum_Kayit = false;
                }
                con.Close();
            }
        }

        public static string money;
        public void dB_P_Cek()
        {
            con.Open();
            cmd = new SqlCommand("SELECT * From k_Bilgileri Where k_Adi='" + dB_İslemleri.k_Adi_DB + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                money = dr[4].ToString();
            }
            con.Close();
        }

        public void dB_P_Guncelle(double x)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    string k_Ekle_Sorgu = "UPDATE k_Bilgileri SET para = @para WHERE k_Adi = '" + dB_İslemleri.k_Adi_DB + "'";
                    cmd = new SqlCommand(k_Ekle_Sorgu, con);
                    cmd.Parameters.AddWithValue("@para", Convert.ToInt32(x));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public void dB_S_Guncelle(int x)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string k_Ekle_Sorgu = "UPDATE k_Bilgileri SET skor = @skor WHERE k_Adi = '" + dB_İslemleri.k_Adi_DB + "'";
                    cmd = new SqlCommand(k_Ekle_Sorgu, con);
                    cmd.Parameters.AddWithValue("@skor", Convert.ToInt32(x));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        public void dB_Sırala()
        {
            con.Open();
            //Tabloya çekliyorsak data adapter şart
            da = new SqlDataAdapter("Select k_Adi, skor From k_Bilgileri ORDER BY skor DESC", con);
            ds = new DataSet();
            da.Fill(ds, "k_Bilgileri");
            con.Close();
        }

        public static string a_S;
        public static string e_P;
        public void dB_Tum_Veriler()
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("SELECT ad_Soyad,E_Posta From k_Bilgileri Where k_Adi = '"+ dB_İslemleri.k_Adi_DB +"'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a_S = dr[0].ToString();
                    e_P = dr[1].ToString();
                }
                con.Close();
                
            }
            catch (Exception)
            {

            }
        }


    }
}
