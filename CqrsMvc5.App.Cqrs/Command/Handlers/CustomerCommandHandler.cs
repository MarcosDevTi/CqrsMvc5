using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.App.Cqrs.Command.Models;
using CqrsMvc5.Domain;
using CqrsMvc5.Domain.Entities;

namespace CqrsMvc5.App.Cqrs.Command.Handlers
{
    public class CustomerCommandHandler : 
        ICommandHandler<AddCustomer>
    {
        private readonly ICustomerRespository _customerRespository;

        public CustomerCommandHandler(ICustomerRespository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        public void Handle(AddCustomer command)
        {
            _customerRespository.Add(new Customer(command.FirstName, command.LastName, command.Email));
        }
    }
}
