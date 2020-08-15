﻿using System.Threading.Tasks;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public class PaymentService : IPaymentService
    {
        private static IInitiatePayment _initiatePayment;

        public PaymentService(IInitiatePayment initiatePayment)
        {
            _initiatePayment = initiatePayment;
        }

        public async Task<PaymentModel> SubmitPaymentToBank(MerchantPaymentRequest paymentRequest)
        {
            return await _initiatePayment.InitiatePaymentWithCardDetails(paymentRequest);
        }


    }

    public interface IPaymentService
    {
        Task<PaymentModel> SubmitPaymentToBank(MerchantPaymentRequest paymentRequest);
    }
}