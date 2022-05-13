using System;

namespace AwesomeShop.Services.Orders.Domain.Bases
{
    public class EntityBase<TIdentifier> 
    {
        public TIdentifier Id { get; set; }
    }
}