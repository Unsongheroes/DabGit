using System.Collections.Generic;

namespace HandIn2._1
{
    public class Adresse
    {
        private string _vejnavn;
        private int _husnummer;
        
        public Adresse(string vejnavn, int husnummer, List<ByPostnummer> byPost)
        {
            Vejnavn(vejnavn);
            Husnummer(husnummer);
            ByPostnummer = byPost;
        }

        public string Vejnavn(string vejnavn)
        {
            return _vejnavn = vejnavn;
        }

        public int Husnummer(int husnummer)
        {
            return _husnummer = husnummer;
        }

        public virtual List<ByPostnummer> ByPostnummer { get; set; }
        
        public virtual List<Person> Persons { get; set; }

        

    }
}