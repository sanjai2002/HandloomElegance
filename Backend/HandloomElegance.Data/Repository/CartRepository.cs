using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;

namespace HandloomElegance.Data.Repository{
    public class CartRepository: ICartRepository{
         private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public CartRepository(HandloomEleganceDbContext HandloomEleganceDbContext){
            _HandloomEleganceDbContext=HandloomEleganceDbContext;
        }

        
        public async Task AddCart(ShoppingCart ShooppingCart){
            await _HandloomEleganceDbContext.AddAsync(ShooppingCart);
            await _HandloomEleganceDbContext.SaveChangesAsync();

        }

        


    }
}