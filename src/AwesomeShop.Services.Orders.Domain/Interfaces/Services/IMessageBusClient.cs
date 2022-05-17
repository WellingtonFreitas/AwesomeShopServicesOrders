namespace AwesomeShop.Services.Orders.Domain.Interfaces.Services
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}
