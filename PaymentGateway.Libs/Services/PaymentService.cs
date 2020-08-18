using System.Threading.Tasks;
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

        public async Task<BankResponse> SubmitPaymentToBank(MerchantPayment payment)
        {
            return await _initiatePayment.InitiatePaymentWithCardDetails(payment);
        }
    }


}
