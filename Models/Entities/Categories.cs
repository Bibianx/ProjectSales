using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Categories
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}