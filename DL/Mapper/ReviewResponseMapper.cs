using Core.Models.Response;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mapper
{
    public class ReviewResponseMapper
    {
        public static ReviewResponseDto toReviewResponse(ReviewDbDto review)
        {
            return new ReviewResponseDto
            {
                Id = review.Id,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                PlaceId = review.PlaceId,
                Rating = review.Rating,
                UserId = review.UserId,
                User = MapUser(review.User),
                Place = MapPlace(review.Place),
            };
        }
        private static AuthResponseDto MapUser(UserDbDto user)
        {
            if (user == null)
            {
                return null;
            }

            return AuthResponseMapper.toAuthResponse(user);
        }
        private static PlaceResponseDto MapPlace(PlaceDbDto place)
        {
            if (place == null)
            {
                return null;
            }

            return PlaceMapper.toPlaceResponse(place);
        }
    }
}
