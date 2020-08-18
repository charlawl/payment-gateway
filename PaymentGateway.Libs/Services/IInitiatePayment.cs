using System.Threading.Tasks;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public interface IInitiatePayment
    {
        Task<BankResponse> InitiatePaymentWithCardDetails(MerchantPayment payment);
    }
}
