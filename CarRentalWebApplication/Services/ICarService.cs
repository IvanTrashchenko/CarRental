using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalWebApplication.Models;

namespace CarRentalWebApplication.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetItemsAsync();
        Task<Car> GetItemAsync(int id);
        Task DeleteItemAsync(int id);
        Task<Car> UpdateItemAsync(int id, UpdateCarRequest updateRequest);
        Task<Car> CreateItemAsync(UpdateCarRequest updateRequest);
    }
}
