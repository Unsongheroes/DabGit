using System;
using System.Collections.Generic;

namespace HandIn2._1
{
    public class ByPostnummer
    {
        private int _postnummer;
        private string _byNavn;
        private string _land;
        

        public ByPostnummer(int postnummer,string byNavn,string land)
        {
            Adresses = new List<Adresse>();
            PostNummer(postnummer);
            ByNavn(byNavn);
            Land(land);
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

        public void AddAdress(Adresse adress)
        {
            Adresses.Add(adress);
        }

        public void printAdresses()
        {
            foreach (var VARIABLE in Adresses)
            {
                VARIABLE.PrintAdress();
            }
            
                   
        }

        public virtual List<Adresse> Adresses { get; set; }


    }
}