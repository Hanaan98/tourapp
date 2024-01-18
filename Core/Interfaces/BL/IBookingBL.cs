using Core.Models.Request;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.BL
{
    public interface IBookingBL
    {
        public Task<BookingResponseDto> CreateBooking(BookingRequestDTO bookingRequestDto);
        public Task<BookingResponseDto> UpdateBooking(Guid bookingId, BookingRequestDTO bookingRequestDto);
        public Task<BookingResponseDto> GetBooking(Guid bookingId);
        public Task<IEnumerable<BookingResponseDto>> GetAllBookings(Guid? _tourId, Guid? _userId);
        public Task DeleteBooking(Guid bookingId);



    }
}
