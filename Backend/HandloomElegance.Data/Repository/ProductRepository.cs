using System.Data.Entity;
using System.Text;
using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;
namespace HandloomElegance.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public ProductRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;
        }

        public bool FindproductByName(string ProductName)
        {
            return _HandloomEleganceDbContext.Products.Any(p => p.Productname == ProductName && p.IsActive == true);
        }

        public async Task AddProducts(Product product)
        {
            await _HandloomEleganceDbContext.AddAsync(product);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public IEnumerable<ProductListViewModel> GetAllproducts()
        {
            return _HandloomEleganceDbContext.Products.Where(e => e.IsActive == true)
            .OrderByDescending(cr => cr.CreatedAt).
            Select(e => new ProductListViewModel
            {
                ProductId = e.ProductId,
                Productname = e.Productname,
                Description = e.Description,
                Price = e.Price,
                StockQuantity = e.StockQuantity,
                CategoryName = e.Category!.CategoryName,
                // Image = Encoding.ASCII.GetString(e.ImageUrl!),
            }).ToList();
        }


        public Product? GetProductDetailsByProductId(Guid ProductId)
        {
            return _HandloomEleganceDbContext.Products
                .Include(c => c.Category)
                .FirstOrDefault(P => P.ProductId == ProductId);
        }

        public Product? FindProductByid(Guid ProductId)
        {
            return _HandloomEleganceDbContext.Products.Find(ProductId);
        }

        public async Task Updateproduct(Product product)
        {
            _HandloomEleganceDbContext.Update(product);
            await _HandloomEleganceDbContext.SaveChangesAsync();

        }

        public async Task DeleteProduct(Product product)
        {
            _HandloomEleganceDbContext.Update(product);
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

    }


}