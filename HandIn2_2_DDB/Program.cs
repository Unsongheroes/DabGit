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
                Postnummer = 8000
            };

            var a = new Adresse
            {
                ByPostNummer = b,
                Husnummer = 1,
                VejNavn = "Magnoliavej",
                PersonAdresses = new List<PersonAdresse>()
            };

            var p = new Person
            {
                Cpr = 1,
                Fornavn = "Patrick",
                EfterNavn = "Gobbenobber",
                Email = "123@123.com",
                MellemNavn = "Truck",
                PersonType = "Fremmed",
                PersonAdresses = new List<PersonAdresse>(), 
                TelefonBog = new List<TelefonNummer>()
            };

            var tlf = new TelefonNummer {Telefonnummer=01234567, TelefonnummerType="Arbejde", TelefonSelskab="TDC", Person=p};

            p.TelefonBog.Add(tlf);

            var pa = new PersonAdresse {Adresse = a, Person = p, Type = "Hjem"};

            p.PersonAdresses.Add(pa);

            try
            {
                Repository<Person>.CreateDatabase().Wait();
                Repository<Person>.CreatePersonDocument(p).Wait();
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
