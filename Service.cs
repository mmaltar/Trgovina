using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Trgovina
{
    static class Service
    {
        public static int AddArtikal(Artikal art, int aktivan)
        {
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(
                @"INSERT INTO artikal(kod, ime, cijena, porez_posto,
                cijena_ukupno, rok_uporabe, datum_nabave, kolicina, aktivan) 
                VALUES (:kod, :ime, :cijena, :porez_posto, :cijena_ukupno,
                :rok_uporabe, :datum_nabave, :kolicina, :aktivan)", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("kod", art.kod));
            dataCmd.Parameters.Add(new SQLiteParameter("ime", art.ime));
            dataCmd.Parameters.Add(new SQLiteParameter("cijena", art.cijena));
            dataCmd.Parameters.Add(new SQLiteParameter("porez_posto", art.porez_posto));
            dataCmd.Parameters.Add(new SQLiteParameter("cijena_ukupno", art.cijena_ukupno));
            dataCmd.Parameters.Add(new SQLiteParameter("rok_uporabe", art.rok_uporabe));
            dataCmd.Parameters.Add(new SQLiteParameter("datum_nabave", art.datum_nabave));
            dataCmd.Parameters.Add(new SQLiteParameter("kolicina", art.kolicina));
            dataCmd.Parameters.Add(new SQLiteParameter("aktivan", 1));

            try
            {
                dataCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


           dataCmd = new SQLiteCommand(@"SELECT id FROM artikal WHERE kod = :kod", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("kod", art.kod));
            SQLiteDataReader reader = dataCmd.ExecuteReader();

            reader.Read();
            
            return reader.GetInt32(0);
        }

        //vraća sve artikle
        public static List<Artikal> GetAllArtikal()
        {
            List<Artikal> retArtikli = new List<Artikal>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM artikal", conn);
            SQLiteDataReader reader = dataCmd.ExecuteReader();

            while (reader.Read())
            {
                retArtikli.Add(new Artikal(reader.GetInt32(0),
                        Int32.Parse(reader.GetString(1)),
                        reader.GetString(2),
                        reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6),
                        reader.GetString(7), reader.GetInt32(8)) 
                    );

            
            }
            return retArtikli;
        }


        //vraća sve artikle s datim kodom
        public static List<Artikal> GetArtikal(string kod)
        {
            List<Artikal> retArtikli = new List<Artikal>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM artikal
                                                             WHERE artikal.kod = :kod 
                                                               ", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("kod", kod));
            SQLiteDataReader reader = dataCmd.ExecuteReader();


            while (reader.Read())
            {
                retArtikli.Add(new Artikal(reader.GetInt32(0),
                        Int32.Parse(reader.GetString(1)),
                        reader.GetString(2),
                        reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6),
                        reader.GetString(7), reader.GetInt32(8))
                    );
            }
            return retArtikli;
        }

        public static void updateArtikal(Artikal art)
        {

            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"UPDATE artikal SET kod = :kod, ime = :ime, cijena = :cijena,
                                                        porez_posto = :porez_posto, cijena_ukupno = :cijena_ukupno, 
                                                        rok_uporabe = :rok_uporabe, datum_nabave = :datum_nabave, 
                                                        kolicina = :kolicina, aktivan = :aktivan WHERE id = :id", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("kod", art.kod));
            dataCmd.Parameters.Add(new SQLiteParameter("ime", art.ime));
            dataCmd.Parameters.Add(new SQLiteParameter("cijena", art.cijena));
            dataCmd.Parameters.Add(new SQLiteParameter("porez_posto", art.porez_posto));
            dataCmd.Parameters.Add(new SQLiteParameter("cijena_ukupno", art.cijena_ukupno));
            dataCmd.Parameters.Add(new SQLiteParameter("rok_uporabe", art.rok_uporabe));
            dataCmd.Parameters.Add(new SQLiteParameter("datum_nabave", art.datum_nabave));
            dataCmd.Parameters.Add(new SQLiteParameter("kolicina", art.kolicina));
            dataCmd.Parameters.Add(new SQLiteParameter("aktivan", art.aktivan));
            dataCmd.Parameters.Add(new SQLiteParameter("id", art.id));


            try
            {
                dataCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //svi aktivni popusti za artikal
        public static List<Popust> getAllPopust(Artikal art)
        {
            List<Popust> retPopusti = new List<Popust>();
            SQLiteConnection conn = Database.mConn;
            List<int> popust_ids = new List<int>();

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT id_popust FROM artikal_popust
                                                        WHERE artikal_popust.id_artikal = :id_artikal", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("id_artikal", art.id));
            SQLiteDataReader reader = dataCmd.ExecuteReader();

            while (reader.Read())
            {
                popust_ids.Add( reader.GetInt32(0));
    
            }

            foreach(int popust_id in popust_ids)
            {
                retPopusti.Add(Popust.WithID(popust_id));

            }

            return retPopusti;
        }

        public static List<Racun> getAllRacun()
        {
            List<Racun> retRacuni = new List<Racun>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM racun", conn);

            SQLiteDataReader reader = dataCmd.ExecuteReader();


            while (reader.Read())
            {
                retRacuni.Add(new Racun(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3),
                    reader.GetInt32(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetString(8)));

            }
            return retRacuni;
        }


        public static List<Racun> getRacunByDate(string date)
        {
            List<Racun> retRacuni = new List<Racun>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            string nextdate = tomorrow.ToString();

            Console.WriteLine("getRacunByDate::date {0}; nextdate:{1}", date, nextdate);

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM racun WHERE datetime >= :date 
                                                        AND datetime <= :nextdate", conn); 

            dataCmd.Parameters.Add(new SQLiteParameter("date", date));
            dataCmd.Parameters.Add(new SQLiteParameter("nextdate", nextdate));

            SQLiteDataReader reader = dataCmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("getRacunByDate::id {0};", reader.GetInt32(0));

                retRacuni.Add(new Racun(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3),
                    reader.GetInt32(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetString(8)));
                
            }     
            return retRacuni;
        }


        public static List<Artikal> getRacunArtikli(int id_racuna)
        {
            List<Artikal> artikli = new List<Artikal>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }


            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT id_artikla, kolicina, iznos FROM racun_artikl WHERE id_racuna = :id_racuna", conn);
            // 
            dataCmd.Parameters.Add(new SQLiteParameter("id_racuna", id_racuna));
            SQLiteDataReader reader = dataCmd.ExecuteReader();

            List<int> ids = new List<int>();
            List<int> kolicine = new List<int>();
            List<double> cijene = new List<double>();
            int i;
            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
                kolicine.Add(reader.GetInt32(1));
                cijene.Add(reader.GetDouble(2));
            }

            for(i = 0; i < ids.Count; i++ )
            {
                dataCmd = new SQLiteCommand(@"SELECT * FROM artikal WHERE id = :id_artikla", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id_artikla", ids[i]));
                reader = dataCmd.ExecuteReader();

                while (reader.Read())
                {

                    artikli.Add(new Artikal(
                        reader.GetInt32(0),
                        Int32.Parse(reader.GetString(1)),
                        reader.GetString(2),
                        reader.GetDouble(3), reader.GetDouble(4), cijene[i], reader.GetString(6),
                        reader.GetString(7), kolicine[i]));
                }
            }
            Console.Write(i.ToString());
            return artikli;
        }



        public static List<Racun> getRacunByID(int id)
        {
            List<Racun> retRacuni = new List<Racun>();
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(@"SELECT * FROM racun WHERE id = :id", conn);
            // 

            dataCmd.Parameters.Add(new SQLiteParameter("id", id));
            SQLiteDataReader reader = dataCmd.ExecuteReader();


            while (reader.Read())
            {
                retRacuni.Add(new Racun(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3),
                    reader.GetInt32(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetString(8)));

            }

            foreach (Racun r in retRacuni)
            {
                dataCmd = new SQLiteCommand(@"SELECT * FROM nacin_placanja WHERE id = :id_nacin_placanja", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id_nacin_placanja", r.getNacinPlacanjaID()));
                reader = dataCmd.ExecuteReader();

                while (reader.Read())
                {
                    r.setNacinPlacanja(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                }

            }
            return retRacuni;
        }


        public static void insertRacunAndAll(Racun r)
        {
            SQLiteConnection conn = Database.mConn;

            try
            {
                conn.Open();
            }
            catch { }

            SQLiteCommand dataCmd = new SQLiteCommand(
                @"INSERT INTO racun(id_user, iznos_artikli, popust_artikli, id_nacina_placanja,
                total_artikli, popust_nacin_placanja, total, datetime) 
                VALUES (:id_user, :iznos_artikli, :popust_artikli, :id_nacina_placanja,
                :total_artikli, :popust_nacin_placanja, :total, :datetime)", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("id_user",r.id_user));
            dataCmd.Parameters.Add(new SQLiteParameter("iznos_artikli", r.iznos_artikli));
            dataCmd.Parameters.Add(new SQLiteParameter("popust_artikli", r.popust_artikli));
            dataCmd.Parameters.Add(new SQLiteParameter("id_nacina_placanja", r.getNacinPlacanjaID()));
            dataCmd.Parameters.Add(new SQLiteParameter("total_artikli", r.total_artikli));
            dataCmd.Parameters.Add(new SQLiteParameter("popust_nacin_placanja", r.popust_nacin_placanja));
            dataCmd.Parameters.Add(new SQLiteParameter("total", r.total));
            dataCmd.Parameters.Add(new SQLiteParameter("datetime", r.datetime));

            try
            {
                dataCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //treba nam id tog računa
            dataCmd = new SQLiteCommand(@"SELECT id FROM racun
                                          WHERE id_user = :id_user AND iznos_artikli = :iznos_artikli
                                           AND datetime = :datetime", conn);

            dataCmd.Parameters.Add(new SQLiteParameter("id_user", r.id_user));
            dataCmd.Parameters.Add(new SQLiteParameter("iznos_artikli", r.iznos_artikli));
            dataCmd.Parameters.Add(new SQLiteParameter("datetime", r.datetime));

            SQLiteDataReader reader = dataCmd.ExecuteReader();

            int id_racuna = 0;
            while (reader.Read())
            {
                id_racuna = reader.GetInt32(0);
            }


            //ubacujemo sve artikle s računa u bazu
            foreach (Artikal art in r.artikli)
            {

                dataCmd = new SQLiteCommand(
                @"INSERT INTO racun_artikl(id_artikla, id_racuna, iznos, popust, ukupno, kolicina)
                values (:id_artikla, :id_racuna, :iznos, :popust, :ukupno, :kolicina)", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id_artikla", art.id));
                dataCmd.Parameters.Add(new SQLiteParameter("id_racuna", id_racuna));
                dataCmd.Parameters.Add(new SQLiteParameter("iznos", art.cijena_ukupno));
                dataCmd.Parameters.Add(new SQLiteParameter("popust", art.popust));
                dataCmd.Parameters.Add(new SQLiteParameter("ukupno", art.cijena_ukupno - art.popust));
                dataCmd.Parameters.Add(new SQLiteParameter("kolicina", art.kolicina));



                dataCmd.ExecuteNonQuery();



                //treba nam id tog racun_artikl
                dataCmd = new SQLiteCommand(@"SELECT id FROM racun_artikl
                                          WHERE id_artikla = :id_artikla AND id_racuna = :id_racuna", conn);

                dataCmd.Parameters.Add(new SQLiteParameter("id_artikla", art.id));
                dataCmd.Parameters.Add(new SQLiteParameter("id_racuna", id_racuna));

                reader = dataCmd.ExecuteReader();

                int id_racun_artikl = 0;
                while (reader.Read())
                {
                    id_racun_artikl = reader.GetInt32(0);
                }


                //ubacujemo popuste na artikle u bazu
                foreach (Popust p in art.popusti)
                {
                    dataCmd = new SQLiteCommand(
                   @"INSERT INTO racun_artikl_popusti(id_racun_artikl, popust_posto, popust_iznos, popust_opis)
                    values (:id_racun_artikl, :popust_posto, :popust_iznos, :popust_opis)", conn);

                    dataCmd.Parameters.Add(new SQLiteParameter("id_racun_artikl", id_racun_artikl));
                    dataCmd.Parameters.Add(new SQLiteParameter("popust_posto", p.Posto));
                    dataCmd.Parameters.Add(new SQLiteParameter("popust_iznos", 0.01 * p.Posto * art.cijena_ukupno));
                    dataCmd.Parameters.Add(new SQLiteParameter("popust_opis",p.Opis));
                    dataCmd.Parameters.Add(new SQLiteParameter("ukupno", art.cijena - art.popust));

                    dataCmd.ExecuteNonQuery();
                }

            }


        }


        public static string FormatSQLDate(string polje)
        {
            return "substr("+polje+ ", 7, 4) || '.' || substr(" + polje + ", 4, 2) || '.' || substr(" + polje + ", 1, 2)";
        }

        public static DataTable ProdajaArtikalaPoKorisniku()
        {
            DataTable korisnici = new DataTable();

            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string sql = @"select   users.ime || ' ' || users.prezime as korisnik,  sum(racun_artikl.kolicina) as smm
                                                                from racun_artikl 
                                                                left join racun on racun.id = racun_artikl.id_racuna
                                                                left join users on racun.id_user = users.id
                                                                group by id_user";

               
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                korisnici = new DataTable();
                mAdapter.Fill(korisnici);

                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch
            {

            }

            return korisnici;
        }

        public static DataTable ProdajaRacunaPoKorisniku()
        {
            DataTable korisnici = new DataTable();

            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string sql = @"select   users.ime || ' ' || users.prezime as korisnik,  count(*) as smm from racun
                                                                left join users on racun.id_user = users.id
                                                                group by id_user";


                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                korisnici = new DataTable();
                mAdapter.Fill(korisnici);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch
            {

            }

            return korisnici;
        }
        public static DataTable ProdajaPoVrstiArtikla()
        {
            DataTable artikli = new DataTable();

            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string sql = @"select   artikal.ime,  sum(racun_artikl.kolicina) as smm from racun_artikl
                                                                left join artikal on racun_artikl.id_artikla = artikal.id
																group by racun_artikl.id_artikla";


                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                artikli = new DataTable();
                mAdapter.Fill(artikli);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch
            {

            }

            return artikli;
        }

        public static DataTable IstekliArtikli()
        {
            DataTable artikli = new DataTable();
            string danas = DateTime.Now.ToString("yyyy.MM.dd");
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string sql = @"select artikal.id as ID, artikal.kod as Kod, artikal.kolicina as 'Količina', artikal.rok_uporabe as 'Vrijedi do'  from artikal where substr(rok_uporabe, 7, 4)||'.'|| substr(rok_uporabe, 4, 2)||'.'||substr(rok_uporabe, 1, 2) <= '" + danas + @"' and kolicina > 0 and aktivan = 1
                                                            and artikal.id not in(

                                                            select artikal.id from artikal
                                                            inner join potvrda on potvrda.id_artikla = artikal.id
                                                            where substr(rok_uporabe, 7, 4)||'.'|| substr(rok_uporabe, 4, 2)||'.'||substr(rok_uporabe, 1, 2) <= '" + danas + @"' and kolicina > 0 and aktivan = 1
                                                            ) ";

                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                mAdapter.Fill(artikli);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch
            {

            }
            return artikli;
        }

        public static void IstekliArtikliPotvrdeno(DataTable dt)
        {
            try
            {
                SQLiteConnection conn = Database.mConn;
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();
                SQLiteCommand dataCmd;
                foreach (DataRow dr in dt.Rows)
                {
                    dataCmd = new SQLiteCommand(
                  @"INSERT INTO potvrda (id_artikla) values (:id_artikla)", conn);

                    dataCmd.Parameters.Add(new SQLiteParameter("id_artikla", dr["ID"].ToString()));
                    dataCmd.ExecuteNonQuery();
                }
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch
            {

            }
        }

    }

    }

