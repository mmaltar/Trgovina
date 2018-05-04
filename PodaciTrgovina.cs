using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Trgovina
{
     class PodaciTrgovina
    {
        private string ime;
        private string grad;
        private string ulica;
        private string k_br;
        private string email;
        private string vlasnik;
        private string oib;
        private string tel;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Grad
        {
            get { return grad; }
            set { grad = value; }
        }

        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }

        public string KucniBroj
        {
            get { return k_br; }
            set { k_br = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Vlasnik
        {
            get { return vlasnik; }
            set { vlasnik = value; }
        }

        public string OIB
        {
            get { return oib; }
            set { oib = value; }
        }

        public string TEL
        {
            get { return tel; }
            set { tel = value; }
        }

        public PodaciTrgovina()
        {
            getDataFromDB();
        }


        public void Save()
        {

            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"UPDATE trgovina SET `ime` = :ime, 
                                                                         `grad` = :grad, 
                                                                         `ulica` = :ulica,
                                                                         `k_br` = :k_br,
                                                                        `email` = :email,
                                                                        `vlasnik` = :vlasnik,
                                                                        `oib` = :oib,
                                                                        `tel` = :tel
                                                                           ", conn);
            dataCmd.Parameters.Add(new SQLiteParameter("ime", ime));
            dataCmd.Parameters.Add(new SQLiteParameter("grad", grad));
            dataCmd.Parameters.Add(new SQLiteParameter("ulica", ulica));
            dataCmd.Parameters.Add(new SQLiteParameter("k_br", k_br));
            dataCmd.Parameters.Add(new SQLiteParameter("email", email));
            dataCmd.Parameters.Add(new SQLiteParameter("vlasnik", vlasnik));
            dataCmd.Parameters.Add(new SQLiteParameter("oib", oib));
            dataCmd.Parameters.Add(new SQLiteParameter("tel", tel));
            dataCmd.ExecuteNonQuery();
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        }


        private void getDataFromDB()
        {
          
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM trgovina ", conn);

                SQLiteDataReader reader = dataCmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                while (reader.Read())
                {
                        email = reader["email"].ToString();
                     
                        grad = reader["grad"].ToString();
                      
                        ime = reader["ime"].ToString();
                      
                        vlasnik = reader["vlasnik"].ToString();
                      
                        ulica = reader["ulica"].ToString();
                      
                        k_br = reader["k_br"].ToString();
                        
                        oib = reader["oib"].ToString();
                         
                        tel = reader["tel"].ToString();
                }

                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                
            }
            catch
            {

            }
        }

    }
}
