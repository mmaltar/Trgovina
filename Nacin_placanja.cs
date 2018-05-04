using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trgovina
{
    class Nacin_placanja
    {
        public int id, popust, popust_posto;
        public string name, opis;

        public Nacin_placanja(int id)
        {
            this.id = id;
        }

        public Nacin_placanja(int id, string name, string opis, int popust, int popust_posto)
        {
            this.id = id;
            this.name = name;
            this.opis = opis;
            this.popust = popust;
            this.popust_posto = popust_posto;
        }
    }
}
