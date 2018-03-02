namespace HandIn2._1
{
    public class ByPostnummer
    {
        public int PostNummer { get; set; }

        public string ByNavn { get; set; }

        public string Land { get; set; }

        public virtual Person Person { get; set; }

        public virtual int PersonId { get; set; }
    }
}