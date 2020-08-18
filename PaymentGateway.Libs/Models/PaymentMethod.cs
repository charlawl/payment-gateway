using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Libs.Models
{
    public class PaymentMethod
    {
        public Guid PaymentMethodId { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
    }
}
