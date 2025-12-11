namespace Models.Entities
{
    public class Categories
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}