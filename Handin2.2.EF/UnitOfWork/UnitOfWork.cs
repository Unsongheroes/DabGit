using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2._2.EF.Interfaces;
using Handin2._2.EF.Repositories;

namespace Handin2._2.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonContext _context;

        public UnitOfWork(PersonContext context)
        {
            _context = context;
            Persons = new PersonRepository(_context);
        }

        public void Dispose()
        {
            var itemsToDelete = Persons.GetAll();
            Persons.RemoveRange(itemsToDelete);

            var itemsToDelete2 = _context.ByPostnummers;
            _context.ByPostnummers.RemoveRange(itemsToDelete2);

            var itemsToDelete3 = _context.Adresses;
            _context.Adresses.RemoveRange(itemsToDelete3);
        }

        public IPersonRepository Persons {  get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
