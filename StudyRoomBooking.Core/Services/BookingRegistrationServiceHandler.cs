using StudyRoomBooking.Core.Helpers.Intefaces;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{
    public class BookingRegistrationServiceHandler : IServiceHandler<BookingRegistrationRequest,BookingRegistrationReponse>
    {
        private IBookingRegistrationHelper _bookingRegistration;
        
        public BookingRegistrationServiceHandler(IBookingRegistrationHelper bookingRegistration) { 
        
            _bookingRegistration = bookingRegistration;
            
        }
        public BookingRegistrationReponse ExecuteService(BookingRegistrationRequest request)
        {
            var bookingResponse=new BookingRegistrationReponse();

            bool isValid = _bookingRegistration.ValidateUserRequest(request.BookingDetails);
            if (!isValid)
            {
                bookingResponse.BookingId = -1;
                return bookingResponse;
            }
            bool roomStatus= _bookingRegistration.IsRoomAvilable();
            if (!roomStatus)
            {
                bookingResponse.BookingId = 0;
                return bookingResponse;
            }
            int bookingId= _bookingRegistration.BookStudyRoom(request.BookingDetails);
            
            bookingResponse.BookingId = bookingId;
            return bookingResponse;


           
        }

        
    }
}
