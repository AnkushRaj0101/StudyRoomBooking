using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public BookingDetailsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpGet]
        public  IActionResult GetAllBookingDetails()
        {
            try
            {
                var bookingResponse = _serviceFactory.ProcessService<EmptyRequest, BookingDetailsResponse>(EmptyRequest.Instance);

                if (bookingResponse.BookingDetails.Count()==0)
                {
                    return NotFound("No bookings found.");
                }

                return Ok(bookingResponse);
            }
            catch (StudyRoomBookingException ex)
            {
                return BadRequest($"Booking Error: {ex.Message}");
            }
        }
    }
}
