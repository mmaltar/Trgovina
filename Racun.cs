using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trgovina
{
    class Racun
    {
        public int id, id_user;
        public string datetime;
        public double iznos_artikli, popust_artikli, total_artikli, popust_nacin_placanja, total;
        public List<Artikal> artikli = new List<Artikal>();
        Nacin_placanja np;


        public Racun() { }

        public Racun(int id_user)
        {
            this.id_user = id_user;
            this.iznos_artikli = 0;
            this.popust_artikli = 0;
            this.total_artikli = 0;
            this.total = 0;
            this.popust_nacin_placanja = 0;
            this.datetime = DateTime.Now.ToString();
        }

        public Racun(int id_user, Nacin_placanja np) : this(id_user)
        {
            this.np = np;
        }

        public Racun(int id, int id_user, double iznos_artikli, double popust_artikli, int id_nacin_placanja,
            double total_artikli, double popust_nacin_placanja, double total, string datetime)
        {
            this.id = id;
            this.id_user = id_user;
            this.iznos_artikli = iznos_artikli;
            this.popust_artikli = popust_artikli;
            this.np = new Nacin_placanja(id_nacin_placanja);
            this.total_artikli = popust_nacin_placanja;
            this.total = total;
            this.datetime = datetime;

        }

        public void Add(Artikal art)
        {
            artikli.Add(art);
            iznos_artikli += art.cijena_ukupno;
            popust_artikli += art.popust;
            total_artikli = iznos_artikli - popust_artikli;
            popust_nacin_placanja = 0.01 * np.popust_posto * total_artikli;
            total = total_artikli - popust_nacin_placanja;
        }

        public int getNacinPlacanjaID()
        {
            return np.id;
        }

        public Nacin_placanja getNacinPlacanja()
        {
            return np;
        }

        public void setNacinPlacanja(int id, string name, string opis, int popust, int popust_posto)
        {
            np = new Nacin_placanja(id, name, opis, popust, popust_posto);

        }

        public void reset()
        {
            this.iznos_artikli = 0;
            this.popust_artikli = 0;
            this.total_artikli = 0;
            this.total = 0;
        }


        /*
        public void Remove(Artikal art)
        {
            if(artikli.Contains(art))
            {
                artikli.Remove(art);
                iznos -= art.cijena_ukupno;
            }
        }
        */
    }
}
