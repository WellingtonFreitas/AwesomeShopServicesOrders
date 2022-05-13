using System;

namespace AwesomeShop.Services.Orders.Domain.Dtos.InputModels
{
    public class CustomerInputModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
