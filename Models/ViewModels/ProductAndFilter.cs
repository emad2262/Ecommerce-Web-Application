namespace Ecommerce_Web_Application.Models.ViewModels
{
    public class ProductAndFilter
    {
        public IEnumerable<Product>? Products { get; set; }
        public FilterWithVm? filterWithVm { get; set; }
        public List<Category> categories  { get; set; }
        public double totalpagenumper { get; set; }
    }
}
