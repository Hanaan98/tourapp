using Core.Models.Response;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Mapper
{
    public class BookingResponseMapper
    {
        public static BookingResponseDto toBookingResponse(BookingDbDto booking)
        {
            return new BookingResponseDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                TourId = booking.TourId,
                Seats = booking.Seats,
                FullName = booking.FullName,
                Email = booking.Email,
                Phone = booking.Phone,
                CNIC = booking.CNIC,
                Cancelled = booking.Cancelled,
                Paid = booking.Paid,
                Tour = MapTour(booking.Tour),
               

            };
        }
        private static TourResponseDto MapTour(TourDbDto tour)
        {
            if (tour == null)
            {
                return null;
            }

            return TourResponseMapper.toTourResponse(tour);
        }
        


    }
}
