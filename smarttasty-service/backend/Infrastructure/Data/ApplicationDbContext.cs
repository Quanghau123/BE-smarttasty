using Microsoft.EntityFrameworkCore;
using backend.Domain.Models;
using backend.Infrastructure.Data.Seeders;

namespace backend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<DishPromotion> DishPromotions { get; set; }
        public DbSet<OrderPromotion> OrderPromotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BookingCustomer> BookingCustomers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ReservationStatusHistory> ReservationStatusHistories { get; set; }

        // ------------------ Các bảng Thanh toán ------------------
        public DbSet<Payment> Payments { get; set; }
        public DbSet<VNPayPayment> VNPayPayments { get; set; }
        public DbSet<ZaloPayPayment> ZaloPayPayments { get; set; }
        public DbSet<CODPayment> CODPayments { get; set; }
        public DbSet<PaymentTransactionLog> PaymentTransactionLogs { get; set; }
        public DbSet<Refund> Refunds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Restaurants)
                .HasForeignKey(r => r.OwnerId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PasswordResetToken>()
               .HasOne(p => p.User)
               .WithMany(u => u.PasswordResetTokens)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Restaurant)
                .WithMany(r => r.Dishes)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.Restaurant)
                .WithMany(r => r.Promotions)
                .HasForeignKey(p => p.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishPromotion>()
                .HasOne(dp => dp.Dish)
                .WithMany(d => d.DishPromotions)
                .HasForeignKey(dp => dp.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishPromotion>()
                .HasOne(dp => dp.Promotion)
                .WithMany(p => p.DishPromotions)
                .HasForeignKey(dp => dp.PromotionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderPromotion>()
                .HasOne(op => op.Promotion)
                .WithMany(p => p.OrderPromotions)
                .HasForeignKey(op => op.PromotionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeReview>()
                .HasOne(rr => rr.User)
                .WithMany(u => u.RecipeReviews)
                .HasForeignKey(rr => rr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeReview>()
                .HasOne(rr => rr.Recipe)
                .WithMany(r => r.RecipeReviews)
                .HasForeignKey(rr => rr.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // ------------------ Order ↔ Payment (1-1) ------------------
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.CODPayment)
                .WithOne(c => c.Payment)
                .HasForeignKey<CODPayment>(c => c.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seeder
            modelBuilder.SeedUsers();
            modelBuilder.SeedRestaurants();
            modelBuilder.SeedDishes();
            modelBuilder.SeedPromotions();
            modelBuilder.SeedReviews();
            modelBuilder.SeedRecipes();
            modelBuilder.SeedRecipeReviews();

        }

    }
}

//add + update (add mà không update là lỗi nguyên db vì không so sánh với migrations cũ được)
//dotnet ef migrations add update_seeder
//dotnet ef database update

//delete migrations nếu update bị lỗi
//dotnet ef migrations remove

//delete
//dotnet ef database drop

