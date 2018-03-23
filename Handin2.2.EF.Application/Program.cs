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



            ByPostNummer Aarhus = new ByPostNummer();
            Aarhus.Postnummer = 8000;
            Aarhus.ByNavn = "Aarhus";
            Aarhus.Land = "Denmark";

            Adresse Pers = new Adresse();

            Person Per = new Person();

            Pers.Husnummer = 1;
            Pers.VejNavn = "kildemosevej";
            Pers.Type = "Primær";
            Pers.Persons.Add(Per);
            Aarhus.Adresses.Add(Pers);
            Per.Cpr = 32;
            Per.EfterNavn = "Andersen";
            Per.PersonType = "CEO";
            Pers.Persons.Add(Per);
            Per.Adresses.Add(Pers);

            using (var unitOfWork = new UnitOfWork.UnitOfWork(new PersonContext()))
            {
                unitOfWork.Persons.Add(Per);
                
                var person = unitOfWork.Persons.Get(1);

                var persons = unitOfWork.Persons.GetPersonsByLastName(1);
                Console.WriteLine(person);
                unitOfWork.Complete();
            }
        }
    }
}
