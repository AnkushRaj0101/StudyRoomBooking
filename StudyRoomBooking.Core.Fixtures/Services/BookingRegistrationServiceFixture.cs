using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Helpers.Intefaces;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;

namespace StudyRoomBooking.Core.Fixtures.Services
{
   
    public class BookingRegistrationHelperFixture
    {
        private Mock<IBookingRegistrationHelper> _bookingRegistrationMock;
        private BookingRegistrationServiceHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _bookingRegistrationMock = new Mock<IBookingRegistrationHelper>();
            _handler = new BookingRegistrationServiceHandler(_bookingRegistrationMock.Object);
        }

        [Test]
        public void ExecuteService_InvalidRequest_ReturnsBookingIdNegativeOne()
        {
            // Arrange
            var request = new BookingRegistrationRequest { BookingDetails = new BookingDetails() }; // Assuming BookingDetails is a class
            _bookingRegistrationMock.Setup(x => x.ValidateUserRequest(request.BookingDetails)).Returns(false);

            // Act
            var response = _handler.ExecuteService(request);

            // Assert
            Assert.That(response.BookingId, Is.EqualTo(-1));
        }

        [Test]
        public void ExecuteService_ValidRequestButNoRoomAvailable_ReturnsBookingIdZero()
        {
            // Arrange
            var request = new BookingRegistrationRequest { BookingDetails = new BookingDetails() };
            _bookingRegistrationMock.Setup(x => x.ValidateUserRequest(request.BookingDetails)).Returns(true);
            _bookingRegistrationMock.Setup(x => x.IsRoomAvilable()).Returns(false);

            // Act
            var response = _handler.ExecuteService(request);

            // Assert
            Assert.That(response.BookingId, Is.EqualTo(0));
        }

        [Test]
        public void ExecuteService_ValidRequestAndRoomAvailable_ReturnsPositiveBookingId()
        {
            // Arrange
            var request = new BookingRegistrationRequest { BookingDetails = new BookingDetails() };
            int expectedBookingId = 5;  // Sample value

            _bookingRegistrationMock.Setup(x => x.ValidateUserRequest(request.BookingDetails)).Returns(true);
            _bookingRegistrationMock.Setup(x => x.IsRoomAvilable()).Returns(true);
            _bookingRegistrationMock.Setup(x => x.BookStudyRoom(request.BookingDetails)).Returns(expectedBookingId);

            // Act
            var response = _handler.ExecuteService(request);

            // Assert
            Assert.That(response.BookingId, Is.EqualTo(expectedBookingId));
        }


    }

}

