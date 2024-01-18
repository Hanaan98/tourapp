using Core.Models.Request;
using Core.Models.Response;

namespace Core.Interfaces.DL
{
    public interface IPlaceDL
    {
        public Task<PlaceResponseDto> SavePlace(PlaceRequestDto place);
        public Task<PlaceResponseDto> UpdatePlace(Guid placeId, PlaceRequestDto place);
        public Task<PlaceResponseDto> GetPlace(Guid placeId);
        public Task<IEnumerable<PlaceResponseDto>> GetAllPlaces();

        public Task DeletePlace(Guid placeId);
    }
}