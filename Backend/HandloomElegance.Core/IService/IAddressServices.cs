using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Entities;
namespace HandloomElegance.Core.IServices{

    public interface IAddressServices{
        public Task<bool> AddAddress(AddAddressViewModel Address);
        
    }


}