using System.Collections.Generic;
using CqrsMvc5.App.Cqrs.Query.Models;

namespace CqrsMvc5.App.Cqrs.Query.Queries
{
    public class GetCustomers : IQuery<IReadOnlyList<CustomerModel>>
    {
        public GetCustomers(bool active)
        {
            Active = active;
        }
        public bool Active { get; private set; }
    }
}
