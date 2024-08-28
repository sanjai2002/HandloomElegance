using HandloomElegance.Common.Entities;
using HandloomElegance.Data.IRepository;

namespace HandloomElegance.Data.Repository{
    public class ReviewRepository:IReviewRepository{
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public ReviewRepository(HandloomEleganceDbContext HandloomEleganceDbContext){
            _HandloomEleganceDbContext=HandloomEleganceDbContext;

        }
        public async Task AddReview(Review review){
            await _HandloomEleganceDbContext.Reviews.AddAsync(review);
            await SaveChanges();
        }

        public async Task SaveChanges(){
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public User? FindUser(Guid userId){
            return _HandloomEleganceDbContext.Users.Find(userId);
        }
        public Product? FindProduct(Guid productId){
            return _HandloomEleganceDbContext.Products.Find(productId);
        }


    }
}