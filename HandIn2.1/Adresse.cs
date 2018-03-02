using System.ComponentModel.DataAnnotations;

namespace HandIn2._1
{
    public class Adresse
    {
        [Key]
        public string Adressen { get; set; }

        public string Vejnavn { get; set; }

        public int Husnummer { get; set; }

        public virtual ByPostnummer ByPostnummer { get; set; }

        public int Postnummer { get; set; }
        public virtual Person Person { get; set; }

        public int PersonId { get; set; }

    }
}