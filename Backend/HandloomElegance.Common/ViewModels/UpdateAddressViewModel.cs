namespace HandloomElegance.Common.ViewModels
{
    public class UpdateAddressViewModel
    {

        public Guid AddressId { get; set; }
        public string StreetAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;
    }
}