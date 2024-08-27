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

        public async Task SoftDelete(ShoppingCart shoppingCart)
        {
            _HandloomEleganceDbContext.ShoppingCarts.Update(shoppingCart);
            await SaveChanges();

        }

        public async Task UpdateCart(ShoppingCart shoopingcart){
            _HandloomEleganceDbContext.ShoppingCarts.Update(shoopingcart);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public Product?  Findproduct(Guid ProductId){

            return _HandloomEleganceDbContext.Products.Find(ProductId);
        }

         public IEnumerable<UserCartListViewModel>GetUserCartList(Guid userId){
            return _HandloomEleganceDbContext.ShoppingCarts.Where(e=>e.UserId==userId && e.IsActive==true)
            .Select(i=>new UserCartListViewModel{
                CartId=i.CartId,
                ProductId=i.ProductId,
                Productname=i.Product!.Productname,
                ImageUrl=i.Product!.ImageUrl,
                CategoryName=i.Product!.Category!.CategoryName,
                Price=i.Product.Price,
                Quantity=i.Quantity
            }

            ).ToList();
         }
    


        




    }
}