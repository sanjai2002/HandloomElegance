using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.Repository;

namespace HandloomElegance.Data.IRepository{
    public interface ICartRepository{
        public Task AddCart(ShoppingCart ShooppingCart);



    }

}