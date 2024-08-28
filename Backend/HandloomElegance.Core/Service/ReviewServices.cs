using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Entities;
namespace HandloomElegance.Core.Services{
    public class Reviewservices:IReviewServices{
        private readonly IReviewRepository _IReviewRepository;

        public Reviewservices(IReviewRepository IReviewRepository){
            _IReviewRepository=IReviewRepository;

        }
        public async Task<bool>AddReview(AddReviewViewModel AddReview){
            bool Rating =AddReview.Rating<=5;
            var Product=_IReviewRepository.FindProduct(AddReview.ProductId);
            var User=_IReviewRepository.FindUser(AddReview.UserId);
            if(Product!=null && User!=null && Rating){
            Review review=new Review(){
                ReviewId=Guid.NewGuid(),
                ProductId=AddReview.ProductId,
                UserId=AddReview.UserId,
                Rating=AddReview.Rating,
                Comment=AddReview.Comment,
                CreatedAt=DateTime.Now,
            };
            await _IReviewRepository.AddReview(review);
            return true;
            }
            return false;
        }



    }
}