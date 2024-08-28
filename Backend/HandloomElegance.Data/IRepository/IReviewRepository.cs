using HandloomElegance.Common.Entities;

namespace HandloomElegance.Data.IRepository{
public interface IReviewRepository{
    public Task AddReview(Review review);

    public User? FindUser(Guid userId);

    public Product? FindProduct(Guid productId);



    }
}