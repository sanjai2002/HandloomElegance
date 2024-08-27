using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
namespace HandloomElegance.Core.Services
{
    public class AddressServices:IAddressServices{
        private readonly IAddressRepository _IAddressRepository;
        public AddressServices(IAddressRepository IAddressRepository){
            _IAddressRepository=IAddressRepository;
        }

        public async Task<bool>AddAddress(AddAddressViewModel address){
            
             Address userAddress=new Address(){
                AddressId=Guid.NewGuid(),
                UserId=address.UserId,
                StreetAddress=address.StreetAddress,
                City=address.City,
                State=address.State,
                PostalCode=address.PostalCode,
                Country=address.Country,
                IsActive=true,
                CreatedAt=DateTime.Now,
             };
        await _IAddressRepository.AddAddress(userAddress);
        return true;
        }


    }

}