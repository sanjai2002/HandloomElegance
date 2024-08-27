namespace HandloomElegance.Common.ViewModels{
public class AddAddressViewModel{
    public Guid? UserId { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

}

}