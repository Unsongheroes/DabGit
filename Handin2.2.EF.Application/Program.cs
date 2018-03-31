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
                PersonAdresses = new List<PersonAdresse>()

            };

            Person per = new Person
            {
                Fornavn = "Per",
                EfterNavn = "Andersen",
                PersonType = "CEO",
                MellemNavn = "georh",
                PersonAdresses = new List<PersonAdresse>()
                
            };

            PersonAdresse personAdresse = new PersonAdresse
            {
                Type = "Shit",
                Person = per,
                Adresse = persAdresse
            };

            TelefonNummer pertlf = new TelefonNummer
            {
                TelefonnummerType = "Privat",
                TelefonSelskab = "TDC"
            };



            per.TelefonBog.Add(pertlf);

            per.PersonAdresses.Add(personAdresse);
           
            


            using (var unitOfWork = new UnitOfWork.UnitOfWork(new PersonContext()))
            {
                unitOfWork.Dispose();

                unitOfWork.Persons.Add(per);

                unitOfWork.Complete();

                Console.WriteLine("gdaffgas");


                var person = unitOfWork.Persons.GetPersonsByLastName(1);

                Console.WriteLine(person.First().MellemNavn);

                Console.WriteLine(person.First().TelefonBog.Single().TelefonnummerType);

                Console.WriteLine(per.PersonAdresses.First().Type);
                Console.WriteLine(per.PersonAdresses.First().Person.MellemNavn);
                Console.WriteLine(per.PersonAdresses.First().Adresse.VejNavn);

                Console.WriteLine(persAdresse.PersonAdresses.First().Person.MellemNavn);
                Console.WriteLine(persAdresse.PersonAdresses.First().Adresse.VejNavn);
                var ch = Console.ReadKey();

            }
        }
    }
}
