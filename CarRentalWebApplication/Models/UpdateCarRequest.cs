namespace CarRentalWebApplication.Models
{
    public class UpdateCarRequest
    {
        public string CarName { get; set; }

        public double CarPrice { get; set; }

        public bool IsAvailable { get; set; }
    }
}
