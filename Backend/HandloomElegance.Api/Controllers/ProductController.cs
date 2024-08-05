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

    [HttpPut]
    public async Task<IActionResult>UpdateProducts(UpdateProductViewModel UpdateProducts){
        bool Updateproducts=await _IProductServices.UpdateProduct(UpdateProducts);
        if(Updateproducts){
            return Ok("Updated Succesfuly");

        }
        return Ok("Not Updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(Guid ProductId){
        bool DeleteProduct=await _IProductServices.Deleteproduct(ProductId);
        if(DeleteProduct){
            return Ok("Product Deleted");
        }
        return Ok("Product Not  Deleted");
    }




    }

}