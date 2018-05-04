using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Trgovina
{
    public enum Role { Administrator = 1, Poslovođa = 2 , Blagajnik = 3}
    public class User
    {
        private int id;
        private string ime;
        private string prezime;
        private string username;
        private int role_id;
        private int active;


        public int ID
        {
            get { return id; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string Username
        {
            get { return username; }
        }

        public Role Rola
        {
            get { return ((Role)role_id); }
            set { role_id = (int)value; }
        }
        
        public string Status
        {
            get { return active == 0 ? "Neaktivan" : "Aktivan"; }
        }

        public int Active
        {
            set{ active = value; }
            get { return  active;}
        }

        private User(int id, int active,  string ime, string prezime, string username, int role_id)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.username = username;
            this.role_id = role_id;
            this.active = active;
        }

        public static User Create(string ime, int active, string prezime, string username, string password, int role_id)
        {

            string passHash = Crypto.GetHashString(password);
            int insertedId = 0;
            if (UsernameExist(username)) throw new Exception("Username already exist!");
            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"INSERT INTO `users`(`ime`, `active`, `prezime`, `username`, `password`, `role_id`) 
                                                                    values(:ime, :active, :prezime, :username, :password, :role_id);
                                                        SELECT last_insert_rowid();", conn);
            
            dataCmd.Parameters.Add(new SQLiteParameter("ime", ime));
            dataCmd.Parameters.Add(new SQLiteParameter("prezime", prezime));
            dataCmd.Parameters.Add(new SQLiteParameter("username", username));
            dataCmd.Parameters.Add(new SQLiteParameter("password",passHash));
            dataCmd.Parameters.Add(new SQLiteParameter("role_id", role_id));
            dataCmd.Parameters.Add(new SQLiteParameter("active", active));

            object insertedIdObj = dataCmd.ExecuteScalar();
            Console.WriteLine("Type : {0}", insertedIdObj.GetType());
            insertedId = Convert.ToInt32(insertedIdObj);

            if (conn.State == System.Data.ConnectionState.Open) conn.Close();

            return new User(insertedId, active, ime,  prezime,  username, role_id);
        }

        public void Save()
        {
            
            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"UPDATE users SET `ime` = :ime, 
                                                                         `prezime` = :prezime, 
                                                                         `role_id` = :role_id,
                                                                         `active` = :active 
                                                                          WHERE id = :id  ", conn);
            dataCmd.Parameters.Add(new SQLiteParameter("ime", ime));
            dataCmd.Parameters.Add(new SQLiteParameter("prezime", prezime));
            dataCmd.Parameters.Add(new SQLiteParameter("role_id", role_id));
            dataCmd.Parameters.Add(new SQLiteParameter("active", active));
            dataCmd.Parameters.Add(new SQLiteParameter("id", id));
            dataCmd.ExecuteNonQuery();
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        }

        private static bool UsernameExist(string username, int id = -1)
        {
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();
                StringBuilder queryString = new StringBuilder(@"SELECT count(*) FROM users
                                                             WHERE users.username = :username");

                if(id > 0)
                {
                    queryString.Append(" AND users.id <> :id");
                }


                SQLiteCommand dataCmd = new SQLiteCommand(queryString.ToString(), conn);

                dataCmd.Parameters.Add(new SQLiteParameter("username", username));
                dataCmd.Parameters.Add(new SQLiteParameter("id", id));

                Int64 nor = (Int64)dataCmd.ExecuteScalar();
                Console.WriteLine("TU {0}", nor);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                if (nor > 0) return true;
            }
            catch
            {

            }
           
            return false;
        } 

        public static User UserLogin(string username, string password)
        {

            User retUser = null;
            try
            { 
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();
               
                SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM users
                                                             WHERE users.username = :username
                                                              AND users.password = :pass  
                                                              AND users.active = 1  
                                                               ", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("username", username));
                dataCmd.Parameters.Add(new SQLiteParameter("pass", password));
                SQLiteDataReader reader = dataCmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
               
                while (reader.Read())
                {
                    retUser = new User(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["active"]),  reader["ime"].ToString(), reader["prezime"].ToString(), reader["username"].ToString(), Convert.ToInt32(reader["role_id"]));
                }
                Console.WriteLine("Loggg in {0}", retUser.Rola);
                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();

            }
            catch { Console.WriteLine("TUUUU44 "); }
            return retUser;
        }

        public static User WithID(int id)
        {
            User retUser = null;
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM users
                                                             WHERE users.id = :id  
                                                               ", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id", id));
                SQLiteDataReader reader = dataCmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                while (reader.Read())
                {
                        retUser = new User(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["active"]),  reader["ime"].ToString(), reader["prezime"].ToString(), reader["username"].ToString(), Convert.ToInt32(reader["role_id"]));
                }

                if(!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                if (retUser == null) throw new Exception("ID ne postoji");
            }
            catch {

            }
            return retUser;
        }

        public static List<User> All(List<Tuple<string, string, string> > filters = null)
        {
            if(filters == null)
            {
                filters = new List<Tuple<string, string, string> >();
            }
            List<User> retUList = new List<User>();
            
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "SELECT * FROM users";

                for(int t = 0; t < filters.Count; t++)
                {
                    if (t == 0)
                    {
                        query += " WHERE " + filters[t].Item1.ToString() + " " + filters[t].Item2.ToString() + " " + filters[t].Item3.ToString();
                    }
                    else
                    {
                        query += " AND " + filters[t].Item1.ToString() + " " + filters[t].Item2.ToString() + " " + filters[t].Item3.ToString();
                    }
                }

                SQLiteCommand dataCmd = new SQLiteCommand(query, conn);

                
                SQLiteDataReader reader = dataCmd.ExecuteReader();
                while (reader.Read())
                {
                    retUList.Add(new User(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["active"]),  reader["ime"].ToString(), reader["prezime"].ToString(), reader["username"].ToString(), Convert.ToInt32(reader["role_id"])));
                }
                
                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + "(): " + ex.Message);
            }
          
            return retUList;
        }

        public void ChangePassword(string newPass)
        {
            string passHash = Crypto.GetHashString(newPass);
            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"UPDATE users SET `password` = :password 
                                                                          WHERE id = :id  ", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("password", passHash));
            dataCmd.Parameters.Add(new SQLiteParameter("id", this.id));
            dataCmd.ExecuteNonQuery();
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();

        }
            
    }
}
