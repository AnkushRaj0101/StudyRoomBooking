using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repositories
{
    public class BookingRegistrationRepository : IBookingRegistrationRepository
    {

        private readonly ApplicationDbContext _context;
        public BookingRegistrationRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
       

        public int BookStudyRoom(BookingDetails bookingDetails)
        {
            StudyRoom studyRoom = _context.StudyRooms.FirstOrDefault(e => e.IsAvailable.Equals(true));
            bookingDetails.StudyRoom = studyRoom;
            _context.BookingDetails.Add(bookingDetails);
            _context.SaveChanges();

            ChangeRoomAvilabilityStatus(studyRoom.RoomNumber);

            var recentRecord = _context.BookingDetails
                            .OrderByDescending(x => x.BookingId)
                            .FirstOrDefault();

            return recentRecord.BookingId;
        }

        private void ChangeRoomAvilabilityStatus(string refRoomNo)
        {

            StudyRoom room = _context.StudyRooms.FirstOrDefault(e => e.RoomNumber.Equals(refRoomNo));
            room.IsAvailable = false;
            _context.StudyRooms.Update(room);
            _context.SaveChanges();
        }

        public StudyRoom IsRoomAvilable()
        {
            StudyRoom roomDetails = _context.StudyRooms.FirstOrDefault(e => e.IsAvailable.Equals(true));
            return roomDetails;
        }

       
    }
}
