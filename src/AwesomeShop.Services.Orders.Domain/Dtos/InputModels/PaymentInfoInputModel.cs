namespace AwesomeShop.Services.Orders.Domain.Dtos.InputModels
{
    public class PaymentInfoInputModel
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
