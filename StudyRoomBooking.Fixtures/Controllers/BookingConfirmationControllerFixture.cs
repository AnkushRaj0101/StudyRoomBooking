using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Fixtures.Controllers
{
    public class BookingConfirmationControllerFixture
    {
        private BookingConfirmationController _bookingController;
        private Mock<IServiceFactory> _serviceFactoryMock;
        [SetUp]
        public void Setup()
        {
            _serviceFactoryMock = new Mock<IServiceFactory>();
            _bookingController = new BookingConfirmationController(_serviceFactoryMock.Object);
        }

        [Test]
        public async Task GetBooking_NoBookingFound_ReturnsNotFound()
        {
            // Arrange
            var expectedStatusCode = 404;
            BookingConfirmationResponse? response = null;
            var bookingRequest = new BookingRequest();
            _serviceFactoryMock.Setup(factory => factory.ProcessService<BookingRequest, BookingConfirmationResponse>(bookingRequest))
                .Returns(response);

            // Act
            var result = await _bookingController.GetBookingDetailsById(bookingRequest.Id) as NotFoundObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode));
                Assert.That(result.Value, Is.EqualTo($"Given ID {bookingRequest.Id} is Invalid"));
            });
        }
        [Test]
        public async Task GetBookingDetails_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            var RefBookingDetails = new BookingDetails()
            {
                BookingId = 1,
                Date = DateTime.Now,
                Email="siva@gmail.com",
                FirstName="siva",
                LastName="kamireddy",
                StudyRoom=new StudyRoom()
                {
                    Id=1,
                    IsAvailable=true,
                    Name="earth",
                    RoomNumber="A101"
                }
            };
            var expectedBookingResponse = new BookingConfirmationResponse() { BookingDetails = RefBookingDetails };
          
            _serviceFactoryMock.Setup(factory => factory.ProcessService<BookingRequest, BookingConfirmationResponse>(It.IsAny<BookingRequest>()))
                .Returns(expectedBookingResponse);

            // Act
            var result = await _bookingController.GetBookingDetailsById(validId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(expectedBookingResponse));
        }

        [Test]
        public async Task GetBookingDetails_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = -1;

            // Act
            var result = await _bookingController.GetBookingDetailsById(invalidId) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.That(result.Value, Is.EqualTo($"Given ID {invalidId} is Invalid"));
        }

    }
}
