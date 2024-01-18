using Core.Interfaces.BL;
using Core.Models.Request;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace tourapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        IPlaceBL placeService;
        public PlaceController(IPlaceBL _service)
        {
            placeService = _service;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllPlaces()
        {
            try
            {
                var places = await placeService.GetAllPlaces();

                return Ok(places);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPlaceById(Guid Id)
        {
            try
            {
                var place = await placeService.GetPlace(Id);

                return Ok(place);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PlaceRequestDto _place)
        {
            if (_place.Location == null || _place.Description == null || _place.Departure == null || _place.Details == null || _place.Image == null)
            {
                return BadRequest("All fields are required");
            }

            try
            {
                await placeService.SavePlace(_place);
                return Ok("Place Created Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit/{Id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPlace(Guid Id, PlaceRequestDto placeRequestdata)
        {

            try
            {
                PlaceResponseDto place = await placeService.UpdatePlace(Id, placeRequestdata);
                return Ok(place);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlace(Guid Id)
        {

            try
            {
                await placeService.DeletePlace(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}