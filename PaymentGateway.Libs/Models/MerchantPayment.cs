using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaymentGateway.Libs.Models
{
    public class MerchantPayment
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string MerchantId { get; set; }
        public Status Status { get; set; }
        public DateTime TransactionDate => DateTime.UtcNow;

    }
    
}
