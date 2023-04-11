using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services.Core
{
    public class QueryServiceBase<T> : IQueryService<T> where T : class
    {
        protected readonly AppDb db;

        public QueryServiceBase(AppDb db) => this.db = db;

        public IQueryable<T> Query(Func<T, bool> predicate)
          => db.Query<T>().Where(predicate).AsQueryable();

        public IQueryable<T> All => Query(x => true);

    }
}
