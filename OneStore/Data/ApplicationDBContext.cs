using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneStore.Models;

namespace OneStore.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Adimn",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
