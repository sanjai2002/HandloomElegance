using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
namespace HandloomElegance.Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryrepoitory _ICategoryrepoitory;
        public CategoryServices(ICategoryrepoitory ICategoryrepoitory)
        {
            _ICategoryrepoitory = ICategoryrepoitory;
        }
        public async Task<bool> AddCategory(CategoryViewModel category)
        {
            bool ExitingCategory= _ICategoryrepoitory.FindCategoybyname(category!.CategoryName!);
            if(ExitingCategory==false){
                Category ob = new Category()
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = category!.CategoryName!,
                Description = category!.Description

            };
            await _ICategoryrepoitory.AddCategory(ob);
            return true;

            }
            return false;

            
        }

        public IEnumerable<CategoryListViewModel> GetAllcategory()
        {
            return _ICategoryrepoitory.GetAllCategory();
        }

        public async Task<bool>UpdateCategory(CategoryListViewModel category)
        {
            var Category = _ICategoryrepoitory.FindCactegorybyid(category.CategoryId);
            if (Category != null)
            {
                Category.CategoryName = category.CategoryName;
                category.Description = category.Description;
                await _ICategoryrepoitory.UpdateCategory(Category);
                return true;
            }
            return false;
        }

        public async Task<bool>DeleteCategory(Guid CategoryId){
            var Category = _ICategoryrepoitory.FindCactegorybyid(CategoryId);
            if(Category!=null){
                await _ICategoryrepoitory.DeleteCategory(Category);
                return true;
            }
            return false;

        }


    }

}