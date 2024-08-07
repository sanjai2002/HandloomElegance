namespace HandloomElegance.Common.ViewModels
{

    public class AddProductViewModel
    {
        public string? Productname { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Image { get; set; }

    }
}