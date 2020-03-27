namespace CarRentalWebApplication.Models
{
    public class RequestInfo
    {
        public int RequestId { get; set; }

        public int InvoiceNo { get; set; }

        public virtual Order Order { get; set; }

        public bool IsApproved { get; set; }

        public string Comment { get; set; }

        public bool IsDamaged { get; set; }
    }
}
