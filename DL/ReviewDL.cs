using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ReviewDL : IReviewDL
    {
        ApplicationDbContext _db;
        public ReviewDL(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<ReviewResponseDto> GetReview(Guid Id)
        {
            ReviewDbDto review = await _db.Reviews.FindAsync(Id);
            if (review == null)
            {
                throw new Exception("Review not found");
            }
            return (ReviewResponseMapper.toReviewResponse(review));
        }
        public async Task DeleteReview(Guid Id)
        {
            ReviewDbDto review = await _db.Reviews.FindAsync(Id);
            if (review == null)
            {
                throw new Exception("Review not found");
            }
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<ReviewResponseDto>> GetAllReviews(Guid? _placeId, Guid? _userId)
        {
            IQueryable<ReviewDbDto> _reviews = _db.Reviews.Include(b => b.Place).Include(b => b.User);

            if (_placeId != null)
            {
                PlaceDbDto place = _db.Places.Find(_placeId);
                if (place == null)
                {
                    throw new Exception("Place not found");
                }
                _reviews = _reviews.Where(r => r.PlaceId == _placeId.Value);
            }

            if (_userId != null)
            {
                UserDbDto user = _db.Users.Find(_userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                _reviews = _reviews.Where(r => r.UserId == _userId.Value);
            }
            var reviews = await _reviews.ToListAsync();
            return (reviews.Select(r => ReviewResponseMapper.toReviewResponse(r)));

        }

        public async Task<ReviewResponseDto> CreateReview(ReviewRequestDto review)
        {
            PlaceDbDto place = _db.Places.Find(review.PlaceId);
            UserDbDto user = _db.Users.Find(review.UserId);
            if (place == null)
            {
                throw new Exception("Invalid Place Id");
            }
            if (user == null)
            {
                throw new Exception("Invalid User Id");
            }
            ReviewDbDto _review = new ReviewDbDto()
            {
                Id = new Guid(),
                PlaceId = review.PlaceId,
                Comment = review.Comment,
                CreatedAt = DateTime.UtcNow,
                UserId = review.UserId,
                Rating = review.Rating,
            };
            _db.Reviews.Add(_review);
            await _db.SaveChangesAsync();
            return (ReviewResponseMapper.toReviewResponse(_review));
        }
    }
}