using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using System.Collections;

namespace HandloomElegance.Api.Controllers{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController:ControllerBase{
        private readonly ICartServices _ICartServices;
        public CartController(ICartServices ICartServices){
           _ICartServices= ICartServices;
        }

        [HttpPost]
        public async Task<IActionResult>AddtoCart(ShooppingCartViewModel cart){
            bool Shoopingcart=await _ICartServices.AddCart(cart);
            if(Shoopingcart){
                return Ok("Cart Added");
            }
            return Ok("Cart Not Added");
        }

        [HttpDelete]
        public async Task<IActionResult>RemoveCart(Guid cartId){
            bool cart=await _ICartServices.RemoveCart(cartId);
            if(cart)return Ok("Cart Removed");
            return Ok("Cart Not Removed");
        }
        

    }
}