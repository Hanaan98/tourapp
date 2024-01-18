using Core.Interfaces.BL;
using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookingService : IBookingBL
    {
        public IBookingDL bookingDL;
        public BookingService(IBookingDL bookingDL)
        {
            this.bookingDL = bookingDL;
        }
        public async Task<BookingResponseDto> CreateBooking(BookingRequestDTO bookingRequestDto)
        {
            return await bookingDL.CreateBooking(bookingRequestDto);
        }
        public async Task<BookingResponseDto> UpdateBooking(Guid bookingId, BookingRequestDTO bookingRequestDto)
        {
            return await bookingDL.UpdateBooking(bookingId, bookingRequestDto);
        }
        public async Task<BookingResponseDto> GetBooking(Guid bookingId)
        {
            return await bookingDL.GetBooking(bookingId);
        }
        public async Task<IEnumerable<BookingResponseDto>> GetAllBookings(Guid? _tourId, Guid? _userId)
        {
            return await bookingDL.GetAllBookings(_tourId, _userId);
        }
        public async Task DeleteBooking(Guid bookingId)
        {
            await bookingDL.DeleteBooking(bookingId);
        }
    }
}
