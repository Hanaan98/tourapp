using Core.Interfaces.DL;
using Core.Models.Request;
using Core.Models.Response;
using DL.DbModels;
using DL.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class BookingDL : IBookingDL
    {
        ApplicationDbContext _db;
        public BookingDL(ApplicationDbContext _context)
        {
            this._db = _context;
        }
        public async Task<BookingResponseDto> CreateBooking(BookingRequestDTO bookingRequestDto)
        {
            TourDbDto tour = await _db.Tours.FindAsync(bookingRequestDto.TourId);
            if (tour == null)
            {
                throw new Exception("Tour not found");
            }
            BookingDbDto newBooking = new BookingDbDto()
            {
                Id = Guid.NewGuid(),
                TourId = bookingRequestDto.TourId,
                UserId = bookingRequestDto.UserId,
                Seats = bookingRequestDto.Seats,
                FullName = bookingRequestDto.FullName,
                Email = bookingRequestDto.Email,
                Phone = bookingRequestDto.Phone,
                CNIC = bookingRequestDto.CNIC
            };
            _db.Bookings.Add(newBooking);
            await _db.SaveChangesAsync();
            return BookingResponseMapper.toBookingResponse(newBooking);
        }
        public async Task<BookingResponseDto> UpdateBooking(Guid bookingId, BookingRequestDTO booking)
        {
            BookingDbDto _booking = _db.Bookings.Find(bookingId);
            if (_booking == null)
            {
                throw new Exception("Booking not found");
            }
            _booking.FullName = !string.IsNullOrEmpty(booking.FullName) ? booking.FullName : _booking.FullName;
            _booking.Email = !string.IsNullOrEmpty(booking.Email) ? booking.Email : _booking.Email;
            _booking.Phone = !string.IsNullOrEmpty(booking.Phone) ? booking.Phone : _booking.Phone;
            _booking.CNIC = !string.IsNullOrEmpty(booking.CNIC) ? booking.CNIC : _booking.CNIC;
            _booking.Seats = booking.Seats != default ? booking.Seats : _booking.Seats;
            _booking.Cancelled = booking.Cancelled != default ? booking.Cancelled : _booking.Cancelled;
            _booking.Paid = booking.Paid != default ? booking.Paid : _booking.Paid;
            if (_booking.Paid)
            {
                TourDbDto tour = _db.Tours.Find(_booking.TourId);
                if (tour == null)
                {
                    throw new Exception("Tour not found");
                }
                if (tour.RemainingSeats < _booking.Seats)
                {
                    throw new Exception("Remaining seats cannot be less than total seats");
                }
                tour.RemainingSeats -= _booking.Seats;
                _db.Tours.Update(tour);
            }
            await _db.SaveChangesAsync();
            return BookingResponseMapper.toBookingResponse(_booking);

        }
        public async Task<BookingResponseDto> GetBooking(Guid bookingId)
        {
            BookingDbDto booking = await _db.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            return BookingResponseMapper.toBookingResponse(booking);

        }
        public async Task<IEnumerable<BookingResponseDto>> GetAllBookings(Guid? _tourId, Guid? _userId)
        {
            IQueryable<BookingDbDto> _bookings = _db.Bookings.Include(t => t.Tour).ThenInclude(p => p.Place).Include(u => u.User);
            if (_tourId != null)
            {
                _bookings =_bookings.Where(b => b.TourId == _tourId);
            }
            if (_userId != null)
            {
                _bookings = _bookings.Where(b => b.UserId == _userId);
            }
            var Bookings = await _bookings.ToListAsync();
            return (Bookings.Select(b => BookingResponseMapper.toBookingResponse(b)));
        }
        public async Task DeleteBooking(Guid bookingId)
        {
            BookingDbDto booking = await _db.Bookings.FindAsync(bookingId) ?? throw new Exception("No Booking Found");
            _db.Bookings.Remove(booking);
            await _db.SaveChangesAsync();
        }
    }
}
