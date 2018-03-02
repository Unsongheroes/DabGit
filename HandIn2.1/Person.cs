using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    public class Person
    {
        private int _cpr;
        private string _fornavn;
        private string _mellemnavn;
        private string _efternavn;
        private string _personType;
        private string _eMail;

        public Person(int cpr, string fornavn, string efternavn, string personType, TelefonNummer tlfNummer, Adresse adresse, string email = "", string mellemnavn = "")
        {
            PersonId(cpr);
            Fornavn(fornavn);
            Mellemnavn(mellemnavn);
            Efternavn(efternavn);
            PersonType(personType);
            EMail(email);
            TelefonNumre.Add(tlfNummer);
            Adresses.Add(adresse);
        }
        public int PersonId(int cpr)
        {
            return _cpr = cpr;
        }

        public string Fornavn(string fornavn)
        {
            return _fornavn = fornavn;
        }

        public string Mellemnavn(string mellemnavn)
        {
            return _mellemnavn = mellemnavn;
        }

        public string Efternavn(string efternavn)
        {
            return _efternavn = efternavn;
        }

        public string PersonType(string persontype)
        {
            return _personType = persontype;
        }

        public string EMail(string email)
        {
            return _eMail = email;
        }

        public virtual List<TelefonNummer> TelefonNumre { get; set; }

        public virtual List<Adresse> Adresses { get; set; }

    }
}
