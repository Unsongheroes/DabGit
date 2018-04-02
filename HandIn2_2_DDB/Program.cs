using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2_2_DDB
{
    class Program
    {
        #region Objektinitialisering
        static void Main(string[] args)
        {
            var b = new ByPostNummer
            {
                ByNavn = "Aarhus",
                Land = "Danmark",
                Postnummer = "8000"
            };

            var a = new Adresse
            {
                AdresseId = "0",
                ByPostNummer = b,
                Husnummer = 1,
                VejNavn = "Magnoliavej"
            };

            var a2 = new Adresse
            {
                AdresseId = "1",
                ByPostNummer = b,
                Husnummer = 2,
                VejNavn = "Strandvejen"
            };

            var p1 = new Person
            {
                Cpr = "12",
                Fornavn = "Patrick",
                EfterNavn = "Gobbenobber",
                Email = "123@123.com",
                MellemNavn = "Truck",
                PersonType = "Fremmed",
                PersonAdresses = new List<PersonAdresse>(), 
                TelefonBog = new List<TelefonNummer>()
            };

            var p2 = new Person
            {
                Cpr = "24",
                Fornavn = "Søren",
                EfterNavn = "Jensen",
                Email = "1234@1234.com",
                MellemNavn = "Als",
                PersonType = "CTO",
                PersonAdresses = new List<PersonAdresse>(),
                TelefonBog = new List<TelefonNummer>()
            };

            var tlf1 = new TelefonNummer {Telefonnummer="01234567", TelefonnummerType="Arbejde", TelefonSelskab="TDC"};
    
            p1.TelefonBog.Add(tlf1);

            var tlf2 = new TelefonNummer { Telefonnummer = "1234543", TelefonnummerType = "Hjem", TelefonSelskab = "TDC" };

            p2.TelefonBog.Add(tlf2);


            var pa1 = new PersonAdresse {MatchId = "0", Adresse = a, Person = p1, Type = "Hjem"};

            p1.PersonAdresses.Add(pa1);
            

            var pa2 = new PersonAdresse {MatchId = "1", Adresse = a, Person = p2, Type = "Hjem" };

            p2.PersonAdresses.Add(pa2);

            var pa3 = new PersonAdresse { MatchId = "2", Adresse = a2, Person = p1, Type = "Sommerhus" };

            p1.PersonAdresses.Add(pa3);

            #endregion
            try
            {
                
                var unitOfWork = new UnitOfWork<Person>();
                unitOfWork.Add(p1);
                unitOfWork.Add(p2);
                unitOfWork.Commit();

                Console.WriteLine("Data has been saved to the database");

                var ch = Console.ReadKey();

                Console.WriteLine("Loading person from database:");

                //Variablen person indeholder en person, som er fundet ved brug af det givne id (cpr).

                var person = unitOfWork.FindByJd(p1.Cpr);

                Console.WriteLine("Case 1: Hent 1 person fra databasen og udskriv dennes primære informationer:");
                //Case 1: Hent 1 person fra databasen og udskriver dennes primære informationer. 
                Console.WriteLine(person.Fornavn + " " + person.MellemNavn + " " + person.EfterNavn + ", " + person.PersonType);

                ch = Console.ReadKey();

                //Case 2: Hent 1 person fra databasen og udskriv dennes e-mail:
                Console.WriteLine("Case 2: Hent 1 person fra databasen og udskriv dennes e-mail:");
                Console.WriteLine(person.Email);

                ch = Console.ReadKey();

                //Case 3: Hent 1 person fra databasen og udskriv dennes tlf-nummer informationer:
                Console.WriteLine("Case 3: Hent 1 person fra databasen og udskriv dennes tlf-nummer informationer:");
                string tmp = "Type: " + person.TelefonBog.Single().TelefonnummerType + ", Nummer: " +
                             person.TelefonBog.Single().Telefonnummer + ", Selskab: " +
                             person.TelefonBog.Single().TelefonSelskab;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();

                //Case 4: Hent 1 person fra databasen og udskriv dennes adresse informationer samt by-postnummer informationer
                Console.WriteLine("Case 4: Hent 1 person fra databasen og udskriv dennes adresse informationer samt by-postnummer informationer");
                tmp = "AdresseType: " + person.PersonAdresses.First().Type + ", Vejnavn: " + person.PersonAdresses.First().Adresse.VejNavn + ", Husnummer: " + person.PersonAdresses.First().Adresse.Husnummer + ", Postnummer: " + person.PersonAdresses.First().Adresse.ByPostNummer.Postnummer + ", By: " + person.PersonAdresses.First().Adresse.ByPostNummer.ByNavn + ", Land: " + person
                    .PersonAdresses.First().Adresse.ByPostNummer.Land;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();

                //Case 5: Hent 1 person fra databasen og udskriv dennes forskellige adressetyper:
                person.PersonAdresses.GetEnumerator().MoveNext();
                Console.WriteLine("Case 5: Hent 1 person fra databasen og udskriv dennes forskellige adressetyper:");
                tmp = "Adresse 1 - Type: " + person.PersonAdresses.First().Type;
                Console.WriteLine(tmp);
                tmp = "Adresse 2 - Type: " + person.PersonAdresses.Last().Type;
                Console.WriteLine(tmp);

                ch = Console.ReadKey();
                

                
            }
                catch (DocumentClientException de)
                {
                    Exception baseException = de.GetBaseException();
                    Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
                }
                catch (Exception e)
                {
                    Exception baseException = e.GetBaseException();
                    Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
                }
                finally
                {
                    Console.WriteLine("End of demo, press any key to exit.");
                    Console.ReadKey();
                }
        }


      

    }
}
