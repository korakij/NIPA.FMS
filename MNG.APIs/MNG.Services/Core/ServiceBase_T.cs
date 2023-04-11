using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services.Core
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        protected readonly AppDb db;

        public ServiceBase(AppDb db) => this.db = db;

        public IQueryable<T> Query(Func<T, bool> predicate)
          => db.Set<T>().Where(predicate).AsQueryable();

        public IQueryable<T> All => Query(x => true);

        public virtual T Add(T item) => db.Set<T>().Add(item).Entity;
        public virtual T Update(T item) => db.Set<T>().Update(item).Entity;
        public virtual T Remove(T item) => db.Set<T>().Remove(item).Entity;

        public T Find(params object[] keys)
          => db.Set<T>().Find(keys);

        public async Task<T> FindAsync(params object[] keys)
          => await db.Set<T>().FindAsync(keys);
    }
}
