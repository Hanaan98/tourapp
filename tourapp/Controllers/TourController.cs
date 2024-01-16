using BL;
using Core.Interfaces.BL;
using Core.Models.Request;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace tourapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        ITourBL tourService;
        public TourController(ITourBL _service)
        {
            tourService = _service;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllTours()
        {
            try
            {
                var places = await tourService.GetAllTours();

                return Ok(places);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTourById(Guid Id)
        {
            try
            {
                var place = await tourService.GetTour(Id);

                return Ok(place);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TourRequestDto _tour)
        {

            try
            {
                await tourService.SaveTour(_tour);
                return Ok("Tour Created Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit/{Id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTour(Guid Id, TourRequestDto tourRequestdata)
        {

            try
            {
                TourResponseDto tour = await tourService.UpdateTour(Id, tourRequestdata);
                return Ok(tour);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTour(Guid Id)
        {

            try
            {
                await tourService.DeleteTour(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
