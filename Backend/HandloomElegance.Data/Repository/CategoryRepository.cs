using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;
namespace HandloomElegance.Data.Repository
{
    public class CategoryRepository : ICategoryrepoitory
    {
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public CategoryRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;

        }

        public bool FindCategoybyname(string CategoryName)
        {
            return _HandloomEleganceDbContext.Categories.Any(e => e.CategoryName == CategoryName);
        }

        public async Task AddCategory(Category category)
        {
            await _HandloomEleganceDbContext.AddAsync(category);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public IEnumerable<CategoryListViewModel> GetAllCategory()
        {
            return _HandloomEleganceDbContext.Categories.Select(i => new CategoryListViewModel
            {
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryName,
                Description = i.Description
            }
            ).ToList();
        }

        public Category FindCactegorybyid(Guid CategoryId)
        {
            return _HandloomEleganceDbContext.Categories.Find(CategoryId);
        }

        public async Task UpdateCategory(Category category)
        {
            _HandloomEleganceDbContext.Categories.Update(category);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            _HandloomEleganceDbContext.Categories.Remove(category);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

    }

}