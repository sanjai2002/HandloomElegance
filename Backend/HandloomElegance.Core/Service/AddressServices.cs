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

        


    }

}