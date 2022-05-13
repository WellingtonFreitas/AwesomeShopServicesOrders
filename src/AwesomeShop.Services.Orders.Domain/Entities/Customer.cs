using AwesomeShop.Services.Orders.Domain.Bases;
using System;

namespace AwesomeShop.Services.Orders.Domain.Entities
{
    public class Customer : EntityBase<Guid>
    {
        public Customer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }
        
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}