using System;
using CqrsMvc5.App.Cqrs.Query.Models;

namespace CqrsMvc5.App.Cqrs.Query.Queries
{
    public class GetCustomerById : IQuery<CustomerModel>
    {
        public GetCustomerById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
