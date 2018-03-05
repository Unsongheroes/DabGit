using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    public static class JoinPersonAdresse
    {
        public static List<item> PersonAdresses = new List<item>();
    }

    public class item
    {
        public string type { get; set; }

        public Person person { get; set; }

        public Adresse adresse { get; set; }
    }
}
