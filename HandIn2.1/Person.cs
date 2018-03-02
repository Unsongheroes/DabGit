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
        private List<Adresse> _adresses;

        public Person(int cpr, string fornavn, string efternavn, string personType, List<Adresse> adresses, string email = "", string mellemnavn = "")
        {
            _adresses = adresses;
            PersonId(cpr);
            Fornavn(fornavn);
            Mellemnavn(mellemnavn);
            Efternavn(efternavn);
            PersonType(personType);
            EMail(email);
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

        public virtual ref List<Adresse> Adresses
        {
            get { return ref _adresses; }
        }
    }
}
