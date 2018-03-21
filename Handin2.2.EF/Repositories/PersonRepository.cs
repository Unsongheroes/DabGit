using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Handin2._2.EF.Interfaces;

namespace Handin2._2.EF.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetPersonsByLastName(int amountofPersons)
        {
            return PersonContext.Persons.OrderBy(c => c.EfterNavn).Take(amountofPersons).ToList();
        }

        public PersonContext PersonContext => Context as PersonContext;
    }
}
