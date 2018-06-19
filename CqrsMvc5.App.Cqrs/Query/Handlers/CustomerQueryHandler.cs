using System.Collections.Generic;
using System.Linq;
using CqrsMvc5.App.Cqrs.Query.Models;
using CqrsMvc5.App.Cqrs.Query.Queries;
using CqrsMvc5.Domain;

namespace CqrsMvc5.App.Cqrs.Query.Handlers
{
    public class CustomerQueryHandler : 
        IQueryHandler<GetCustomers, IReadOnlyList<CustomerModel>>,
        IQueryHandler<GetCustomerById, CustomerModel>
    {
        private readonly ICustomerRespository _customerRespository;

        public CustomerQueryHandler(ICustomerRespository customerRespository)
        {
            _customerRespository = customerRespository;
        }
        public IReadOnlyList<CustomerModel> Handle(GetCustomers query)
        {
            return _customerRespository.Where(x => x.Active == query.Active).Select(x => new CustomerModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }

        public CustomerModel Handle(GetCustomerById query)
        {
            var cust = _customerRespository.GetById(query.Id);
            return new CustomerModel
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Email = cust.Email
            };
        }
    }
}
