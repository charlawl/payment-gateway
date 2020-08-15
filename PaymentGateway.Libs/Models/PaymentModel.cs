using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace PaymentGateway.Libs.Models
{
    
    public class PaymentModel
    {
        //ID needs to come from DB?
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("payment_method.type")]
        public string PaymentType { get; set; }
        [JsonProperty("payment_method.fields.number")]
        public string CardNumber { get; set; }

    }
}
