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


            try
            {
                //Repository<Person>.CreateDatabase().Wait();
                //Repository<Person>.CreateDocumentAsync(p).Wait();

                //var read = Repository<Person>.GetDocumentAsync("12").Result;
                //Console.WriteLine(read.EfterNavn);

                //var read = Repository<Person>.DeleteDocumentAsync("12");



                var unitOfWork = new UnitOfWork<Person>();
                unitOfWork.Add(p1);
                unitOfWork.Add(p2);

               unitOfWork.Commit();
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
