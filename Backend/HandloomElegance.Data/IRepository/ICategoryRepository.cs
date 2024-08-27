using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Data.IRepository{
    public interface ICategoryrepoitory{
      public bool FindCategoybyname(string CategoryName);
      public Task AddCategory(Category category);
      public IEnumerable<CategoryListViewModel>GetAllCategory();
      public Category FindCactegorybyid(Guid CategoryId);
      public Task UpdateCategory(Category category);
      public Task SoftDeleteCategory(Category category);

    }

}