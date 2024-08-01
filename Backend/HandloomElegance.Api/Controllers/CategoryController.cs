using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using System.Collections;

namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Categorycontroller : ControllerBase
    {
        private readonly ICategoryServices _ICategoryServices;

        public Categorycontroller(ICategoryServices ICategoryServices)
        {
            _ICategoryServices = ICategoryServices;
        }

        [HttpPost]
        public async Task<IActionResult> Addcategory(CategoryViewModel category)
        {
            bool Category = await _ICategoryServices.AddCategory(category);
            if (Category)
            {
                return Ok("Category Added");
            }
            else
            {
                return Ok("Category Not Added");
            }

        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var category = _ICategoryServices.GetAllcategory();
            return Ok(category);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryListViewModel Category){
            bool Categories=await _ICategoryServices.UpdateCategory(Category);
            if(Categories){
                return Ok("Update successfully");
            }
            return Ok("Not Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid CategoryId){
            bool Categories=await _ICategoryServices.DeleteCategory(CategoryId);
            if(Categories==true){
                return Ok("Deleted Successfully");
            }
            return Ok("Not Deleted");
        }






    }

}