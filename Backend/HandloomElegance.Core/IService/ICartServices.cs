using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using HandloomElegance.Common.Entities;

namespace HandloomElegance.Core.IServices{
    public interface ICartServices{
        public Task<bool>AddCart(ShooppingCartViewModel ShooppingCart);

    

    }
}