using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaymentGateway.Libs.Models
{
    
    public class BankResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        public DateTime TransactionDate => DateTime.UtcNow;

    }
}
