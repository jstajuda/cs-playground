using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probnytest
{

    public class Produkt
    {
        public int waga;
        public int cena;

        public Produkt(int waga, int cena)
        {
            this.waga = waga;
            this.cena = cena;
        }

        public static Comparison<Produkt> PorownajPoCenie = delegate(Produkt x, Produkt y)
        {
            if (x.cena > y.cena) return 1;
            else if (x.cena == y.cena) return 0;
            else return -1;
        };

        public static Comparison<Produkt> PorownajPoWadze = delegate (Produkt x, Produkt y)
        {
            if (x.waga > y.waga) return 1;
            else if (x.waga == y.waga) return 0;
            else return -1;
        };

        public static Comparison<Produkt> PorownajPoCeniePotemPoWadze = delegate (Produkt x, Produkt y)
        {
            if (x.cena > y.cena) return 1;
            else if (x.cena == y.cena) return PorownajPoWadze(x, y);
            else return -1;
        };

        //wersja w notacji lambda
        public static Comparison<Produkt> PorownajPoWadzePotemPoCenie = (Produkt x, Produkt y) =>
        {
            if (x.waga > y.waga) return 1;
            else if (x.waga == y.waga) return PorownajPoCenie(x, y);
            else return -1;
        };


        public override string ToString()
        {
            return $"Produkt - cena: {cena:00} - waga: {waga:00}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            var lista = new List<Produkt>()
            {
                new Produkt(5, 10),
                new Produkt(1, 15),
                new Produkt(3, 7),
                new Produkt(3, 3),
                new Produkt(4, 20),
                new Produkt(6, 7),
                new Produkt(3, 1)
            };


            Console.WriteLine("Lista nieposortowana");
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Lista posortowana po cenie");
            lista.Sort(Produkt.PorownajPoCenie);
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Lista posortowana po wadze");
            lista.Sort(Produkt.PorownajPoWadze);
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Lista posortowana po wadze, następnie po cenie");
            lista.Sort(Produkt.PorownajPoWadzePotemPoCenie);
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Lista posortowana po cenie, następnie po wadze");
            lista.Sort(Produkt.PorownajPoCeniePotemPoWadze);
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Jeszcze raz po wadze, tylko z funkcją anonimową podaną jako argument");
            lista.Sort( delegate(Produkt x, Produkt y)
            {
                if (x.waga > y.waga) return 1;
                else if (x.waga == y.waga) return 0;
                else return -1;
            });
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Jeszcze raz po cenie, tylko z lambdą podaną jako argument");
            lista.Sort( (Produkt x, Produkt y) =>
            {
                if (x.cena > y.cena) return 1;
                else if (x.cena == y.cena) return 0;
                else return -1;
            });
            foreach (var produkt in lista)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("---------------");


            Console.ReadKey();
        }
    }
}
