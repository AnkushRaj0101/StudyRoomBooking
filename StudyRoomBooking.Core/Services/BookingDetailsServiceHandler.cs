using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{
    public class BookingDetailsServiceHandler : IServiceHandler<EmptyRequest, BookingDetailsResponse>
    {
        private readonly IBookingDetailsRepository _bookingDetailsrepository;

        public BookingDetailsServiceHandler(IBookingDetailsRepository bookingDetailsrepository)
        {
            _bookingDetailsrepository = bookingDetailsrepository;
        }

        public BookingDetailsResponse ExecuteService(EmptyRequest request)
        {
            return _bookingDetailsrepository.GetAllBookingDetails();
        }
    }
}
