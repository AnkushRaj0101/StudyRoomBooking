using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Fixtures.Services
{
    [TestFixture]
    public class RoomServiceHandlerFixture
    {
        [Test]
        public void ExecuteService_Returns_RoomResponse()
        {
            // Arrange
            var mockRoomRepository = new Mock<IStudyRoomRepository>();
            var roomServiceHandler = new RoomServiceHandler(mockRoomRepository.Object);
            var emptyRequest = new EmptyRequest();

            var expectedResponse = new StudyRoomResponse { };

            mockRoomRepository.Setup(repo => repo.GetRooms()).Returns(expectedResponse);

            // Act
            var result = roomServiceHandler.ExecuteService(emptyRequest);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }

    }
}
