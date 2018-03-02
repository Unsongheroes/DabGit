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
            Adresse ad1 = new Adresse("Silkeborgvej", 22, aarhus,"Hjem");
            Adresse ad2 = new Adresse("Silkeborgvej", 23, aarhus, "Hjem");
            Adresse ad3 = new Adresse("Silkeborgvej", 24, aarhus, "Hjem");
            Adresse ad4 = new Adresse("Silkeborgvej", 25, aarhus, "Hjem");


            TelefonNummer JensArbejd = new TelefonNummer(12345678,"Arbejd", "Telia");
            Person Jens = new Person(11111900, "Jens", "Poulsen", JensArbejd, "Kollega","jens@gmail.com", "Peter");
            Person Jens2 = new Person(11111901, "Jens2", "Poulsen2", JensArbejd, "Kollega", "jens2@gmail.com", "Peter2");
            Person Jens3 = new Person(11111902, "Jens3", "Poulsen3", JensArbejd, "Kollega", "jens3@gmail.com", "Peter3");
            Person Jens4 = new Person(11111903, "Jens4", "Poulsen4", JensArbejd, "Kollega", "jens4@gmail.com", "Peter4");



            ad1.AddPerson(Jens);
            ad1.AddPerson(Jens2);
            ad1.AddPerson(Jens3);
            ad1.AddPerson(Jens4);

            Jens.addAddress(ad1);
            Jens2.addAddress(ad1);
            Jens3.addAddress(ad1);
            Jens4.addAddress(ad1);


            Console.WriteLine("The given address is: ");
            ad1.PrintAdress();
            Console.WriteLine("And is related to the following persons: ");
            ad1.PrintPersons();

            Jens.Efternavn("Larsen");
            ad1.PrintPersons();




        }
    }
}
