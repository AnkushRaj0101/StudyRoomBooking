using StudyRoomBooking.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.Models.Messages.Response
{
    public class BookingDetailsResponse
    {
        public IEnumerable<BookingDetails> BookingDetails { get; set; } 
    }
}
