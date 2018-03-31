using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandIn2_2_DDB
{
    public class Person
    {
        public int Cpr { get; set; }
        public string Fornavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string PersonType { get; set; }
        public string Email { get; set; }
        public List<TelefonNummer> TelefonBog { get; set; }
        public List<PersonAdresse> PersonAdresses { get; set; }

        /*
         * uvidst om der skal være en constructor - dette spørgsmål gælder for alle classerne i denne fil.
         */

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Adresse
    {
        public int AdresseId { get; set; }
        public string VejNavn { get; set; }
        public int Husnummer { get; set; }
        public List<PersonAdresse> PersonAdresses { get; set; }
        public ByPostNummer ByPostNummer { get; set; }
    }

    public class TelefonNummer
    {
        public int Telefonnummer { get; set; }
        public string TelefonnummerType { get; set; }
        public string TelefonSelskab { get; set; }

        
    }

    public class ByPostNummer
    {  
        public int Postnummer { get; set; }
        public string ByNavn { get; set; }
        public string Land { get; set; }
    }

    
    public class PersonAdresse
    {
        public int MatchId { get; set; }
        public string Type { get; set; }

        public Adresse Adresse { get; set; }
    }

}
