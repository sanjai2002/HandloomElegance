using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using HandloomElegance.Common.Entities;

namespace HandloomElegance.Core.IServices{

    public interface IProductServices{

         public Task<bool>AddProducts(AddProductViewModel AddProducts);   
         public IEnumerable<ProductListViewModel>GetAllProducts();

         public Task<ProductListDetailsViewModel>GetProductDetailsByProductId(string productid);
         public Task<bool>UpdateProduct(UpdateProductViewModel UpdateProducts);

         public Task <bool>Deleteproduct(Guid ProductId);

    }

}