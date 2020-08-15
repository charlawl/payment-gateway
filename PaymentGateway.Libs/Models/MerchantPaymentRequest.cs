using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace PaymentGateway.Libs.Models
{
    public class MerchantPaymentRequest
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string MerchantId { get; set; }
        public Status Status { get; set; }

        public class PaymentMethods
        {
            public Guid Id { get; set; }
            public string Type { get; set; }
            public Fields Fields { get; set; }
        }

        public class Fields
        {
            public Guid Id { get; set; }
            public string Number { get; set; }
            public string ExpirationMonth { get; set; }
            public string ExpirationYear { get; set; }
            public string Cvv { get; set; }
        }

       
    }
}
