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
        public List<Adresse> Adresses { get; set; }
        public List<TelefonNummer> TelefonNummers { get; set; }

        
        public Person()
        {
            Adresses = new List<Adresse>();
            TelefonNummers = new List<TelefonNummer>();
        }

    }

    public class Adresse
    {
        [Key]
        public string VejNavn { get; set; }
        public string Type { get; set; } //tjek kommentar fra hand_in 2.1 skal dette undlades?
        public int Husnummer { get; set; }
        public List<Person> Persons { get; set; }
        public ByPostNummer ByPostNummer { get; set; }

        public Adresse()
        {
            Persons = new List<Person>();
            ByPostNummer = new ByPostNummer();
        }

    }

    public class TelefonNummer
    {
        [Key]
        public int Telefonnummer { get; set; }
        public string TelefonnummerType { get; set; }
        public string TelefonSelskab { get; set; }
        public virtual Person Person { get; set; }

        public TelefonNummer()
        {
            Person = new Person();
        }
    }

    public class ByPostNummer
    {
        [Key]
        public int Postnummer { get; set; }
        public string ByNavn { get; set; }
        public string Land { get; set; }
        public List<Adresse> Adresses { get; set; }

        public ByPostNummer()
        {
            Adresses = new List<Adresse>();
        }

    }

    /*
    Skal dette med i denne opgave, eller kan vi gøre det med lister i persons & adresser, som peger på hinanden?
    */
    //public static class JoinPersonAdresse
    //{
    //    public static List<Item> PersonAdresses = new List<Item>();
    //}

    //public class Item
    //{
    //    [Key]
    //    public string Type { get; set; }
    //    public Person Person { get; set; }
    //    public Adresse Adresse { get; set; }
    //}
}
