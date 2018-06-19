using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.Domain;
using CqrsMvc5.Domain.Entities;

namespace CqrsMvc5.Infra.Data
{
    public class CustomerRepository : Repository<Customer>, ICustomerRespository
    {
        public CustomerRepository(CqrsMvc5Context context) : base(context)
        {
        }
    }
}
