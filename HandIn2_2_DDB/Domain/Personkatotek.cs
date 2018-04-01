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
        [JsonProperty(PropertyName = "id")]
        public string Cpr { get; set; }
        [JsonProperty(PropertyName = "fornavn")]
        public string Fornavn { get; set; }
        [JsonProperty(PropertyName = "mellemnavn")]
        public string MellemNavn { get; set; }
        [JsonProperty(PropertyName = "efternavn")]
        public string EfterNavn { get; set; }
        [JsonProperty(PropertyName = "persontype")]
        public string PersonType { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "telefonbog")]
        public List<TelefonNummer> TelefonBog { get; set; }
        [JsonProperty(PropertyName = "personadresser")]
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
        [JsonProperty(PropertyName = "id")]
        public string AdresseId { get; set; }
        [JsonProperty(PropertyName = "vejnavn")]
        public string VejNavn { get; set; }
        [JsonProperty(PropertyName = "husnummer")]
        public int Husnummer { get; set; }
        [JsonProperty(PropertyName = "bypostnummer")]
        public ByPostNummer ByPostNummer { get; set; }
    }

    public class TelefonNummer
    {
        [JsonProperty(PropertyName = "id")]
        public string Telefonnummer { get; set; }
        [JsonProperty(PropertyName = "telefonnummertype")]
        public string TelefonnummerType { get; set; }
        [JsonProperty(PropertyName = "telefonselskab")]
        public string TelefonSelskab { get; set; }

        
    }

    public class ByPostNummer
    {
        [JsonProperty(PropertyName = "id")]
        public string Postnummer { get; set; }
        [JsonProperty(PropertyName = "bynavn")]
        public string ByNavn { get; set; }
        [JsonProperty(PropertyName = "land")]
        public string Land { get; set; }
    }

    
    public class PersonAdresse
    {
        [JsonProperty(PropertyName = "id")]
        public string MatchId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "adresse")]
        public Adresse Adresse { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }

}
