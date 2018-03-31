using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2._2.EF
{
    public class Person
    {
        [Key]
        public int Cpr { get; set; }
        public string Fornavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string PersonType { get; set; }
        public string Email { get; set; }

        public List<TelefonNummer> TelefonBog { get; set; }

        public List<PersonAdresse> PersonAdresses { get; set; }

        public Person()
        {
            TelefonBog = new List<TelefonNummer>();
            PersonAdresses = new List<PersonAdresse>();
        }
    }

    public class Adresse
    {
        [Key]
        public string VejNavn { get; set; }
        public int Husnummer { get; set; }
        
        public List<PersonAdresse> PersonAdresses { get; set;}
        
        public ByPostNummer ByPostNummer { get; set; }

        public Adresse()
        {
            PersonAdresses = new List<PersonAdresse>();
        }
        

    }

    public class TelefonNummer
    {
        [Key]
        public int Telefonnummer { get; set; }
        public string TelefonnummerType { get; set; }
        public string TelefonSelskab { get; set; }

        public int PersonCPR { get; set; }
        public Person Person { get; set; }

        
    }

    public class ByPostNummer
    {
        [Key]
        public int Postnummer { get; set; }
        public string ByNavn { get; set; }
        public string Land { get; set; }
        

    }
    

    public class PersonAdresse
    {
        [Key]
        public int MatchId { get; set; }

        public string Type { get; set; }

        public int PersonCpr { get; set; }
        public Person Person { get; set; }

        public string AdresseNavn { get; set; }
        public Adresse Adresse { get; set; }

        
    }
}
