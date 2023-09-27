using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRegistrationController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public BookingRegistrationController(IServiceFactory serviceFactory)
         {
            _serviceFactory = serviceFactory;
         }

        [HttpPost("RoomBooking")]
        public  IActionResult StudyRoomBooking(BookingDetails bookingDetails)
        {
            try
            {
                var bookingRegistrationRequest = new BookingRegistrationRequest()
                {
                    BookingDetails = bookingDetails
                };

                var result = _serviceFactory.ProcessService<BookingRegistrationRequest, BookingRegistrationReponse>(bookingRegistrationRequest);
               
                if (result.BookingId==-1)
                {
                    return BadRequest("UserDetails Are Invalid");
                }
                
                if (result.BookingId == 0)
                {
                    return Ok("StudyRoom is Unavailable");
                }
               
               
                return Ok($"{result.BookingId}");
              
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
               
            }
        }

    }

}
