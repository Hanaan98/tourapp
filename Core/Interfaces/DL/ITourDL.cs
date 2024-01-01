using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.DL
{
    public interface ITourDL
    {
        public Task<TourResponseDto> SaveTour(TourRequestDto tour);
        public Task<TourResponseDto> UpdateTour(Guid tourId, TourRequestDto tour);
        public Task<TourResponseDto> GetTour(Guid tourId);
        public Task<IEnumerable<TourResponseDto>> GetAllTours();

        public Task DeleteTour(Guid tourId);
    }
}
