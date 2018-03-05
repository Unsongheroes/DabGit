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

        public Person(int cpr, string fornavn, string efternavn,TelefonNummer tlfNummer, string personType, Adresse adresse, string email = "", string mellemnavn = "")
        {
            _adresses = new List<Adresse>();
            TelefonNumre = new List<TelefonNummer>();
            addAddress(adresse, "primær");
            PersonId(cpr);
            Fornavn(fornavn);
            Mellemnavn(mellemnavn);
            Efternavn(efternavn);
            PersonType(personType);
            EMail(email);
            TelefonNumre.Add(tlfNummer);
            
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

        public void addAddress(Adresse adress, string type)
        {
            item tmp = new item();
            tmp.adresse = adress;
            tmp.person = this;
            tmp.type = type;


            JoinPersonAdresse.PersonAdresses.Add(tmp);
            _adresses.Add(adress);
            adress.Persons.Add(this);
        }

        public void print()
        {
            if(_mellemnavn == "")
            Console.WriteLine(_fornavn + " " + _efternavn );
            else
            {
                Console.WriteLine(_fornavn + " " + _mellemnavn + " " + _efternavn);
            }
        }

        public void printPhone()
        {
            foreach (var VARIABLE in TelefonNumre)
            {
                Console.WriteLine(VARIABLE.Telefonnummer.ToString() + " " + VARIABLE.TelefonnummerType + " " + VARIABLE.TelefonSelskab);
            }

        }
    }
}
