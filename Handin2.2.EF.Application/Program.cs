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

            #region Objektinitialisering

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
            Adresse sommerhunAdresse = new Adresse
            {
                Husnummer = 2,
                VejNavn = "Strandvejen",
                ByPostNummer = Aarhus,


            };

            Person per = new Person
            {
                Fornavn = "Per",
                EfterNavn = "Andersen",
                PersonType = "CEO",
                MellemNavn = "georh",
                Email = "Per@Gmail.com"
                
                
            };

            Person patrick = new Person
            {
                Fornavn = "Patrick",
                EfterNavn = "Gobbenobber",
                PersonType = "HouseWife",
                MellemNavn = "Not",
                Email = "Patrick@Gmail.com"

            };

            PersonAdresse personAdresse = new PersonAdresse
            {
                Type = "Hjem",
                Person = per,
                Adresse = persAdresse
            };

            PersonAdresse personAdresse1 = new PersonAdresse
            {
                Type = "Sommerhus",
                Person = per,
                Adresse = sommerhunAdresse
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
            per.PersonAdresses.Add(personAdresse1);

            patrick.PersonAdresses.Add(personAdresse2);

            #endregion


            using (var unitOfWork = new UnitOfWork.UnitOfWork(new PersonContext()))
            {
                //denne funktion sletter alt i databasen 
                unitOfWork.Dispose();

                //Der oprettes 2 personer, 1 by, 2 adresser og 1 telefonnummer i databasen.
                unitOfWork.Persons.Add(per);
                unitOfWork.Persons.Add(patrick);

                //Denne funktion gemmer de tilføjede personer
                unitOfWork.Complete();

                Console.WriteLine("Data has been saved to the database");

                var ch = Console.ReadKey();

                Console.WriteLine("Loading person from database:");

                //Variablen person indeholder en liste af personer i dette tilfælde er der 2 personer i listen.
                var person = unitOfWork.Persons.GetPersonsByLastName(2);

                Console.WriteLine("Case 1: Hent 1 person fra databasen og udskriv dennes primære informationer:");
                //Case 1: Hent 1 person fra databasen og udskriver dennes primære informationer. 
                Console.WriteLine(person.First().Fornavn + " " + person.First().MellemNavn + " " + person.First().EfterNavn + ", " + person.First().PersonType);

                ch = Console.ReadKey();
                
                //Case 2: Hent 1 person fra databasen og udskriv dennes e-mail:
                Console.WriteLine("Case 2: Hent 1 person fra databasen og udskriv dennes e-mail:");
                Console.WriteLine(person.First().Email);

                ch = Console.ReadKey();

                //Case 3: Hent 1 person fra databasen og udskriv dennes tlf-nummer informationer:
                Console.WriteLine("Case 3: Hent 1 person fra databasen og udskriv dennes tlf-nummer informationer:");
                string tmp = "Type: " + person.First().TelefonBog.Single().TelefonnummerType + ", Nummer: " +
                             person.First().TelefonBog.Single().Telefonnummer + ", Selskab: " +
                             person.First().TelefonBog.Single().TelefonSelskab;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();

                //Case 4: Hent 1 person fra databasen og udskriv dennes adresse informationer samt by-postnummer informationer
                Console.WriteLine("Case 4: Hent 1 person fra databasen og udskriv dennes adresse informationer samt by-postnummer informationer");
                tmp = "AdresseType: " + person.First().PersonAdresses.First().Type + ", Vejnavn: " + person.First().PersonAdresses.First().Adresse.VejNavn + ", Husnummer: " + person.First().PersonAdresses.First().Adresse.Husnummer + ", Postnummer: " + person.First().PersonAdresses.First().Adresse.ByPostNummer.Postnummer + ", By: " + person.First().PersonAdresses.First().Adresse.ByPostNummer.ByNavn + ", Land: " + person
                    .First().PersonAdresses.First().Adresse.ByPostNummer.Land;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();

                //Case 5: Hent 1 person fra databasen og udskriv dennes forskellige adressetyper:
                person.First().PersonAdresses.GetEnumerator().MoveNext();
                Console.WriteLine("Case 5: Hent 1 person fra databasen og udskriv dennes forskellige adressetyper:");
                tmp = "Adresse 1 - Type: " + person.First().PersonAdresses.First().Type;
                Console.WriteLine(tmp);
                tmp = "Adresse 2 - Type: " + person.First().PersonAdresses.Last().Type;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();

            }
        }
    }
}
