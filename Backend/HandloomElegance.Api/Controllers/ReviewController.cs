using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _IReviewServices;

        public ReviewController(IReviewServices IReviewServices)
        {
            _IReviewServices = IReviewServices;
        }
        [HttpPost]
        public async Task<IActionResult>PostReview(AddReviewViewModel AddReview){
            bool Review=await _IReviewServices.AddReview(AddReview);
            if(Review) return Ok("Review Submitted");
            return Ok("Review Not Submitted");
           
        }




    }
}