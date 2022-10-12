using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kémia
{
    class Adatok
    {
        //2. feladat
        string ev;
        string elem;
        string vegyjel;
        int rendszam;
        string felfedezo;
        

        public string Ev { get => ev; set => ev = value; }
        public string Elem { get => elem; set => elem = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszam { get => rendszam; set => rendszam = value; }
        public string Felfedezo { get => felfedezo; set => felfedezo = value; }
       

        public Adatok(string ev, string elem, string vegyjel, int rendszam, string felfedezo)
        {
            Ev = ev;
            Elem = elem;
            Vegyjel = vegyjel;
            Rendszam = rendszam;
            Felfedezo = felfedezo;
        }
        public Adatok(string adatsor)
        {
            string[] adatok = adatsor.Split(';');
            
            Ev = adatok[0];
            Elem = adatok[1];
            Vegyjel = adatok[2];
            Rendszam = int.Parse(adatok[3]);
            Felfedezo = adatok[4];
        }
    }
}
