using CarRentalWebApplication.Configuration;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApplication.Models
{
    using System;

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

            modelBuilder.Entity<Car>().HasData(
                new Car[]
                    {
                        new Car { CarId = 1, CarName = "Mazda", CarPrice = 200.00, IsAvailable = true },
                        new Car { CarId = 2, CarName = "Audi", CarPrice = 300.00, IsAvailable = true },
                        new Car { CarId = 3, CarName = "Lexus", CarPrice = 400.00, IsAvailable = false }
                    });

            modelBuilder.Entity<Client>().HasData(
                new Client[]
                    {
                        new Client {ClientId = 1, ClientName = "Ivan", ClientSurname = "Trashchanka", IdentificationNumber = "AAAAAAAAAAA3"},
                        new Client {ClientId = 2, ClientName = "Gleb", ClientSurname = "Loutov", IdentificationNumber = "AAAAAAAAAAA4"}
                    });

            modelBuilder.Entity<Order>().HasData(
                new Order[]
                    {
                        new Order {InvoiceNo = 1, CarId = 1, ClientId = 1, RentalStart = DateTime.Now, RentalEnd = new DateTime(2020, 11, 11)},
                        new Order {InvoiceNo = 2, CarId = 2, ClientId = 1, RentalStart = DateTime.Now, RentalEnd = new DateTime(2020, 11, 11)},
                        new Order {InvoiceNo = 3, CarId = 2, ClientId = 2, RentalStart = DateTime.Now, RentalEnd = new DateTime(2020, 11, 11)},
                    });

            modelBuilder.Entity<RequestInfo>().HasData(
                new RequestInfo[]
                    {
                        new RequestInfo {RequestId = 1, InvoiceNo = 1, IsApproved = true},
                        new RequestInfo {RequestId = 2, InvoiceNo = 2, IsApproved = true},
                        new RequestInfo {RequestId = 3, InvoiceNo = 3, IsApproved = false, Comment = "Bad client", IsDamaged = true}
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
