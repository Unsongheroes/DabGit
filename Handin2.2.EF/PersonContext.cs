using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2._2.EF
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=HandIn2EF")
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Adresse> Adresses { get; set; }

        public DbSet<ByPostNummer> ByPostnummers { get; set; }

        public DbSet<TelefonNummer> TelefonNummers { get; set; }
    }
}
