using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    public class Suppliers
    {
        public Guid SupplierId { get; set; } = Guid.NewGuid();
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}