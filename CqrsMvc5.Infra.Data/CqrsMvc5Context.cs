using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.Domain.Entities;

namespace CqrsMvc5.Infra.Data
{
    public class CqrsMvc5Context : DbContext
    {
        public CqrsMvc5Context()
        :base("CqrsMvc5")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public IReadOnlyList<Customer> GetAll()
        {
            var act = true;
            var result = Customers.Where(c => c.Active == act);
            return result.ToList();
        }

        public IReadOnlyList<Customer> GetAllExp(Expression<Func<Customer, bool>> predicate)
        {
            return Customers.Where(predicate).ToList();
        }
    }
}
