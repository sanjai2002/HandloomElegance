using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;

namespace HandloomElegance.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public CartRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;
        }


        public async Task AddCart(ShoppingCart ShooppingCart)
        {
            await _HandloomEleganceDbContext.AddAsync(ShooppingCart);
            await SaveChanges();
        }

      
        public ShoppingCart FindCartId(Guid CartId)
        {
            return _HandloomEleganceDbContext.ShoppingCarts.Find(CartId);
        }

        public async Task RemoveCart(ShoppingCart shoppingCart)
        {
            _HandloomEleganceDbContext.Remove(shoppingCart);
            await SaveChanges();

        }

        public async Task SaveChanges()
        {
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }
        




    }
}