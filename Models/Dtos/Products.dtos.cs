namespace Models.Dtos
{
    public class ProductsRequest
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public string Categorie { get; set; }
        public string Supplier { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
    }

    public class ProductsResponse : ProductsRequest;
}