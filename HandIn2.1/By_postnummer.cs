namespace HandIn2._1
{
    public class ByPostnummer
    {
        private int _postnummer;
        private string _byNavn;
        private string _land;
        

        public ByPostnummer(int postnummer,string ByNavn,string land)
        {
            PostNummer(postnummer);
        }

        public int PostNummer(int postnummer)
        {
            return _postnummer = postnummer;
        }

        public string ByNavn(string bynavn)
        {
           return _byNavn = bynavn;
        }

        public string Land(string land)
        {
            return _land = land;
        }

        public virtual Person Person { get; set; }

        public virtual int PersonId { get; set; }
    }
}