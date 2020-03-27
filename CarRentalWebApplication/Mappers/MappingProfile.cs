using CarRentalWebApplication.Models;

namespace CarRentalWebApplication.Mappers
{
    public static class Mapper
    {
        public static Car Map (this UpdateCarRequest request)
        {
            return new Car
                       {
                           CarName = request.CarName, CarPrice = request.CarPrice, IsAvailable = request.IsAvailable
                       };
        }
    }
}