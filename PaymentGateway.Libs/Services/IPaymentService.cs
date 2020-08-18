using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public interface IPaymentService
    {
        Task<BankResponse> SubmitPaymentToBank(MerchantPayment payment);
    }
}
