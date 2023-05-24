using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConVizibicikli
{
    public class Kolcsonzes
    {
        string nev;
        char jazon;
        int eOra;
        int ePerc;
        int vOra;
        int vPerc;

        //!!!
        //Bár könnyebbé teheti a munkát egy újabb konstruktor
        //pld.ha sokszor kell CSV stringgel dolgozni, de OOP elveknek kevéssé felel meg.
        //Ezt inkább az osztály használójának kellene kivül megoldania.
        //Ezzel az osztályom erőssen fog függeni a CSV szerkezetétől.
        //Ha változik a CSV szerkezet, akkor lehet átírni az osztályt is.
        //Ezt a fajta függőséget (Dependency) nem szeretjük!
        public Kolcsonzes(string csvSor)
        {
            var mezok = csvSor.Split(';');
            this.nev = mezok[0];
            this.jazon = mezok[1][0];
            this.eOra = int.Parse(mezok[2]);
            this.ePerc = int.Parse(mezok[3]);
            this.vOra = int.Parse(mezok[4]);
            this.vPerc = int.Parse(mezok[5]);
        }
        //!!! vége

        public Kolcsonzes(string nev, char jazon, int eOra, int ePerc, int vOra, int vPerc)
        {
            this.nev = nev;
            this.jazon = jazon;
            this.eOra = eOra;
            this.ePerc = ePerc;
            this.vOra = vOra;
            this.vPerc = vPerc;
        }

        public string Nev { get => nev; }
        public char Jazon { get => jazon; }
        public int EOra { get => eOra; }
        public int EPerc { get => ePerc; }
        public int VOra { get => vOra; }
        public int VPerc { get => vPerc; }
    }