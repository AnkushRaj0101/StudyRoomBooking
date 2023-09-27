﻿using Microsoft.AspNetCore.Mvc;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingConfirmationController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
        public BookingConfirmationController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingDetailsById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound($"Given ID {id} is Invalid");
                }
                var request = new BookingRequest { Id = id };
                var bookingResponse = _serviceFactory.ProcessService<BookingRequest, BookingConfirmationResponse>(request);

                if (bookingResponse == null)
                {
                    return NotFound($"No bookings found with {id}.");
                }

                return Ok(bookingResponse);
            }
            catch (StudyRoomBookingException ex)
            {
                return BadRequest($"Study StudyRoom Booking Error: {ex.Message}");
            }
        }
    }
}
