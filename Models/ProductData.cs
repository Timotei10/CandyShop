namespace CandyShop.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductCategory> BookCategories { get; set; }
    }
}
