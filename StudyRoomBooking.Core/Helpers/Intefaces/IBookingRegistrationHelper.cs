using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.Core.Helpers.Intefaces
{
    public interface IBookingRegistrationHelper
    {
        bool ValidateUserRequest(BookingDetails bookingDetails);
        bool IsRoomAvilable();
        
        int BookStudyRoom(BookingDetails bookingDetails);
        
    }
}
