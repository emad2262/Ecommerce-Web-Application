namespace Ecommerce_Web_Application.Models.ViewModels
{
    public class FilterWithVm
    {
        public string? ProductName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int categoryId { get; set; }


    }
}
