using System.ComponentModel.DataAnnotations;

namespace StudyRoomBooking.Models.DomainModels
{
    public class StudyRoom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
