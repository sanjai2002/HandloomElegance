using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;

namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Categorycontroller:ControllerBase{
        private readonly ICategoryServices _ICategoryServices;

        public Categorycontroller(ICategoryServices ICategoryServices){
            _ICategoryServices=ICategoryServices;

        }
        [HttpPost]
        public async Task<IActionResult>Addcategory(CategoryViewModel category){
            bool Category=await _ICategoryServices.AddCategory(category);
            if(Category){
                return Ok("Category Added");
            }
            else{
                return Ok("Category Not Added");
            }

        }
        





    }

}