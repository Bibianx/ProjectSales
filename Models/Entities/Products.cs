using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models.Entities
{
    [Index(nameof(CategoryId), nameof(SupplierId))]
    public class Products
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }

        public Guid SupplierId { get; set; }
        
        [ForeignKey("SupplierId")]
        public Suppliers Suppliers { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

    }
}