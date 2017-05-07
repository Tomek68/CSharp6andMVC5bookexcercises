using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CSharp6andMVC5bookexcercises
{
    //strona 115
    //listing 1.70 przykład z użyciem Lazy<T>
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
            var lista = user.Platnosci.Value;
            Console.WriteLine("\r\nPłatności zostały pobrane");
            foreach (var el in lista)
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
    }

    public class Uzytkownik
    {
        public string Imie { get { return "Marek"; } set { } }
        public string Nazwisko { get { return "Marecki"; } set { } }

        public Lazy<IList<Platnosc>> Platnosci
        {
            get
            {
                return new Lazy<IList<Platnosc>>(()
                    => this.PobierzPlatnosci());
            }
        }

        private IList<Platnosc> PobierzPlatnosci()
        {
            List<Platnosc> platnosci = new List<Platnosc>();
            Platnosc platnosc1 = new Platnosc()
            {
                DataZamowienia = DateTime.Now,
                NumerZamowienia = 1,
                WartoscZamowienia = 100
            };
            Platnosc platnosc2 = new Platnosc()
            {
                DataZamowienia = DateTime.Now.AddDays(1),
                NumerZamowienia = 2,
                WartoscZamowienia = 300
            };
            platnosci.Add(platnosc1);
            platnosci.Add(platnosc2);
            return platnosci;
        }

        public class Platnosc
        {
            public int NumerZamowienia { get; set; }
            public DateTime DataZamowienia { get; set; }
            public int WartoscZamowienia { get; set; }
        }
    }
}
