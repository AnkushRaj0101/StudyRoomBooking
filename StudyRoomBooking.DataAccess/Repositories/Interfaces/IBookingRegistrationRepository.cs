using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IBookingRegistrationRepository
    {
        int BookStudyRoom(BookingDetails bookingDetails);
       
        StudyRoom IsRoomAvilable();




    }
}
