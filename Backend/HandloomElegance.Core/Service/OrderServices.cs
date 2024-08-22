using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;

namespace HandloomElegance.Core.Services
{
    public class OrderServices : IOrderServices
    {
        public readonly IOrderRepository _IOrderRepository;

        public OrderServices(IOrderRepository IOrderRepository)
        {
            _IOrderRepository = IOrderRepository;

        }

       public async Task<bool>Order(OrderViewModel order){          
            Order Ob=new Order(){
                OrderId=Guid.NewGuid(),
                UserId=order.UserId,
                OrderDate=DateTime.Now,
                Status="Pending",
                TotalAmount=order.TotalAmount,
                AddressId=order.AddressId,
            };
            await _IOrderRepository.Addorder(Ob);
            var OrderId=_IOrderRepository.Findorder(Ob.OrderId);
            for(int i=0;i<order.ProductId.Count;i++){
                var Product=_IOrderRepository.FindProduct(order.ProductId[i]);
                Product.StockQuantity=Product.StockQuantity-order.Quantity[i];
                await _IOrderRepository.QuantityUpdate(Product);
                OrderItem orderItem=new OrderItem(){
                    OrderItemId=Guid.NewGuid(),
                    OrderId=OrderId.OrderId,
                    ProductId=Product.ProductId,
                    Quantity=order.Quantity[i],
                    Price=Product.Price,
                };
                await _IOrderRepository.AddorderItems(orderItem);
            }
            return true;
        }

        public async Task<bool>CartOrder(Guid userId,Guid AddressId){
            var CartItems= _IOrderRepository.GetUserCart(userId);
            decimal TotalAmount =0;
            foreach(var cart in CartItems){
                Guid productId = Guid.Parse(cart.ProductId.ToString());
                var product = _IOrderRepository.FindProduct(productId);
                TotalAmount+=product.Price*cart.Quantity;
            }
            Order ob=new Order(){
                OrderId=Guid.NewGuid(),
                UserId=CartItems.First().UserId,
                OrderDate=DateTime.Now,
                Status="Pending",
                TotalAmount=TotalAmount,
                AddressId=AddressId,
            };

            await _IOrderRepository.Addorder(ob);
            var OrderId=_IOrderRepository.Findorder(ob.OrderId);
            foreach(var Cart in CartItems){
            Guid productId = Guid.Parse(Cart!.ProductId!.ToString());
            var product=_IOrderRepository.FindProduct(productId);
            product.StockQuantity=product.StockQuantity-Cart.Quantity;
            await _IOrderRepository.QuantityUpdate(product);
                OrderItem orderItem=new OrderItem(){
                    OrderItemId=Guid.NewGuid(),
                    OrderId=OrderId.OrderId,
                    ProductId=product.ProductId,
                    Quantity=Cart.Quantity,
                    Price=product.Price,
                };
                await _IOrderRepository.AddorderItems(orderItem);
                await _IOrderRepository.DeleteUserCart(Cart);
         }
         return true;

        } 

    }
}