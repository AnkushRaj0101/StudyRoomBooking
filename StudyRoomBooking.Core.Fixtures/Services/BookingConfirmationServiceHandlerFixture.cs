using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.Fixtures.Services
{
    [TestFixture]
    public class BookingConfirmationServiceHandlerFixture
    {
        [Test]
        public void ExecuteService_ValidBookingRequest_ReturnsBookingDetailsResponse()
        {
            // Arrange
            int validId = 1;
            var request = new BookingRequest { Id = validId };

            // Create a mock for IBookingDetailsRepository
            var mockRepository = new Mock<IBookingConfirmationRepository>();
            var expectedResponse = new BookingConfirmationResponse { BookingDetails = new BookingDetails() };
            mockRepository.Setup(repo => repo.GetBookingDetailsById(validId)).Returns(expectedResponse);

            var serviceHandler = new BookingConfirmationServiceHandler(mockRepository.Object);

            // Act
            var result = serviceHandler.ExecuteService(request);

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void ExecuteService_InvalidBookingRequest_ReturnsNull()
        {
            // Arrange
            var request = new BookingRequest { Id = 0 };

            // Create a mock for IBookingDetailsRepository
            var mockRepository = new Mock<IBookingConfirmationRepository>();
            _ = mockRepository.Setup(repo => repo.GetBookingDetailsById(It.IsAny<int>())).Returns((BookingConfirmationResponse)null);

            var serviceHandler = new BookingConfirmationServiceHandler(mockRepository.Object);

            // Act
            var result = serviceHandler.ExecuteService(request);

            // Assert
            Assert.Null(result);
        }
    }
}
