using System.ComponentModel.DataAnnotations;

namespace HandIn2._1
{
    public class TelefonNummer
    {

        public TelefonNummer(int telefonNr, string type, string selskab = "")
        {
            Telefonnummer = telefonNr;
            TelefonnummerType = type;
            TelefonSelskab = TelefonSelskab;
        }
        [Key]
        public int Telefonnummer { get; set; }

        public string TelefonnummerType { get; set; }

        public string TelefonSelskab { get; set; }

        public virtual Person Person { get; set; }
        
    }
}