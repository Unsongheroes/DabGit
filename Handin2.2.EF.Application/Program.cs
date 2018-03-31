using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2._2.EF.Application
{
    class Program
    {
        static void Main(string[] args)
        {



            ByPostNummer Aarhus = new ByPostNummer
            {
                Postnummer = 8000,
                ByNavn = "Aarhus",
                Land = "Denmark"
            };

            Adresse persAdresse = new Adresse
            {
                Husnummer = 1,
                VejNavn = "kildemosevej",
                ByPostNummer = Aarhus,
               

            };

            Person per = new Person
            {
                Fornavn = "Per",
                EfterNavn = "Andersen",
                PersonType = "CEO",
                MellemNavn = "georh",
                
                
            };

            Person patrick = new Person
            {
                Fornavn = "Patrick",
                EfterNavn = "Gobbenobber",
                PersonType = "HouseWife",
                MellemNavn = "Not",
                

            };

            PersonAdresse personAdresse = new PersonAdresse
            {
                Type = "Hjem",
                Person = per,
                Adresse = persAdresse
            };

            PersonAdresse personAdresse2 = new PersonAdresse
            {
                Type = "Arbejde",
                Person = patrick,
                Adresse = persAdresse
            };

            TelefonNummer pertlf = new TelefonNummer
            {
                TelefonnummerType = "Privat",
                TelefonSelskab = "TDC"
            };



            per.TelefonBog.Add(pertlf);

            per.PersonAdresses.Add(personAdresse);

            patrick.PersonAdresses.Add(personAdresse2);
           
            


            using (var unitOfWork = new UnitOfWork.UnitOfWork(new PersonContext()))
            {
                unitOfWork.Dispose();

                unitOfWork.Persons.Add(per);
                unitOfWork.Persons.Add(patrick);

                unitOfWork.Complete();

                Console.WriteLine("gdaffgas");


                var person = unitOfWork.Persons.GetPersonsByLastName(2);

                Console.WriteLine(person.First().MellemNavn);

                Console.WriteLine(person.First().TelefonBog.Single().TelefonnummerType);

                Console.WriteLine(person.First(x => x.Fornavn=="Per").PersonAdresses.First().Type);
                Console.WriteLine(person.First(x => x.Fornavn == "Per").PersonAdresses.First().Person.Fornavn);
                Console.WriteLine(person.First(x => x.Fornavn == "Per").PersonAdresses.First().Adresse.VejNavn);

                //Console.WriteLine(persAdresse.PersonAdresses.First().Type);
                //Console.WriteLine(persAdresse.PersonAdresses.First().Person.MellemNavn);
                //Console.WriteLine(persAdresse.PersonAdresses.First().Adresse.VejNavn);


                Console.WriteLine(person.First(x => x.Fornavn == "Patrick").PersonAdresses.First().Type);
                Console.WriteLine(person.First(x => x.Fornavn == "Patrick").PersonAdresses.First().Person.Fornavn);
                Console.WriteLine(person.First(x => x.Fornavn == "Patrick").PersonAdresses.First().Adresse.VejNavn);

                var ch = Console.ReadKey();

            }
        }
    }
}
