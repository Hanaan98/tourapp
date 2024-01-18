using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.DL
{
    public interface IReviewDL
    {
        public Task<ReviewResponseDto> GetReview(Guid Id);
        public Task DeleteReview(Guid Id);
        public Task<IEnumerable<ReviewResponseDto>> GetAllReviews(Guid? _placeId, Guid? _userId);
        public Task<ReviewResponseDto> CreateReview(ReviewRequestDto review);
    }
}
