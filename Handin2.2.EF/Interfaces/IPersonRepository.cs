using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2._2.EF.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPersonsByLastName(int amountofPersons);
    }
}
