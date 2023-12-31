using Core.Interfaces.BL;
using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;

namespace BL
{
    public class PlaceService : IPlaceBL
    {
        IPlaceDL placeDL;

        public PlaceService(IPlaceDL _dl) {
            placeDL = _dl;
        }
        public async Task<PlaceResponseDto> SavePlace(PlaceRequestDto place){

            return await placeDL.SavePlace(place);
        }
      
        public async Task<PlaceResponseDto> UpdatePlace(Guid placeId, PlaceRequestDto place){
            return await placeDL.UpdatePlace(placeId , place);
        }
        public async Task<PlaceResponseDto> GetPlace(Guid placeId){
            return await placeDL.GetPlace(placeId);
        }
        public async Task<IEnumerable<PlaceResponseDto>> GetAllPlaces(){
            var places = await placeDL.GetAllPlaces(); 
            return places;
        }
        public async Task DeletePlace(Guid placeId){
            await placeDL.DeletePlace(placeId);
        }
    }    
}