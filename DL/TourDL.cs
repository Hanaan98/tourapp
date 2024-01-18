using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class TourDL : ITourDL
    {
        ApplicationDbContext _db;
        public TourDL(ApplicationDbContext _context)
        {
            this._db = _context;
        }
        public async Task<TourResponseDto> SaveTour(TourRequestDto tour)
        {
            PlaceDbDto place = await _db.Places.FindAsync(tour.PlaceId);
            if (place == null)
            {
                throw new Exception("Place not found");
            }
            TourDbDto newTour = new TourDbDto()
            {
                Id = Guid.NewGuid(),
                PlaceId = tour.PlaceId,
                StartDate = tour.StartDate,
                TotalSeats = tour.TotalSeats,
                RemainingSeats = tour.RemainingSeats,
            };

            _db.Tours.Add(newTour);
            await _db.SaveChangesAsync();

            return TourResponseMapper.toTourResponse(newTour);
        }
        public async Task<TourResponseDto> UpdateTour(Guid tourId, TourRequestDto _tour)
        {
            TourDbDto tour = await _db.Tours.FindAsync(tourId);
            if (tour == null)
            {
                throw new Exception("Tour not found");
            }
            tour.StartDate = _tour.StartDate != default ? _tour.StartDate : tour.StartDate;
            tour.TotalSeats = _tour.TotalSeats != default ? _tour.TotalSeats : tour.TotalSeats;
            tour.RemainingSeats = _tour.RemainingSeats != default ? _tour.RemainingSeats : tour.RemainingSeats;

            await _db.SaveChangesAsync();
            return TourResponseMapper.toTourResponse(tour);

        }
        public async Task<TourResponseDto> GetTour(Guid tourId)
        {
            TourDbDto tour = await _db.Tours.Include(t => t.Place).SingleOrDefaultAsync(t => t.Id == tourId);
            if (tour == null)
            {
                throw new Exception("Tour not found");
            }
            return TourResponseMapper.toTourResponse(tour);
        }
        public async Task<IEnumerable<TourResponseDto>> GetAllTours(Guid? PlaceId)
        {
            if (PlaceId == null)
            {
                return await _db.Tours
                    .Include(t => t.Place) 
                    .Select(_tour => TourResponseMapper.toTourResponse(_tour))
                    .ToListAsync();
            }

            List<TourResponseDto> _tours = await _db.Tours
                .Where(tour => tour.PlaceId == PlaceId)
                .Include(t => t.Place)
                .Select(_tour => TourResponseMapper.toTourResponse(_tour))
                .ToListAsync();

            return _tours;
        }
        public async Task DeleteTour(Guid tourId)
        {
            TourDbDto tour = await _db.Tours.FirstOrDefaultAsync(t => t.Id == tourId);

            if (tour == null)
            {
                throw new Exception("Tour not found");
            }
            else
            {
                _db.Tours.Remove(tour);
                await _db.SaveChangesAsync();
            }
            
        }
    }
}
