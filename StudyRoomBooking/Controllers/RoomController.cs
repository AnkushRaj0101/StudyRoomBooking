using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
    
        public RoomController(IServiceFactory serviceFactory)
        {
  
            _serviceFactory = serviceFactory;
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var roomsResponse =  _serviceFactory.ProcessService<EmptyRequest, StudyRoomResponse>(EmptyRequest.Instance);

                if (roomsResponse == null )
                {
                    return NotFound("No rooms found.");
                }

                return Ok(roomsResponse);
            }
            catch (StudyRoomBookingException ex)
            {
                return BadRequest($"Study StudyRoom Booking Error: {ex.Message}");
            }
        }
    }
}
