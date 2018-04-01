using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HandIn2_2_DDB
{
    public class UnitOfWork<T> where T : Person
    {
        private List<T> Changed = new List<T>();
        private List<T> New = new List<T>();
        private List<T> Deleted = new List<T>();

        public void Add(T item)
        {
            New.Add(item);
        }

        public void Update(T item)
        {
            Changed.Add(item);
        }

        public void Delete(T item)
        {
            Deleted.Add(item);
        }

        public void Commit()
        {
            Repository<Person>.CreateDatabase().Wait();
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (T item in Changed)
                {
                    Repository<T>.UpdateDocumentAsync(item.Cpr, item).Wait();
                }

                foreach (T item in New)
                {
                    Repository<T>.CreateDocumentAsync(item).Wait();
                }

                foreach (T item in Deleted)
                {
                    Repository<T>.DeleteDocumentAsync(item.Cpr).Wait();
                }
            }
        }

        public Person FindByJd(string id)
        {
           var read = Repository<Person>.GetDocumentAsync(id).Result;
            return read;
        }

    }
}
