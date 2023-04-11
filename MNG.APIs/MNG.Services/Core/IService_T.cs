using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services.Core
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Query(Func<T, bool> predicate);
        IQueryable<T> All { get; }

        T Find(params object[] keys);
        Task<T> FindAsync(params object[] keys);

        T Add(T item);
        T Update(T item);
        T Remove(T item);
    }
}
