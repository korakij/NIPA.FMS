using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services.Core
{
    public interface IQueryService<T> where T : class
    {
        IQueryable<T> Query(Func<T, bool> predicate);
        IQueryable<T> All { get; }
    }
}
