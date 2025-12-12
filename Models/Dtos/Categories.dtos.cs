namespace Models.Dtos
{
    public class CategoriesResponse
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CategoriesRequest : CategoriesResponse;
}