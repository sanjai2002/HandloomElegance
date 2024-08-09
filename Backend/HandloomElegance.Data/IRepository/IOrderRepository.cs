using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Data.IRepository{

    public interface IOrderRepository{

        public Task Addorder(Order order);
        public Order Findorder(Guid OrderId);

        public Product FindProduct(Guid ProductId);

        public Task QuantityUpdate(Product product);

        public Task AddorderItems(OrderItem orderItem);

    }


}