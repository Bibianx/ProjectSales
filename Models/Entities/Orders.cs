using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    [Index(nameof(OrderDate), nameof(CustomerId), nameof(EmployeeId), nameof(ShipperId))]
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();
        
        public DateOnly OrderDate { get; set; }

        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers Customers { get; set; }

        public Guid EmployeeId { get; set; }
        
        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }
       
        public Guid ShipperId { get; set; }
        
        [ForeignKey("ShipperId")]
        public Shippers Shippers { get; set; }

    }
}