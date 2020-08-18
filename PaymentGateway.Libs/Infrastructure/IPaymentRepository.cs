using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Infrastructure
{
    public interface IPaymentRepository
    { 
        Task Add(MerchantPayment payment);
        Task<MerchantPayment> GetById(Guid id);
        Task Update(Guid id, MerchantPayment payment);
    }


}
