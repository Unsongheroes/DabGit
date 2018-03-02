namespace HandIn2._1
{
    public class Adresse
    {
        private string _vejnavn;
        private int _husnummer;
        
        public Adresse(string vejnavn, int husnummer,int postnummer, int PersonId)
        {
            Vejnavn(vejnavn);
            Husnummer(husnummer);
        }

        public string Vejnavn(string vejnavn)
        {
            return _vejnavn = vejnavn;
        }

        public int Husnummer(int husnummer)
        {
            return _husnummer = husnummer;
        }

        public virtual ByPostnummer ByPostnummer { get; set; }

        public int Postnummer { get; set; }
        public virtual Person Person { get; set; }

        public int PersonId { get; set; }

    }
}