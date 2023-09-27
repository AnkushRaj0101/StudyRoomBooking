using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.Controllers;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.Exceptions;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

[TestFixture]
public class BookingDetailsControllerTests
{
    private BookingDetailsController _controller;
    private Mock<IServiceFactory> _mockServiceFactory;
    private List<BookingDetails> mockData;

    [SetUp]
    public void SetUp()
    {
        _mockServiceFactory = new Mock<IServiceFactory>();
        _controller = new BookingDetailsController(_mockServiceFactory.Object);
        MockData();
    }
    private  List<BookingDetails> MockData()
    {
        mockData = new List<BookingDetails>()
        {
            new BookingDetails()
            {
               BookingId=1,
               Date = DateTime.Now,
               Email="rakesh@gmail.com",
               FirstName="Rakesh",
               LastName="Pernati"
            },
            new BookingDetails()
            {
               BookingId=2,
               Date = DateTime.Now,
               Email="siva@gmail.com",
               FirstName="Siva",
               LastName="Kamireddy"
            },


        };

        return mockData;
    }


    [Test]
    public void GetAllBookingDetails_WhenBookingsExist_ReturnsOkResult()
    {
        // Arrange
        var mockResponse = new BookingDetailsResponse { BookingDetails = mockData };
        _mockServiceFactory.Setup(x => x.ProcessService<EmptyRequest, BookingDetailsResponse>(It.IsAny<EmptyRequest>()))
                           .Returns(mockResponse);

        // Act
        var result = _controller.GetAllBookingDetails();

        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
    }

    [Test]
    public void GetAllBookingDetails_WhenNoBookingsExist_ReturnsNotFound()
    {
        // Arrange
        var mockResponse = new BookingDetailsResponse { BookingDetails = new List<BookingDetails>() };
        _mockServiceFactory.Setup(x => x.ProcessService<EmptyRequest, BookingDetailsResponse>(It.IsAny<EmptyRequest>()))
                           .Returns(mockResponse);

        // Act
        var result = _controller.GetAllBookingDetails();

        // Assert
        var notFoundResult = result as NotFoundObjectResult;
        Assert.IsNotNull(notFoundResult);
        Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void GetAllBookingDetails_WhenServiceThrowsException_ReturnsBadRequest()
    {
        // Arrange
        _mockServiceFactory.Setup(x => x.ProcessService<EmptyRequest, BookingDetailsResponse>(It.IsAny<EmptyRequest>()))
                           .Throws(new StudyRoomBookingException("Some error"));

        // Act
        var result = _controller.GetAllBookingDetails();

        // Assert
        var badRequestResult = result as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
        Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
    }
}
