using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{
    public class BookingConfirmationServiceHandler : IServiceHandler<BookingRequest,BookingConfirmationResponse>
    {
        private readonly IBookingConfirmationRepository _repository;
        public BookingConfirmationServiceHandler(IBookingConfirmationRepository repository)
        {
            _repository = repository;
        }
        public BookingConfirmationResponse ExecuteService(BookingRequest request)
        {
            return _repository.GetBookingDetailsById(request.Id);
        }
    }
}
