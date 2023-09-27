using StudyRoomBooking.Core.Helpers.Intefaces;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StudyRoomBooking.Core.Helpers
{
    public class BookingRegistrationService : IBookingRegistrationHelper
    {
        private readonly IBookingRegistrationRepository _registrationRepo;
        public BookingRegistrationService(IBookingRegistrationRepository registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }


		public bool ValidateUserRequest(BookingDetails bookingDetails)
		{

			if (!NameValidation(bookingDetails.FirstName))
			{
				return false;
			}
			else if (!NameValidation(bookingDetails.LastName))
			{
				return false;
			}
			else if (!Emailvalidation(bookingDetails.Email))
			{
				return false;
			}
			else if (!DateValidation(bookingDetails.Date))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool IsRoomAvilable()
		{
			StudyRoom roomDetails = _registrationRepo.IsRoomAvilable();
			if (roomDetails == null)
			{

				return false;
			}

			return true;
		}

		private bool NameValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 20)
            {
                return false;
            }
            if (!name.All(ch => char.IsLetter(ch) || char.IsWhiteSpace(ch)))
            {
                return false;
            }

            return true;

        }
        private bool Emailvalidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            const string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool DateValidation(DateTime date)
        {
            string desiredFormat = "yyyy-MM-dd";
            string formattedDate = date.ToString(desiredFormat);
            DateTime parsedDate;

            if (DateTime.TryParseExact(formattedDate, desiredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return date.Date == parsedDate.Date && date >= DateTime.Today;
            }

            return false;

        }

        public int BookStudyRoom(BookingDetails bookingDetails)
        {
            int bookingid= _registrationRepo.BookStudyRoom(bookingDetails);
            return bookingid;
        }
    }
}
