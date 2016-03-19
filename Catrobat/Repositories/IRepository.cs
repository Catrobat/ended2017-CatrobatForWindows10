using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Catrobat.Repositories
{
    interface IRepository<T> where T : class
    {
        T Get(string id);

        IList<T> GetAll();

        T Add(T item);

        T Update(T item);

        void Delete(T item);

    }
}
