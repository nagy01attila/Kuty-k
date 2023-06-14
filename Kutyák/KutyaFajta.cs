using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyák
{
    class KutyaFajtak
    {
        public int id;
        public string nev;
        public string eredeti;

        public KutyaFajtak(string sor)
        {
            string[] adatok = sor.Trim().Split(';');
            id = int.Parse(adatok[0]);
            nev = adatok[1];
            eredeti = adatok[2];
        }
    }
}
