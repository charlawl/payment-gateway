using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Add(MerchantPaymentRequest paymentRequest);
        Task<MerchantPaymentRequest> GetById(Guid id);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _dbContext;

        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(MerchantPaymentRequest paymentRequest)
        {
            _dbContext.PaymentRequests.Add(paymentRequest);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<MerchantPaymentRequest> GetById(Guid id)
        {
            return _dbContext.PaymentRequests.Find(id);
        }
    }
}
