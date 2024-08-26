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
        
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProductServices(IProductRepository IProductRepository,IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor)
        {
            _IProductRepository = IProductRepository;
             _environment = environment;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<bool> AddProducts(AddProductViewModel AddProducts)
        {
            bool ExistingProduct = _IProductRepository.FindproductByName(AddProducts!.Productname!);
            if (!ExistingProduct)
            {
                Product ob = new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Productname = AddProducts!.Productname!,
                    Description = AddProducts.Description,
                    Price = AddProducts.Price,
                    StockQuantity = AddProducts.StockQuantity,
                    CategoryId = AddProducts.CategoryId,
                    // ImageUrl = byteArray, 
                };
                await _IProductRepository.AddProducts(ob);
                return true;
            }
            return false;
        }
        
        public IEnumerable<ProductListViewModel>GetAllProducts(){
            return _IProductRepository.GetAllproducts();
        }
      public async Task<ProductListDetailsViewModel>GetProductDetailsByProductId(string ProductId){
            var product =  _IProductRepository.GetProductDetailsByProductId(Guid.Parse(ProductId));
                ProductListDetailsViewModel ProductList=new ProductListDetailsViewModel(){
                    ProductId=product.ProductId,
                    Productname=product.Productname,
                    Description=product.Description,
                    Price=product.Price,
                    StockQuantity=product.StockQuantity,
                    CategoryName=product.Category?.CategoryName,
                    // Image=Encoding.ASCII.GetString(product!.ImageUrl!)
                };
                return ProductList;
      }

        public async Task<bool>UpdateProduct(UpdateProductViewModel UpdateProducts ){
            var product =_IProductRepository.FindProductByid(UpdateProducts.ProductId);
            if(product!=null){
                byte[] byteArray = Encoding.ASCII.GetBytes(UpdateProducts!.Image!);
                product.Productname=UpdateProducts!.Productname!;
                product.Description=UpdateProducts!.Description!;
                product.Price=UpdateProducts!.Price;
                product.StockQuantity=UpdateProducts!.StockQuantity;
                product.CategoryId=UpdateProducts!.CategoryId;
                // product.ImageUrl=byteArray;
                product.UpdatedAt=DateTime.Now;
                await _IProductRepository.Updateproduct(product);
                return true;
            }
            return false;
        }

        public async Task<bool>Deleteproduct(Guid ProductId){
             var product =_IProductRepository.FindProductByid(ProductId);
             if(product!=null){
                await _IProductRepository.DeleteProduct(product);
                return true;
             }
             return false;

        }


    }

    
}