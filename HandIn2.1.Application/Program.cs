using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ByPostnummer aarhus = new ByPostnummer(8000, "Aarhus", "Denmark");
            Adresse ad1 = new Adresse("Silkeborgvej", 22, aarhus, "Hjem");



            TelefonNummer JensArbejd = new TelefonNummer(12345678,"Arbejd", "Telia");
            Person person = new Person(11111900, "Jens", "Poulsen", "Kollega", JensArbejd, ad1,"jens@gmail.com", "Peter");



        }
    }
}
