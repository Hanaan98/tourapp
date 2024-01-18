using Azure.Core;
using BL;
using Core.Interfaces.BL;
using Core.Models.Request;
using DL;
using Microsoft.AspNetCore.Mvc;

namespace tourapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        public IBookingBL bookingService;
        public BookingController(IBookingBL bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetBooking(Guid Id)
        {
            try
            {
                var booking = await bookingService.GetBooking(Id);
                return Ok(booking);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("")]
        public async Task<IActionResult> GetBookings(Guid? _tourId, Guid? _userId)
        {
            try
            {
                var bookings =await bookingService.GetAllBookings(_tourId, _userId);
                return Ok(bookings);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(BookingRequestDTO bookingRequestDto)
        {
            try
            {
                var booking = await bookingService.CreateBooking(bookingRequestDto);
                return Ok(booking);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, BookingRequestDTO bookingRequestDto)
        {
            try
            {
                var booking = await bookingService.UpdateBooking(Id, bookingRequestDto);
                return Ok(booking);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await bookingService.DeleteBooking(Id);
                return Ok("Booking Deleted Successfully");
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
