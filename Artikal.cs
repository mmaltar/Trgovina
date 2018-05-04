using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Trgovina
{
    public class Artikal
    {
        public int id, kod, kolicina, aktivan;
        public string ime, rok_uporabe, datum_nabave;
        public double cijena, cijena_ukupno, porez_posto;
        public double popust = 0;

        public List<Popust> popusti = new List<Popust>();

        Artikal() { }

        public Artikal(int kod, string ime, double cijena, double porez_posto, double cijena_ukupno, string rok_uporabe,
                     string datum_nabave, int kolicina)
        {
            this.kod = kod;
            this.ime = ime;
            this.cijena = Math.Round(cijena, 2);
            this.porez_posto = porez_posto;
            this.cijena_ukupno = Math.Round(cijena_ukupno, 2);
            this.rok_uporabe = rok_uporabe;
            this.datum_nabave = datum_nabave;
            this.kolicina = kolicina;
        }


        public Artikal(int id, int kod, string ime, double cijena, double porez_posto, double cijena_ukupno, string rok_uporabe,
                        string datum_nabave, int kolicina) : this(kod, ime, cijena, porez_posto, cijena_ukupno, rok_uporabe, datum_nabave, kolicina)
        {
            this.id = id;
            this.kod = kod;
        }

        public Artikal(int id, int kod, string ime, double cijena, double porez_posto, double cijena_ukupno, string rok_uporabe,
                        string datum_nabave, int kolicina, int aktivan) :
            this (id, kod, ime, cijena, porez_posto, cijena_ukupno, rok_uporabe, datum_nabave, kolicina)
        {
       
            this.aktivan = aktivan;
        }

        public void dodajPopust(Popust p)
        {
            popusti.Add(p);
            if (popust == 0)
                popust = 0.01 * p.Posto * cijena_ukupno;
            else popust += 0.01 * p.Posto * cijena_ukupno;
        }
       
        public double getPopustSum()
        {
            double sum = 0;
            foreach (Popust p in popusti)
                sum += p.Posto;
            return sum;
        }
      
    }
}
