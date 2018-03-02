namespace HandIn2._1
{
    public class TelefonNummer
    {

        public int Telefonnummer { get; set; }

        public string TelefonnummerType { get; set; }

        public string TelefonSelskab { get; set; }

        public virtual Person Person { get; set; }

        public int PersonId { get; set; }
    }
}