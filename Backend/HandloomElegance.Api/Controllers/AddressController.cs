using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using System.Collections;
namespace HandloomElegance.Api.Controllers{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController:ControllerBase{
        private readonly IAddressServices _IAddressServices;
        public AddressController(IAddressServices IAddressServices){
           _IAddressServices= IAddressServices;
        }
        
    }
    
    }