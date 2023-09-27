using StudyRoomBooking.Models.Messages.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IBookingDetailsRepository
    {
        BookingDetailsResponse GetAllBookingDetails();
    }
}
