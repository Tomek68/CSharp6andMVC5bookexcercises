using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.LazyInitializer;

namespace LazyInitialization.LazyInitializer
{
    //lazy initialization using LazyInitializer
    //listing 1.71
    class Program
    {
        static void Main(string[] args)
        {
            Uzytkownik user = new Uzytkownik();
            Console.WriteLine(
                "\r\nImie: " + user.Imie +
                "\r\nImie: " + user.Nazwisko +
                "\r\nW tym momencie płaności nie zostały jeszcze pobrane");
            Console.ReadLine();
            //user.Platnosci ma wartość null
            user.InitializePlatnosci();
            //user.Platnosci ma listę płatności

            Console.WriteLine("\r\nPłatności zostały pobrane\r\n");
            foreach (var el in user.Platnosci)
            {
                Console.WriteLine(
       "\r\nNumer zamówienia: " +
       el.NumerZamowienia +
       "\r\nWartość zamówienia: " +
       el.WartoscZamowienia +
       "\r\nData zamówienia: " +
       el.DataZamowienia
       );
            }
            Console.ReadLine();
        }

        public class Uzytkownik
        {
            public string Imie
            {
                get { return "Marek"; }
                set { }
            }

            public string Nazwisko
            {
                get { return "Marecki"; }
                set { }
            }

            public List<Platnosc> Platnosci { get; set; }

            public void InitializePlatnosci()
            {
                List<Platnosc> platnosci = new List<Platnosc>();
                for (int i = 1; i < 4; i++)
                {
                    Platnosc platnosc = null;
                    EnsureInitialized(
                        ref platnosc, () =>
                    {
                        return PobierzPlatnosci(i);
                    });
                    platnosci.Add(platnosc);
                }
                Platnosci = platnosci;
            }

            private Platnosc PobierzPlatnosci(int i)
            {
                Platnosc platnosc = new Platnosc
                {
                    DataZamowienia = DateTime.Now.AddDays(i),
                    NumerZamowienia = i,
                    WartoscZamowienia = i * 100
                };
                return platnosc;
            }
        }

        public class Platnosc
        {
            public int NumerZamowienia { get; set; }
            public DateTime DataZamowienia { get; set; }
            public int WartoscZamowienia { get; set; }
        }

    }
}
