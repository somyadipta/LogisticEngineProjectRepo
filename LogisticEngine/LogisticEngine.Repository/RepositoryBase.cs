using LogisticEngine.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository
{
    public class RepositoryBase : IDisposable
    {
        private readonly LogisticDbContext _Context;
        public RepositoryBase()
        {
            _Context = new LogisticDbContext();
        }

        public bool Add<T>(T entity) where T: class
        {
            this._Context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            this._Context.SaveChanges();
            return true;
        }

        public bool Update<T>(T entity) where T : class
        {
            this._Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this._Context.SaveChanges();
            return true;
        }

        public bool Remove<T>(T entity) where T : class
        {
            return true;
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return this._Context.Set<T>().Where(condition);
        }

        public IQueryable<T> GetWith<T>(string includeEntities, Expression<Func<T, bool>> condition) where T : class
        {
            return this._Context.Set<T>().Include(includeEntities).Where(condition);
        }

        public void Dispose()
        {
            this._Context.Dispose();
        }
    }
}
