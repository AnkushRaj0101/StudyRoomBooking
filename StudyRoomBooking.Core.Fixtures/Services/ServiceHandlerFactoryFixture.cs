using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Fixtures.Services
{
    [TestFixture]
    public class ServiceHandlerFactoryFixture
    {
        [Test]
        public void ProcessService_Returns_ServiceResponse()
        {
            // Arrange
            var mockServiceProvider = new Mock<IServiceProvider>();
            var serviceHandlerFactory = new ServiceHandlerFactory(mockServiceProvider.Object);

            var request = new EmptyRequest();
            var response = new StudyRoomResponse();

            // Mock the service handler
            var mockServiceHandler = new Mock<IServiceHandler<EmptyRequest, StudyRoomResponse>>();
            mockServiceHandler.Setup(handler => handler.ExecuteService(request)).Returns(response);

            mockServiceProvider
                .Setup(provider => provider.GetService(typeof(IServiceHandler<EmptyRequest, StudyRoomResponse>)))
                .Returns(mockServiceHandler.Object);

            // Act
            var result = serviceHandlerFactory.ProcessService<EmptyRequest, StudyRoomResponse>(request);

            // Assert
            Assert.That(result, Is.EqualTo(response));
        }
    }
}
