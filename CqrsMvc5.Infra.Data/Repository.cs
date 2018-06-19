using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.Domain;
using CqrsMvc5.DomainShared.Entities;

namespace CqrsMvc5.Infra.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CqrsMvc5Context Context;
        protected DbSet<T> DbSet;
        public Repository(CqrsMvc5Context context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public void Add(T obj)
        {
            DbSet.Add(obj);
            Context.SaveChanges();
        }

        public T GetById(Guid id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
