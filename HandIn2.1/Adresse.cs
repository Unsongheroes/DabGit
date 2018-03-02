using System.Collections.Generic;

namespace HandIn2._1
{
    public class Adresse
    {
        private string _vejnavn;
        private int _husnummer;
        private string _type;
        private List<Person> _persons;

        public Adresse(string vejnavn, int husnummer, ByPostnummer byPost, string type, List<Person> persons)
        {
            Vejnavn(vejnavn);
            Husnummer(husnummer);
            ByPostnummer = byPost;
            _persons = persons;
            Type(type);
        }

        public string Vejnavn(string vejnavn)
        {
            return _vejnavn = vejnavn;
        }

        public int Husnummer(int husnummer)
        {
            return _husnummer = husnummer;
        }

        public string Type(string type)
        {
            return _type = type;
        }

        public virtual ByPostnummer ByPostnummer { get; set; }

        public virtual ref List<Person> Persons
        {
            get { return ref _persons; }
        }
    }
}