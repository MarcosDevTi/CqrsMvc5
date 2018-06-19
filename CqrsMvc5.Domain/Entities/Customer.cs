using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsMvc5.DomainShared.Entities;

namespace CqrsMvc5.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            
        }
        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Active = true;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
    }
}
