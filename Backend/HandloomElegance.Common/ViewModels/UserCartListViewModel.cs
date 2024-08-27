namespace HandloomElegance.Common.ViewModels
{
    public class UserCartListViewModel
    {
        public Guid CartId { get; set; }
        public Guid? ProductId { get; set; }
        public string Productname { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        

    }

}