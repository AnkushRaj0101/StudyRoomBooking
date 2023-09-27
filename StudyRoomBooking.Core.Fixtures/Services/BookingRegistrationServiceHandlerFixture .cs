using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Helpers.Intefaces;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Tests.Core.Services
{
    [TestFixture]
    public class BookingRegistrationServiceHandlerTests
    {
        private Mock<IBookingRegistrationHelper> _mockBookingRegistrationHelper;
        private BookingRegistrationServiceHandler _serviceHandler;

        [SetUp]
        public void Setup()
        {
            _mockBookingRegistrationHelper = new Mock<IBookingRegistrationHelper>();
            _serviceHandler = new BookingRegistrationServiceHandler(_mockBookingRegistrationHelper.Object);
        }

        [Test]
        public void ExecuteService_InvalidUserRequest_ReturnsBookingIdMinusOne()
        {
            _mockBookingRegistrationHelper.Setup(x => x.ValidateUserRequest(It.IsAny<BookingDetails>())).Returns(false);

            var response = _serviceHandler.ExecuteService(new BookingRegistrationRequest());

            Assert.That(response.BookingId, Is.EqualTo(-1));
        }

        [Test]
        public void ExecuteService_ValidRequest_RoomNotAvailable_ReturnsBookingIdZero()
        {
            _mockBookingRegistrationHelper.Setup(x => x.ValidateUserRequest(It.IsAny<BookingDetails>())).Returns(true);
            _mockBookingRegistrationHelper.Setup(x => x.IsRoomAvilable()).Returns(false);

            var response = _serviceHandler.ExecuteService(new BookingRegistrationRequest());

            Assert.That(response.BookingId, Is.EqualTo(0));
        }

        [Test]
        public void ExecuteService_ValidRequest_RoomAvailable_ReturnsBookingIdFromBookStudyRoom()
        {
            const int expectedBookingId = 123;
            _mockBookingRegistrationHelper.Setup(x => x.ValidateUserRequest(It.IsAny<BookingDetails>())).Returns(true);
            _mockBookingRegistrationHelper.Setup(x => x.IsRoomAvilable()).Returns(true);
            _mockBookingRegistrationHelper.Setup(x => x.BookStudyRoom(It.IsAny<BookingDetails>())).Returns(expectedBookingId);

            var response = _serviceHandler.ExecuteService(new BookingRegistrationRequest());

            Assert.That(response.BookingId, Is.EqualTo(expectedBookingId));
        }
    }
}
