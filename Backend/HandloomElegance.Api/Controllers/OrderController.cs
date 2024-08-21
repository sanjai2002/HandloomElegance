using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;

using System.Collections;

namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       public readonly IOrderServices _IOrderServices;
       public OrderController(IOrderServices IOrderServices){
        _IOrderServices=IOrderServices;
       }

       [HttpPost]
       public async Task<IActionResult>Ordercontroller(OrderViewModel OrderViewModel){
        bool order=await _IOrderServices.Order(OrderViewModel);
        if(order){
            return Ok("Order Conformed");
        }
        return Ok("Not Ordered");
       }
       [HttpPost]
       public async Task<IActionResult>Cartorder(Guid userid){
        bool order=await _IOrderServices.CartOrder(userid);
        if(order){
            return Ok("Order Conformed");
        }
        return Ok("Not Ordered");

       }



    }
    
    }