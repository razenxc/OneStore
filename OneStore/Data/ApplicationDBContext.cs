using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneStore.Model;

namespace OneStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions o, IConfiguration config) : base(o) 
        {
            _config = config;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JwtRefreshToken> JwtRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============
            // Admin Account
            User adminAccount = new User
            {
                Id = 1,
                Username = _config["ApiSettings:AdminUsername"],
                Role = "ADMIN"
            };

            adminAccount.PasswordHash = new PasswordHasher<User>().HashPassword(adminAccount, _config["ApiSettings:AdminPassword"]);

            modelBuilder.Entity<User>()
                .HasData(adminAccount);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
