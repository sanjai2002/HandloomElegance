using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
namespace HandloomElegance.Core.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _ICartRepository;

        public CartServices(ICartRepository ICartRepository)
        {
            _ICartRepository = ICartRepository;

        }

        public async Task<bool> AddCart(ShooppingCartViewModel Cart)
        {
            var product = _ICartRepository.Findproduct(Guid.Parse(Cart.ProductId.ToString()));
            if (Cart.Quantity < product.StockQuantity)
            {
                ShoppingCart ShoppingCart = new ShoppingCart()
                {
                    CartId = Guid.NewGuid(),
                    UserId = Cart.UserId,
                    ProductId = Cart.ProductId,
                    Quantity = Cart.Quantity,
                    IsActive=true,
                    CreatedAt=DateTime.Now,
                };
                await _ICartRepository.AddCart(ShoppingCart);
                return true;

            }
            return false;

        }


        public async Task<bool> RemoveCart(Guid CartId)
        {
            var cart = _ICartRepository.FindCartId(CartId);
            if (cart != null)
            {
                cart.IsActive=false;
                await _ICartRepository.SoftDelete(cart);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCart(UpdateCartViewModel updateCart)
        {
            var UserCart = _ICartRepository.FindCartId(updateCart.CartId);
            if (UserCart != null)
            {
                UserCart.Quantity = updateCart.Quantity;
                await _ICartRepository.UpdateCart(UserCart);
                return true;
            }
            return false;
        }

         public IEnumerable<UserCartListViewModel>GetUserCartListByUserId(Guid userId){
            return _ICartRepository.GetUserCartList(userId);
         }
    }

}