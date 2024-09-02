using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Data.IRepository{
public interface IReviewRepository{
    public Task AddReview(Review review);
    public User? FindUser(Guid userId);
    public Product? FindProduct(Guid productId);
    public double CalculateRatingByProductId(Guid productId);

     public IEnumerable<ProductRatingViewModel> GetAllProductReviews();


    
    



    }
}