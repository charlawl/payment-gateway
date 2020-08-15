using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace PaymentGateway.Libs.Models
{
    
    public class BankResponse
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public Status Status { get; set; }

    }
}
