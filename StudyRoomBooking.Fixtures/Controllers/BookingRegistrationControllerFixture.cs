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
    [TestFixture]
    public class BookingRegistrationControllerFixture
    {

        private Mock<IServiceFactory> _mockServiceFactory;
        private BookingRegistrationController _controller;


        [SetUp]
        public void SetUp()
        {
            _mockServiceFactory = new Mock<IServiceFactory>();
            _controller = new BookingRegistrationController(_mockServiceFactory.Object);
        }


        [Test]
        public void Should_Return_BadRequest_When_BookingId_Is_Negative_One()
        {
            // Arrange
            var bookingDetails = new BookingDetails();
            _mockServiceFactory.Setup(x => x.ProcessService<BookingRegistrationRequest, BookingRegistrationReponse>(It.IsAny<BookingRegistrationRequest>()))
                              .Returns(new BookingRegistrationReponse { BookingId = -1 });

            // Act
            var result = _controller.StudyRoomBooking(bookingDetails);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.That(((BadRequestObjectResult)result).Value, Is.EqualTo("UserDetails Are Invalid"));
        }

        [Test]
        public void Should_Return_NotFound_When_BookingId_Is_Zero()
        {
            // Arrange
            var bookingDetails = new BookingDetails();
            _mockServiceFactory.Setup(x => x.ProcessService<BookingRegistrationRequest, BookingRegistrationReponse>(It.IsAny<BookingRegistrationRequest>()))
                              .Returns(new BookingRegistrationReponse { BookingId = 0 });

            // Act
            var result = _controller.StudyRoomBooking(bookingDetails);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            Assert.That(((NotFoundObjectResult)result).Value, Is.EqualTo("StudyRoom is Unavailable"));
        }

        [Test]
        public void Should_Return_Ok_With_Positive_BookingId_Value()
        {
            // Arrange
            var bookingDetails = new BookingDetails();
            _mockServiceFactory.Setup(x => x.ProcessService<BookingRegistrationRequest, BookingRegistrationReponse>(It.IsAny<BookingRegistrationRequest>()))
                              .Returns(new BookingRegistrationReponse { BookingId = 1 });

            // Act
            var result = _controller.StudyRoomBooking(bookingDetails);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.That(((OkObjectResult)result).Value, Is.EqualTo("Your Booking is successfull with BookingId:1"));
        }

        [Test]
        public void Should_Return_StatusCode_500_When_Exception_Is_Thrown()
        {
            // Arrange
            var bookingDetails = new BookingDetails();
            _mockServiceFactory.Setup(x => x.ProcessService<BookingRegistrationRequest, BookingRegistrationReponse>(It.IsAny<BookingRegistrationRequest>()))
                              .Throws(new Exception("Some went wrong"));

            // Act
            var result = _controller.StudyRoomBooking(bookingDetails);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            Assert.That(((ObjectResult)result).StatusCode, Is.EqualTo(500));
        }
    }




}










