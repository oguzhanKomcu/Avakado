using Avakado.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Avakado.Services.CouponApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Coupon>().HasData(
                 new Coupon { Id = 1, CouponCode = "KOD1", DiscountAmount = 10.0, MinAmount = 50 },
                 new Coupon { Id = 2, CouponCode = "KOD2", DiscountAmount = 15.0, MinAmount = 100 },
                 new Coupon { Id = 3, CouponCode = "KOD3", DiscountAmount = 20.0, MinAmount = 150 },
                 new Coupon { Id = 4, CouponCode = "KOD4", DiscountAmount = 25.0, MinAmount = 200 },
                 new Coupon { Id = 5, CouponCode = "KOD5", DiscountAmount = 30.0, MinAmount = 250 }
             );
        }
    }
}
