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
            
            _context.Dispose(true);
            

        }



        public IPersonRepository Persons { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
