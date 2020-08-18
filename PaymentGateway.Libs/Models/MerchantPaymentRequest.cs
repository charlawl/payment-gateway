namespace PaymentGateway.Libs.Models
{
    public class MerchantPaymentRequest
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string MerchantId { get; set; }

    }
}
