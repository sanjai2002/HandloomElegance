using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Data.IRepository{

    public interface IAddressRepository{

        public Task AddAddress(Address address);

        public Task UpdateAddress(Address address);

    

        public Address? FindAddress(Guid AddressId);

        public Task SoftDeleteAddress(Address address);

       

    }
}