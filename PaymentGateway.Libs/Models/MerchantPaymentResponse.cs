using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaymentGateway.Libs.Models
{
    public class MerchantPaymentResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public string MerchantId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

    }
}
