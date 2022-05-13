using AwesomeShop.Services.Orders.Domain.Bases;
using AwesomeShop.Services.Orders.Domain.Interfaces.Events;
using System.Collections.Generic;

namespace AwesomeShop.Services.Orders.Domain.Entities
{
    public class AggregateRoot<TIdentifier> : EntityBase<TIdentifier>
    {
        private  List<IDomainEvent> _events = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
        {
            if (_events == null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);    
        }
    }
}
