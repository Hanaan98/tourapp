using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class PlaceDL : IPlaceDL
    {
        ApplicationDbContext _db;
        public PlaceDL(ApplicationDbContext _context)
        {
            this._db = _context;
        }
        public async Task<PlaceResponseDto> SavePlace(PlaceRequestDto place)
        {
            PlaceDbDto newPlace = new PlaceDbDto
            {
                Id = Guid.NewGuid(),
                Location = place.Location,
                Description = place.Description,
                Image = place.Image,
                Price = place.Price,
                Details = place.Details,
                Departure = place.Departure,
                Days = place.Days
            };

            _db.Places.Add(newPlace);
            await _db.SaveChangesAsync();

            return PlaceMapper.toPlaceResponse(newPlace);
        }
        public async Task<PlaceResponseDto> UpdatePlace(Guid placeId, PlaceRequestDto _place)
        {
            PlaceDbDto place = await _db.Places.FindAsync(placeId);
            if (place == null)
            {
                return null;
            }
            place.Location = !string.IsNullOrEmpty(_place.Location) ? _place.Location : place.Location;
            place.Description = !string.IsNullOrEmpty(_place.Description) ? _place.Description : place.Description;
            place.Price = _place.Price != default ? _place.Price : place.Price;
            place.Days = _place.Days != default ? _place.Days : place.Days;
            place.Departure = !string.IsNullOrEmpty(_place.Departure) ? _place.Departure : place.Departure;
            place.Details = !string.IsNullOrEmpty(_place.Details) ? _place.Details : place.Details;
            place.Image = !string.IsNullOrEmpty(_place.Image) ? _place.Image : place.Image;

            await _db.SaveChangesAsync();


            return PlaceMapper.toPlaceResponse(place);
        }

        public async Task<PlaceResponseDto> GetPlace(Guid placeId)
        {
            PlaceDbDto place = await _db.Places.FindAsync(placeId);
            return place != null ? PlaceMapper.toPlaceResponse(place) : null;
        }
        public async Task<IEnumerable<PlaceResponseDto>> GetAllPlaces()
        {

            List<PlaceResponseDto> _places = await _db.Places.Select(_place =>
                PlaceMapper.toPlaceResponse(_place)
            ).ToListAsync();

            return _places;
        }

        public async Task DeletePlace(Guid placeId)
        {
            PlaceDbDto place = await _db.Places.FirstOrDefaultAsync(p => p.Id == placeId);
            if (place == null)
            {
                // return;
            }
            else
            {
                _db.Places.Remove(place);
                await _db.SaveChangesAsync();
            }
        }

    }

}