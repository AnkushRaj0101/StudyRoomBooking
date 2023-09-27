using System.Collections.Generic;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.Models.Messages.Response
{
    public class StudyRoomResponse
    {
        public IEnumerable<StudyRoom> Rooms { get; set; }

    }
}
