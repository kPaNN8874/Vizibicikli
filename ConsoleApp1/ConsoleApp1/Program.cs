using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ConVizibicikli
{
    internal class Program
    {
        static List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            //Hagyományos technika
            StreamReader sr = new StreamReader("DataSource\\kolcsonzesek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var mezok = sr.ReadLine().Split(';');

                Kolcsonzes uj = new Kolcsonzes(mezok[0],
                                               mezok[1][0],
                                               int.Parse(mezok[2]),
                                               int.Parse(mezok[3]),
                                               int.Parse(mezok[4]),
                                               int.Parse(mezok[5]));
            }
            sr.Close();

            // LINQ + Foreach
            kolcsonzesek.Clear();

            foreach (var sor in File.ReadAllLines("DataSource\\kolcsonzesek.txt"))
            {
                kolcsonzesek.Add(new Kolcsonzes(sor));
            }



            //LINQ
            List<Kolcsonzes> masikLista
                = File.ReadAllLines("DataSource\\kolcsonzesek.txt")
                      .Skip(1)
                      .Select(x => new Kolcsonzes(x))
                      .ToList();

            //5.feladat
            Console.WriteLine($"%.feladat: Napi kölcsönzések száma: {kolcsonzesek.Count}");

            //6.feladat
            Console.WriteLine($"6.feladat: Kérek egy nevet: ");
            string megadottNev = "Kata";
            Console.WriteLine(megadottNev);
            Console.WriteLine($"\t {megadottNev} kölcsönzései: ");

            if (kolcsonzesek.Count(x => x.Nev == megadottNev) == 0)
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            }
            else
            {
                kolcsonzesek.Where(x => x.Nev == "Kata").ToList().ForEach(x => Console.WriteLine($"\t {x.EOra}:{x.EPerc}-{x.VOra}:{x.VPerc}"));

            }
            //7.feladat
            //8.feladat
            int napibevetel = 2400 * (kolcsonzesek.Sum(ob => ob.IdoHossz()) / 30 + 1);
            Console.WriteLine( $"8.feladat: A napi bevétel: {napibevetel} Ft.");
            //9.feladat
            //10.feladat
            kolcsonzesek.GroupBy(x => x.Jazon).OrderBy(x => x.Key).ToList().ForEach(x => Console.WriteLine($"{x.Key}-{x.Count()}"));

        }
    }
}