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
    public class TourService : ITourBL
    {
        ITourDL tourDL;
        public TourService(ITourDL tourDL)
        {
            this.tourDL = tourDL;
        }
        public async Task<TourResponseDto> SaveTour(TourRequestDto tour)
        {
            return await tourDL.SaveTour(tour);
        }
        public async Task<TourResponseDto> UpdateTour(Guid tourId, TourRequestDto tour)
        {
            return await tourDL.UpdateTour(tourId, tour);
        }
        public async Task<TourResponseDto> GetTour(Guid tourId)
        {
            return await tourDL.GetTour(tourId);
        }
        public async Task<IEnumerable<TourResponseDto>> GetAllTours()
        {
            var tours = await tourDL.GetAllTours();
            return tours;
        }
        public async Task DeleteTour(Guid tourId)
        {
            await tourDL.DeleteTour(tourId);
        }
        
    }
}
