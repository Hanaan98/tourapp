using Core.Models.Response;
using DL.DbModels;

namespace DL.Mapper
{
    public class PlaceMapper
    {
        public static PlaceResponseDto toPlaceResponse(PlaceDbDto place)
        {
            return new PlaceResponseDto
            {
                Id = place.Id,
                Location = place.Location,
                Description = place.Description,
                Image = place.Image,
                Price = place.Price,
                Details = place.Details,
                Departure = place.Departure,
                Days = place.Days
            };
        }
    }
}