using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Entities;
namespace HandloomElegance.Core.IServices{

    public interface IAddressServices{
         public Task<bool>AddAddress(AddAddressViewModel Address);

         public Task<bool>UpdateAddress(UpdateAddressViewModel address);

         public Task<bool>SoftDeleteAddress(Guid AddressId);

         public IEnumerable<UserAddressListViewmodel>GetUserAddressByUserId(Guid UserId);
        
    }


}