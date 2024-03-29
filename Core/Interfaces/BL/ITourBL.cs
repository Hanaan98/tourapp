﻿using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.BL
{
    public interface ITourBL
    {
        public Task<TourResponseDto> SaveTour(TourRequestDto tour);
        public Task<TourResponseDto> UpdateTour(Guid tourId, TourRequestDto tour);
        public Task<TourResponseDto> GetTour(Guid tourId);
        public Task<IEnumerable<TourResponseDto>> GetAllTours(Guid? PlaceId);

        public Task DeleteTour(Guid tourId);
    }
}
