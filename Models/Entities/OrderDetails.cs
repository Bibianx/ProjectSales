using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    [Index(nameof(OrderId), nameof(ProductId), IsUnique = true)]
    public class OrderDetails
    {
        public Guid OrderDetailId { get; set; } = Guid.NewGuid();
        public string Quantity { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}