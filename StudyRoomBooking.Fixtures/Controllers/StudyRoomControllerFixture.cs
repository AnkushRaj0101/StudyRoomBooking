using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace YourNamespace.Tests.Controllers
{
    [TestFixture]
    public class StudyRoomControllerFixture
    {
        private RoomController _roomController;
        private Mock<IServiceFactory> _serviceFactoryMock;

        [SetUp]
        public void Setup()
        {
            _serviceFactoryMock = new Mock<IServiceFactory>();
            _roomController = new RoomController(_serviceFactoryMock.Object);
        }
     
        [Test]
        public async Task GetAllRooms_NoRoomsFound_ReturnsNotFound()
        {
            // Arrange
            var expectedStatusCode = 404;
            StudyRoomResponse? response = null;
            _serviceFactoryMock.Setup(factory => factory.ProcessService<EmptyRequest, StudyRoomResponse>(EmptyRequest.Instance))
                .Returns(response);

            // Act
            var result = await _roomController.GetAllRooms() as NotFoundObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode));
                Assert.That(result.Value, Is.EqualTo("No rooms found."));
            });
        }
    }
}
