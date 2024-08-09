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
        









    }
}