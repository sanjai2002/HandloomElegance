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

        public async Task<bool>AddCart(ShooppingCartViewModel Cart){
            ShoppingCart ShoppingCart=new ShoppingCart(){
                CartId=Guid.NewGuid(),
                UserId=Cart.UserId,
                ProductId=Cart.ProductId,
                Quantity=Cart.Quantity

            };
           await  _ICartRepository.AddCart(ShoppingCart);
           return true;

        }


    


    }

}