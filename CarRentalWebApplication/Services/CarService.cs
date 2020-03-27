using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalWebApplication.Services
{
    using CarRentalWebApplication.Mappers;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} cannot be null.");
        }

        public async Task<Car> CreateItemAsync(UpdateCarRequest updateRequest)
        {
            var res = updateRequest.Map();

            await this.context.Cars.AddAsync(res);

            await this.context.SaveChangesAsync();

            return res;
        }

        public async Task DeleteItemAsync(int id)
        {
            var res = await this.context.Cars.SingleOrDefaultAsync(item => item.CarId == id);

            if (res == null)
            {
                throw new CarNotFoundException($"{id} not found.");
            }

            this.context.Cars.Remove(res);

            await this.context.SaveChangesAsync();
        }

        public async Task<Car> GetItemAsync(int id)
        {
            var res = await this.context.Cars.SingleOrDefaultAsync(item => item.CarId == id);

            if (res == null)
            {
                throw new CarNotFoundException($"{id} not found.");
            }

            return res;
        }

        public async Task<IEnumerable<Car>> GetItemsAsync()
        {
            var items = await this.context.Cars.OrderBy(item => item.CarId).ToListAsync();

            return items;
        }

        public async Task<Car> UpdateItemAsync(int id, UpdateCarRequest updateRequest)
        {
            var res = await this.context.Cars.SingleOrDefaultAsync(item => item.CarId == id);

            if (res == null)
            {
                throw new CarNotFoundException($"{id} not found.");
            }

            res = updateRequest.Map();

            await this.context.SaveChangesAsync();

            return res;
        }
    }
}