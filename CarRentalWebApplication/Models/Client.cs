using System.Collections.Generic;

namespace CarRentalWebApplication.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientSurname { get; set; }

        public string IdentificationNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
