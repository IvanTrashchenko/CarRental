using CarRentalWebApplication.Configuration;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RequestInfo> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new RequestInfoConfig());

            /*modelBuilder.Entity<Item>().HasData(
                new Item[]
                    {
                        new Item { Id = 1, Description = "56'' Blue Freen", Price = 3.5m },
                        new Item { Id = 2, Description = "Spline End (Xtra Large)", Price = 0.25m },
                        new Item { Id = 3, Description = "3'' Red Freen", Price = 12m }
                    });*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
