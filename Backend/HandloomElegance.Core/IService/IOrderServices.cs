using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using HandloomElegance.Common.Entities;

namespace HandloomElegance.Core.IServices{
    public interface IOrderServices{

        public Task<bool>Order(OrderViewModel order);

    }
}