using Core.Interfaces.BL;
using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReviewService : IReviewBL
    {
        public IReviewDL reviewDL;
        public ReviewService(IReviewDL reviewDL)
        {
            this.reviewDL = reviewDL;
        }
        public async Task<ReviewResponseDto> GetReview(Guid Id)
        {
            return await reviewDL.GetReview(Id);
        }
        public async Task DeleteReview(Guid Id)
        {
            await reviewDL.DeleteReview(Id);
        }
        public async Task<IEnumerable<ReviewResponseDto>> GetAllReviews(Guid? _placeId, Guid? _userId)
        {
            return await reviewDL.GetAllReviews(_placeId, _userId);
        }
        public async Task<ReviewResponseDto> CreateReview(ReviewRequestDto review)
        {
            return await reviewDL.CreateReview(review);
        }
    }
}