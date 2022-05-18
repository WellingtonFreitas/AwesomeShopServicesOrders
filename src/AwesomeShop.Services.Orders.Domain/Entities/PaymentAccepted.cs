using System;

namespace AwesomeShop.Services.Orders.Domain.Entities
{
    public class PaymentAccepted
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
