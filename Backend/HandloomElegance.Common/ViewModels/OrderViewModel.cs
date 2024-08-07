namespace HandloomElegance.Common.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderItemId { get; set; }
        public List<Guid> ProductId { get; set; }
        public List<int> Quantity { get; set; }
        public int TotalAmount { get; set; }
        public Guid? UserId { get; set; }
        public Guid AddressId { get; set; }

    }

}