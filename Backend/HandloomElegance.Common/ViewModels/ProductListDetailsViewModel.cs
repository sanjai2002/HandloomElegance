namespace HandloomElegance.Common.ViewModels
{
    public class ProductListDetailsViewModel{
        public Guid ProductId { get; set; }
        public string? Productname { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? CategoryName { get; set; }
        public string? Image { get; set; }
    }
}