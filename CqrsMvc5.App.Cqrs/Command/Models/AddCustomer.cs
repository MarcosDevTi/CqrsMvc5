using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMvc5.App.Cqrs.Command.Models
{
    public class AddCustomer : ICommand
    {
        public AddCustomer(string firstName, string lastName, string email)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public Guid Id { get; }
        public DateTime Timestamp { get; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
