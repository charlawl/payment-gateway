using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Add(MerchantPayment paymentRequest);
        Task<MerchantPayment> GetById(Guid id);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _dbContext;

        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(MerchantPayment payment)
        {
            _dbContext.Payments.Add(payment);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<MerchantPayment> GetById(Guid id)
        {
            return _dbContext.Payments
                    .Include(request => request.PaymentMethod)
                    .Single(r => r.Id == id);
        }
    }
}
