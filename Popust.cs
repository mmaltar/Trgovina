using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Trgovina
{
    public class Popust
    {
        private int id;
        private double posto;
        private string opis, vrijedi_od, vrijedi_do;

        public int ID
        {
            get { return id; }
        }

        public double Posto
        {
            get { return posto; }
            set { posto = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string VrijediOd
        {
            get { return vrijedi_od; }
            set { vrijedi_od = value; }
        }

        public string VrijediDo
        {
            get { return vrijedi_do; }
            set { vrijedi_do = value; }
        }

        private Popust( int id, double posto, string opis, string vrijedi_od, string vrijedi_do)
        {
            this.id = id;
            this.posto = posto;
            this.opis = opis;
            this.vrijedi_do = vrijedi_do;
            this.vrijedi_od = vrijedi_od;
        }

        public static Popust Create(double posto, string opis, string vrijedi_od, string vrijedi_do)
        {

            int insertedId = 0;
            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"INSERT INTO `popust`(`posto`, `opis`, `vrijedi_od`, `vrijedi_do`) 
                                                                    values(:posto, :opis, :vrijedi_od, :vrijedi_do);
                                                        SELECT last_insert_rowid();", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("posto", posto));
            dataCmd.Parameters.Add(new SQLiteParameter("opis", opis));
            dataCmd.Parameters.Add(new SQLiteParameter("vrijedi_od", vrijedi_od));
            dataCmd.Parameters.Add(new SQLiteParameter("vrijedi_do", vrijedi_do));

            object insertedIdObj = dataCmd.ExecuteScalar();
            insertedId = Convert.ToInt32(insertedIdObj);

            if (conn.State == System.Data.ConnectionState.Open) conn.Close();

            return new Popust(insertedId,  posto,  opis,  vrijedi_od,  vrijedi_do);
        }

        public void Save()
        {

            SQLiteConnection conn = Database.mConn;
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
            SQLiteCommand dataCmd = new SQLiteCommand(@"UPDATE popust SET `posto` = :posto, 
                                                                         `opis` = :opis, 
                                                                         `vrijedi_od` = :vrijedi_od,
                                                                         `vrijedi_do` = :vrijedi_do 
                                                                          WHERE id = :id  ", conn);
            dataCmd.Parameters.Add(new SQLiteParameter("posto", posto));
            dataCmd.Parameters.Add(new SQLiteParameter("opis", opis));
            dataCmd.Parameters.Add(new SQLiteParameter("vrijedi_od", vrijedi_od));
            dataCmd.Parameters.Add(new SQLiteParameter("vrijedi_do", vrijedi_do));
            dataCmd.Parameters.Add(new SQLiteParameter("id", id));
            dataCmd.ExecuteNonQuery();
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        }

        public static Popust WithID(int id)
        {
            Popust retPopust = null;
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM popust
                                                             WHERE popust.id = :id  
                                                               ", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id", id));
                SQLiteDataReader reader = dataCmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    retPopust = new Popust(Convert.ToInt32(reader["id"]), Convert.ToDouble(reader["posto"]), reader["opis"].ToString(), reader["vrijedi_od"].ToString(), reader["vrijedi_do"].ToString());
                }

                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                if (retPopust == null) throw new Exception("ID ne postoji");
            }
            catch
            {

            }
            return retPopust;
        }

        public static List<Popust> All(List<Tuple<string, string, string>> filters = null)
        {
            if (filters == null)
            {
                filters = new List<Tuple<string, string, string>>();
            }
            List<Popust> retPList = new List<Popust>();

            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "SELECT * FROM popust";

                for (int t = 0; t < filters.Count; t++)
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

                Console.WriteLine("query {0}", query);

                SQLiteCommand dataCmd = new SQLiteCommand(query, conn);


                SQLiteDataReader reader = dataCmd.ExecuteReader();
                while (reader.Read())
                {
                    retPList.Add(new Popust(Convert.ToInt32(reader["id"]), Convert.ToDouble(reader["posto"]), reader["opis"].ToString(), reader["vrijedi_od"].ToString(), reader["vrijedi_do"].ToString() ));
                }

                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + "(): " + ex.Message);
            }

            return retPList;
        }

        public static List<Popust> All(string select, string where = null)
        {
            List<Popust> retPList = new List<Popust>();
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "SELECT "+select + " FROM popust ";

                if (where != null)
                {
                    query = query +" WHERE "+ where;
                }

                Console.WriteLine("query {0}", query);

                SQLiteCommand dataCmd = new SQLiteCommand(query, conn);


                SQLiteDataReader reader = dataCmd.ExecuteReader();
                while (reader.Read())
                {
                    retPList.Add(new Popust(Convert.ToInt32(reader["id"]), Convert.ToDouble(reader["posto"]), reader["opis"].ToString(), reader["vrijedi_od"].ToString(), reader["vrijedi_do"].ToString()));
                }

                if (!reader.IsClosed) reader.Close();
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + System.Reflection.MethodBase.GetCurrentMethod().ToString() + "(): " + ex.Message);
            }

            return retPList;
        }
    }
}
