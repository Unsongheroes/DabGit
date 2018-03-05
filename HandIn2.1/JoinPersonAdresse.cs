using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    public static class JoinPersonAdresse
    {
        public static List<Item> PersonAdresses = new List<Item>();
    }

    public class Item
    {
        public string Type { get; set; }

        public Person Person { get; set; }

        public Adresse Adresse { get; set; }

        public void Print()
        {
            Console.Write("Person: ");
            Person.print();
            Console.Write("Adresse: ");
            Adresse.PrintAdress();
        }
    }
}
