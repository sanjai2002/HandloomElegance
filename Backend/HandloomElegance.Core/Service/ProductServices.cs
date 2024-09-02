using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;
using HandloomElegance.Data.Repository;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;



namespace HandloomElegance.Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _IProductRepository;
        private readonly IReviewRepository _IReviewRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProductServices(IProductRepository IProductRepository, IReviewRepository IReviewRepository, IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor)
        {
            _IProductRepository = IProductRepository;
            _IReviewRepository = IReviewRepository;
            _environment = environment;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<bool> AddProducts(AddProductViewModel AddProducts)
        {
            bool ExistingProduct = _IProductRepository.FindproductByName(AddProducts!.Productname!);
            if (!ExistingProduct)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{AddProducts.Image.FileName}";
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "Products");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AddProducts.Image.CopyTo(stream);
                }
                Product ob = new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Productname = AddProducts!.Productname!,
                    Description = AddProducts.Description,
                    Price = AddProducts.Price,
                    StockQuantity = AddProducts.StockQuantity,
                    CategoryId = AddProducts.CategoryId,
                    ImageUrl = uniqueFileName,
                    CreatedAt = DateTime.Now,
                    IsActive = false,
                };
                await _IProductRepository.AddProducts(ob);
                return true;
            }
            return false;
        }

        public IEnumerable<ProductListViewModel> GetAllProducts()
        {

            var products = _IProductRepository.GetAllproducts();
             var productrating=_IReviewRepository.GetAllProductReviews().ToDictionary(c=>c.productId);
            foreach (var product in products)
            {
                product.rating = productrating.ContainsKey(product.ProductId)?productrating[product.ProductId].rating:0;
            }

            return products;
        }

        public async Task<ProductListDetailsViewModel> GetProductDetailsByProductId(string ProductId)
        {
            var product = _IProductRepository.GetProductDetailsByProductId(Guid.Parse(ProductId));

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            ProductListDetailsViewModel ProductList = new ProductListDetailsViewModel()
            {
                ProductId = product.ProductId,
                Productname = product.Productname,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryName = product!.Category!.CategoryName,
                Image = String.Format(
                        "{0}://{1}{2}/wwwroot/Products/{3}",
                        _contextAccessor.HttpContext.Request.Scheme,
                        _contextAccessor.HttpContext.Request.Host,
                        _contextAccessor.HttpContext.Request.PathBase,
                        product.ImageUrl),
                rating = _IReviewRepository.CalculateRatingByProductId(Guid.Parse(ProductId)),
            };

            return ProductList;
        }
        public async Task<bool> UpdateProduct(UpdateProductViewModel UpdateProducts)
        {
            var product = _IProductRepository.FindProductByid(UpdateProducts.ProductId);
            if (product != null)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{UpdateProducts!.Image!.FileName}";
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "Products");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UpdateProducts.Image.CopyTo(stream);
                }
                product.Productname = UpdateProducts!.Productname!;
                product.Description = UpdateProducts!.Description!;
                product.Price = UpdateProducts!.Price;
                product.StockQuantity = UpdateProducts!.StockQuantity;
                product.CategoryId = UpdateProducts!.CategoryId;
                product.ImageUrl = uniqueFileName;
                product.UpdatedAt = DateTime.Now;
                await _IProductRepository.Updateproduct(product);
                return true;
            }
            return false;
        }

        public async Task<bool> Deleteproduct(Guid ProductId)
        {
            var product = _IProductRepository.FindProductByid(ProductId);
            if (product != null)
            {
                product.IsActive = false;
                await _IProductRepository.DeleteProduct(product);
                return true;
            }
            return false;
        }


    }


}