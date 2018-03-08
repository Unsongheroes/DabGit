using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HandIn2._1.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Tomt postnummer/by tilføjes Aarhus, 8000, Denmark.");
            //ByPostnummer aarhus = new ByPostnummer(8000, "Aarhus", "Denmark");
            //Console.WriteLine("Indeholder 0 adresser:");
            //var checkpoint = Console.ReadKey();
            //aarhus.printAdresses();


            //Adresse ad1 = new Adresse("Silkeborgvej", 22, aarhus,"Hjem");
            //Adresse ad2 = new Adresse("Silkeborgvej", 23, aarhus, "Hjem");
            //Adresse ad3 = new Adresse("Silkeborgvej", 24, aarhus, "Hjem");
            //Adresse ad4 = new Adresse("Silkeborgvej", 25, aarhus, "Hjem");

            //Console.WriteLine("Tilføjelse af 4 adresser til postnummer via aarhus.printAdresses();:");
            //aarhus.printAdresses();
            //checkpoint = Console.ReadKey();
            //Console.WriteLine();

            //Console.WriteLine("Tilføjer nyt telefonnummer samt en enkelt person til adresse Silkeborgvej 22:");
            //TelefonNummer JensArbejd = new TelefonNummer(12345678,"Arbejd", "Telia");

            //Person Jens = new Person(11111900, "Jens", "Poulsen", JensArbejd, "Kollega", ad1,"jens@gmail.com", "Peter");

            //Jens.print();
            //Jens.printPhone();
            //checkpoint = Console.ReadKey();
            //Console.WriteLine();

            //Console.WriteLine("Tilføjer 3 personer til adresse Silkeborgvej 22:");

            //Person Ditte = new Person(11111901, "Ditte", "Poulsen", JensArbejd, "Kollega", ad1);
            //Person Samuel = new Person(11111902, "Samuel", "Poulsen", JensArbejd, "Studerende", ad1);
            //Person Abdi = new Person(11111903, "Abdi", "Poulsen", JensArbejd, "Kontanthjælp", ad1,"jens4@gmail.com");

            //Console.WriteLine();

            //Console.WriteLine("Den valgte adresse er:");
            //ad1.PrintAdress();
            //Console.WriteLine("Adressen indeholder følgende personer via ad1.PrintPersons():");
            //ad1.PrintPersons();
            //Console.WriteLine();

            //checkpoint = Console.ReadKey();
            //Console.WriteLine();

            //Console.WriteLine("Ændring af Jens' efternavn til Larsen.");
            //Jens.Efternavn("Larsen");
            //Console.WriteLine("Adressen indeholder følgende personer via ad1.PrintPersons():");
            //ad1.PrintPersons();

            //checkpoint = Console.ReadKey();

            //Console.WriteLine();

            //Console.WriteLine("Følgende er printet fra joint klassen: ");
            //foreach (var VARIABLE in JoinPersonAdresse.PersonAdresses)
            //{
            //    VARIABLE.Print();
            //    Console.WriteLine();
            //}

            //checkpoint = Console.ReadKey();

            using (var db = new PersonsContext())
            {
                // adding entities 
                //db. add 
                //db. savechanges

                //var query

                ByPostnummer aarhus = new ByPostnummer(8000, "Aarhus", "Denmark");
                //Console.WriteLine("Indeholder 0 adresser:");

                Adresse ad1 = new Adresse("Silkeborgvej", 22, aarhus, "Hjem");
                Adresse ad2 = new Adresse("Silkeborgvej", 23, aarhus, "Hjem");
                Adresse ad3 = new Adresse("Silkeborgvej", 24, aarhus, "Hjem");
                Adresse ad4 = new Adresse("Silkeborgvej", 25, aarhus, "Hjem");

                TelefonNummer JensArbejd = new TelefonNummer(12345678, "Arbejd", "Telia");

                Person Jens = new Person(11111900, "Jens", "Poulsen", JensArbejd, "Kollega", ad1, "jens@gmail.com", "Peter");


                db.ByPostnummers.Add(aarhus);
                db.Adresses.Add(ad1);
                db.Adresses.Add(ad2);
                db.Adresses.Add(ad3);
                db.Adresses.Add(ad4);
                db.TelefonNummers.Add(JensArbejd);
                db.Persons.Add(Jens);
                db.SaveChanges();


                var query = from b in db.Adresses
                    select b;

                foreach (var adress in query)
                {
                    Console.WriteLine("value: {0}", adress.Persons);
                }


            }




        }

        public class PersonsContext : DbContext
        {

            //public PersonsContext
            //{
            //    this.Database.Log = s => System.Diagnostics.Debug.WriteLine();
            //}
            public DbSet<Person> Persons { get; set; }
            
            public DbSet<Adresse> Adresses { get; set; }

            public DbSet<ByPostnummer> ByPostnummers { get; set; }

            public DbSet<TelefonNummer> TelefonNummers { get; set; }






        }
    }
}
