using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Shippers
    {
        [Key]
        public Guid ShipperId { get; set; } = Guid.NewGuid();
        public string ShipperName { get; set; }
        public string Phone { get; set; }
    }
    
}