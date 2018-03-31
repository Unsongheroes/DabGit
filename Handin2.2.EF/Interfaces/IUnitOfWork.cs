using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2._2.EF.Interfaces
{
    
        interface IUnitOfWork : IDisposable
        {
            IPersonRepository Persons { get; }
            int Complete();


        }
    }

