using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mapper
{
    public class TourResponseMapper
    {
        public static TourResponseDto toTourResponse(TourDbDto tour)
        {
            return new TourResponseDto
            {
                Id = tour.Id,
                PlaceId = tour.PlaceId,
                StartDate = tour.StartDate,
                TotalSeats = tour.TotalSeats,
                RemainingSeats = tour.RemainingSeats,
                Place = MapPlace(tour.Place),
            };

            
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
