using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Core.IServices{
    public interface IReviewServices{
        public Task<bool> AddReview(AddReviewViewModel AddReview);

    }
}