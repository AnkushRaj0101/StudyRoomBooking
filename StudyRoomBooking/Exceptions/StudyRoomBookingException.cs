namespace StudyRoomBooking.Exceptions
{
    public class StudyRoomBookingException : ApplicationException
    {
        public StudyRoomBookingException() { }

        public StudyRoomBookingException(string message) : base(message) { }

        public StudyRoomBookingException(string message, Exception innerException) : base(message, innerException) { }
    }

}
