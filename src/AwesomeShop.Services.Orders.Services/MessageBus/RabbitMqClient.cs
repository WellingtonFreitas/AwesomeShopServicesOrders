using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using AwesomeShop.Services.Orders.Services.Subscribers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System;
using System.Text;

namespace AwesomeShop.Services.Orders.Services.MessageBus
{
    public class RabbitMqClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMqClient()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            //_connection = connectionFactory.CreateConnection(connectionName);
            _connection = connectionFactory.CreateConnection("order-service-producer");

        }
        public void Publish(object message, string routingKey, string exchange)
        {
            var channel = _connection.CreateModel();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var payload = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(payload);

            channel.ExchangeDeclare(exchange: exchange, type: "topic", durable: true);

            channel.BasicPublish(exchange: exchange, routingKey: routingKey,basicProperties: null, body: body);
        }
    }
}
