using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Response;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BookingDetailsResponse GetAllBookingDetails()
        {
            var bookings = _context.BookingDetails.Include(e=>e.StudyRoom).ToList();
            return new BookingDetailsResponse { BookingDetails = bookings };
        }
    }
}
