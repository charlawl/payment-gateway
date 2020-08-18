using Microsoft.EntityFrameworkCore;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MerchantPayment>().Property(b => b.Status).HasDefaultValue(Status.Accepted);
        }

        public DbSet<MerchantPayment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

    }
}
