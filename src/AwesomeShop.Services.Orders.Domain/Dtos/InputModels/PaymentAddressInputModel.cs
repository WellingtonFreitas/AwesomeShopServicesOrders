namespace AwesomeShop.Services.Orders.Domain.Dtos.InputModels
{
    public class PaymentAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
