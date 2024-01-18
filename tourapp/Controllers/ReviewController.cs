using Core.Interfaces.BL;
using Core.Models.Request;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace tourapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        public IReviewBL reviewService;
        public ReviewController(IReviewBL reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ReviewRequestDto review)
        {
            try
            {
                var _review =await reviewService.CreateReview(review);
                return Ok(_review);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("")]
        public async Task<IActionResult> GetReviews(Guid? _placeId, Guid? _userId)
        {
            try
            {
                var reviews =await reviewService.GetAllReviews(_placeId, _userId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReview(Guid Id)
        {
            try
            {
                var review =await reviewService.GetReview(Id);
                return Ok(review);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReview(Guid Id)
        {
            try
            {
                var review =await reviewService.GetReview(Id);
                return Ok("Review deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
