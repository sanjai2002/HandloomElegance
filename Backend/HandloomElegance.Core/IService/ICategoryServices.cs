using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using HandloomElegance.Common.Entities;

namespace HandloomElegance.Core.IServices{
    public interface ICategoryServices{

        public Task<bool>AddCategory(CategoryViewModel category);

        public IEnumerable<CategoryListViewModel>GetAllcategory();

        public Task<bool>UpdateCategory(CategoryListViewModel category);

        public Task<bool>DeleteCategory(Guid CategoryId);


    }


}