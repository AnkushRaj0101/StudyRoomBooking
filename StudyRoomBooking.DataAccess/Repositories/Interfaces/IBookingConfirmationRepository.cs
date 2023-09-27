using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IBookingConfirmationRepository
    {
        BookingConfirmationResponse GetBookingDetailsById(int id);
    }
}
