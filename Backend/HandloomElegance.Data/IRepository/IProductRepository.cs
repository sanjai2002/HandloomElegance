using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Data.IRepository{
    public interface IProductRepository{
        public bool FindproductByName(string ProductName);
        public Task AddProducts(Product product);

        public IEnumerable<ProductListViewModel>GetAllproducts();

        public Product GetProductDetailsByProductId(Guid productid);

        public Product FindProductByid(Guid productId);
        public Task Updateproduct(Product product);

        public Task DeleteProduct(Product product);


    }


}