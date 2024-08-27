using Microsoft.AspNetCore.Http;

namespace HandloomElegance.Common.ViewModels
{
    public class UpdateProductViewModel
    {
        public Guid ProductId { get; set; }
        public string? Productname { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid? CategoryId { get; set; }
        public IFormFile? Image { get; set; }

    }

}