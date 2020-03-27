using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWebApplication.Models
{
    public class Order
    {
        public int InvoiceNo { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public DateTime RentalStart { get; set; }

        public DateTime RentalEnd { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
