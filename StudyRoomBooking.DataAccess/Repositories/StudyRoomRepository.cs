using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Response;
using System;
using System.Linq;

namespace StudyRoomBooking.DataAccess.Repositories
{

    public  class StudyRoomRepository : IStudyRoomRepository
    {
        private readonly ApplicationDbContext _context;
        
        public StudyRoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        StudyRoomResponse IStudyRoomRepository.GetRooms()
        {
            
            var rooms = _context.StudyRooms.ToList();

            return new StudyRoomResponse
            {
                Rooms = rooms
            };
        }
    }
}
