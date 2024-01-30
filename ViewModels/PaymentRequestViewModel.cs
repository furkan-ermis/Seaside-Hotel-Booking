namespace DestinyHaven.ViewModels
{
    public class PaymentRequestViewModel
    {
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerSurname { get; set; }
        public string BuyerGsmNumber { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerIdentityNumber { get; set; }
        public DateTime BuyerLastLoginDate { get; set; }
        public DateTime BuyerRegistrationDate { get; set; }
        public string BuyerRegistrationAddress { get; set; }
    }
}
