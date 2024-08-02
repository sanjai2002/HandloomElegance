using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _IProductServices;

        public ProductController(IProductServices IProductServices){
           _IProductServices= IProductServices;

        }
        [HttpPost]
       public async Task<IActionResult> AddProducts(AddProductViewModel Products)
        {
            bool AddProducts = await _IProductServices.AddProducts(Products);
            if (AddProducts)
            {
                return Ok("Product Added");
            }
            else
            {
                return Ok("Product Already Exits");
            }

        }

    }

}