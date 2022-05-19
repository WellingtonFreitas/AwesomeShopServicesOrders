using Newtonsoft.Json;
using System;

namespace AwesomeShop.Services.Orders.Domain.Entities
{
    public class PaymentAccepted
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }
        [JsonProperty("fullName")]
        public string FullName { get; private set; }
        [JsonProperty("email")]
        public string Email { get; private set; }
    }
}
