using System;

namespace CqrsMvc5.App.Cqrs.Query.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
