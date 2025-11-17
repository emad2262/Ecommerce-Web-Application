namespace Ecommerce_Web_Application.Models.ViewModels
{
    public class DetailsProduct
    {
        public Product Product { get; set; } = null!;
        public List<Product> Relatedproduct { get; set; } = null!;
        public List<Product>? Topvisited { get; set; }
        public List<Product>? CategoryProduct { get; set; }

    }
}
