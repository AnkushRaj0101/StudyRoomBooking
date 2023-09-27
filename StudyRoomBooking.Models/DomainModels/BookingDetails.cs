using System;
using System.ComponentModel.DataAnnotations;

namespace StudyRoomBooking.Models.DomainModels
{

    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime Date { get; set; }
        public StudyRoom StudyRoom { get; set; }
    }
}
