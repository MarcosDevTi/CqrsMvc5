using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.DomainShared.Entities;

namespace CqrsMvc5.Domain
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T obj);
        T GetById(Guid id);
        IEnumerable<T> Where(Expression<Func< T, bool>> predicate);
    }
}
