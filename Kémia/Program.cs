using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Kémia
{
    class Program
    {
        public static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            

            using (StreamReader file = new StreamReader("felfedezesek.csv" ))            //2.feladat beolvasas
            {
                file.ReadLine();
                while (!file.EndOfStream)
                {
                    adatok.Add(new Adatok(file.ReadLine()));
                }
                file.Close();
            }
            //3.feladat Hány kémia elem van az állományban
            Console.WriteLine($"3.feladat: Elemek száma: {adatok.Count}");
            //4.feladat felfedezett kemiai elemek az ókorban          
            Console.WriteLine($"4.feladat: Felfedezések száma az ókorban: {adatok.FindAll(x => x.Ev == "Ókor").Count}");
            //5./6. feladat
            feladat6();

            feladat8();

          
            Console.ReadKey();
      
        }

        private static void feladat8()
        {
            Console.WriteLine("8.feladat: Statitzika");
            adatok.GroupBy(a => a.Ev).Where(c =>c.Count() > 3 && c.Key != "Ókor").ToList().ForEach(g => Console.WriteLine($"\t{g.Key}: {g.Count()} db"));
        }

        private static void feladat6()
        {
            string kell = feladat5();
            Console.WriteLine($"6.feladat: Keresés");
            Adatok van = adatok.Find(x => x.Vegyjel.ToLower() == kell.ToLower());
            if (! (van is null))
            {
                Console.WriteLine($"\tAz elem vegyjele: {van.Vegyjel} \n\tAz elem neve: {van.Elem} \n\tRendszám: {van.Rendszam} \n\tFelfedezés éve: {van.Ev} \n\tFelfedező: {van.Felfedezo}");
            }
        }

        private static string feladat5()
        {
            //5.feladat
            Console.Write($"5.feladat: Kérek egy vegyjelet:");
            string vegyjel2 = Console.ReadLine();
            

            while (!Regex.IsMatch(vegyjel2,@"^[a-zA-Z]{1,2}$"))
            {
                Console.Write($"5.feladat: Kérek egy vegyjelet:");
                vegyjel2 = Console.ReadLine();                     
            }
            return vegyjel2;
        }
    }
}
