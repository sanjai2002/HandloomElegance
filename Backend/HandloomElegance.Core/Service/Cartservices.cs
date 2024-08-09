using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
namespace HandloomElegance.Core.Services
{
    public  class CartServices:ICartServices{
        private readonly ICartRepository _ICartRepository;
        
        public CartServices(ICartRepository ICartRepository){
            _ICartRepository=ICartRepository;

        }
        
    


    }

}