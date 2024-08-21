using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;

namespace HandloomElegance.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public readonly HandloomEleganceDbContext _HandloomEleganceDbContext;

        public OrderRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;

        }

        public async Task Addorder(Order order)
        {
            await _HandloomEleganceDbContext.Orders.AddAsync(order);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }



        public Order Findorder(Guid OrderId)
        {
            return _HandloomEleganceDbContext.Orders.Find(OrderId);
        }

        public Product FindProduct(Guid productid)
        {
            return _HandloomEleganceDbContext.Products.Find(productid);
        }

        public async Task QuantityUpdate(Product product)
        {
            _HandloomEleganceDbContext.Products.Update(product);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public async Task AddorderItems(OrderItem orderItem)
        {
            await _HandloomEleganceDbContext.OrderItems.AddAsync(orderItem);
            await _HandloomEleganceDbContext.SaveChangesAsync();

        }
        public List<Address>GetUserAddress(Guid userId){
            return _HandloomEleganceDbContext.Addresses.Where(e=>e.UserId==userId).ToList();
        }
        public List<ShoppingCart> GetUserCart(Guid userId)
        {
            return _HandloomEleganceDbContext.ShoppingCarts.Where(e => e.UserId == userId).ToList();
        }


    }
}