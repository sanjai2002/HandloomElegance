using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Data.IRepository{
    public interface ICartRepository{
        public Task AddCart(ShoppingCart shoppingCart);
        public ShoppingCart FindCartId(Guid CartId);
        public Task RemoveCart(ShoppingCart shoppingCart);

        public Task UpdateCart(ShoppingCart shoopingcart);

        public Product Findproduct(Guid ProductId);



    }

}