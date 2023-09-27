using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Response;
using System.Collections.Generic;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class BookingConfirmationRepository :IBookingConfirmationRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingConfirmationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        BookingConfirmationResponse IBookingConfirmationRepository.GetBookingDetailsById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var booking = _context.BookingDetails.Include(x=>x.StudyRoom).FirstOrDefault(b=>b.BookingId == id);
            if (booking == null)
            {
                return null;
            }
            return new BookingConfirmationResponse
            {
                BookingDetails = booking,
            };
        }


    }
}
