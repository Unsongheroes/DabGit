using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandIn2._1
{
    public class Adresse
    {
        [Key]
        public string _vejnavn { get; set; }
        private int _husnummer { get; set; }
        private string _type { get; set; }
        private List<Person> _persons;

        public Adresse(string vejnavn, int husnummer, ByPostnummer byPost, string type)
        {
            _vejnavn = vejnavn;
            _husnummer = husnummer;
            ByPostnummer = byPost;
            byPost.AddAdress(this);
            _persons = new List<Person>();
            _type = type;
        }

        

        public void AddPerson(Person person)
        {
            Item tmp = new Item();
            tmp.Adresse = this;
            tmp.Person = person;
            tmp.Type = _type;

            JoinPersonAdresse.PersonAdresses.Add(tmp);

            _persons.Add(person);
            person.Adresses.Add(this);
        }

        public virtual ByPostnummer ByPostnummer { get; set; }


        public virtual ref List<Person> Persons
        {
            get { return ref _persons; }
        }

        public void PrintPersons()
        {
            foreach (var item in Persons)
            {
                item.print();
            }
        }

        public void PrintAdress()
        {
            Console.WriteLine(_vejnavn + " " + _husnummer + " " + _type);
        }
    }
}