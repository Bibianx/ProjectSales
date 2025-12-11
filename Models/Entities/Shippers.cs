namespace Models
{
    public class Shippers
    {
        public Guid ShipperId { get; set; } = Guid.NewGuid();
        public string ShipperName { get; set; }
        public string Phone { get; set; }
    }
    
}