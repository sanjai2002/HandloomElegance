using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
namespace HandloomElegance.Core.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository _IAddressRepository;
        public AddressServices(IAddressRepository IAddressRepository)
        {
            _IAddressRepository = IAddressRepository;
        }

        public async Task<bool> AddAddress(AddAddressViewModel address)
        {

            Address userAddress = new Address()
            {
                AddressId = Guid.NewGuid(),
                UserId = address.UserId,
                StreetAddress = address.StreetAddress,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                IsActive = true,
                CreatedAt = DateTime.Now,
            };
            await _IAddressRepository.AddAddress(userAddress);
            return true;
        }

        public async Task<bool> UpdateAddress(UpdateAddressViewModel address)
        {
            var existingAddress = _IAddressRepository.FindAddress(address.AddressId);
            if (existingAddress != null)
            {
                existingAddress.StreetAddress = address.StreetAddress;
                existingAddress.City = address.City;
                existingAddress.State = address.State;
                existingAddress.PostalCode = address.PostalCode;
                existingAddress.Country = address.Country;
                existingAddress.ModifiedAt = DateTime.Now;
                await _IAddressRepository.UpdateAddress(existingAddress);
                return true;
            }
            return false;
        }

        public async Task<bool> SoftDeleteAddress(Guid AddressId)
        {
            var address = _IAddressRepository.FindAddress(AddressId);
            if(address!=null){
                address.IsActive=false;
                await _IAddressRepository.SoftDeleteAddress(address);
                return true;
            }
            return false;
        }

    }

}