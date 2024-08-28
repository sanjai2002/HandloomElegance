namespace HandloomElegance.Common.ViewModels
{
    public class OrderViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid? UserId { get; set; }
        public Guid AddressId { get; set; }

    }

}