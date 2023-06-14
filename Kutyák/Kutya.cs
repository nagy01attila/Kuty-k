using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyák
{
    class Kutya
    {
        public int id;
        public int fajta_id;
        public int nev_id;
        public int kor;
        public string vizsgalat;

        public Kutya(string sor)
        {
            string[] adatok = sor.Trim().Split(';');
            id = int.Parse(adatok[0]);
            fajta_id = int.Parse(adatok[1]);
            nev_id = int.Parse(adatok[2]);
            kor = int.Parse(adatok[3]);
            vizsgalat = adatok[4];
        }
    }

}
