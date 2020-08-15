using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

    }
    public class MerchantPaymentRequest
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string MerchantId { get; set; }

    }

    public class MerchantPaymentResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string MerchantId { get; set; }
        public Status Status { get; set; }
    }

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
