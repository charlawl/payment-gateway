using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public interface IPaymentPublisher
    {
        void PublishPaymentSubmitted(MerchantPayment payment);
    }
}
