using HandloomElegance.Common.Entities;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public ReviewRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;
        }
        public async Task AddReview(Review review)
        {
            await _HandloomEleganceDbContext.Reviews.AddAsync(review);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public User? FindUser(Guid userId)
        {
            return _HandloomEleganceDbContext.Users.Find(userId);
        }
        public Product? FindProduct(Guid productId)
        {
            return _HandloomEleganceDbContext.Products.Find(productId);
        }

        public double CalculateRatingByProductId(Guid productId)
        {

            double averageRating = _HandloomEleganceDbContext.Reviews
                        .Where(r => r.ProductId == productId)
                        .Average(r => r.Rating);
            return Math.Round(averageRating, 1);
        }


         public IEnumerable<ProductRatingViewModel> GetAllProductReviews()
        {
             return  _HandloomEleganceDbContext.Reviews
                .GroupBy(p => p.ProductId)
                .Select(g=>new  ProductRatingViewModel
                {
                    productId = g.First().Product!.ProductId,
                    rating = Math.Round(g.Average(r => r.Rating), 1)
                })
                .ToList();

        }
    }
}