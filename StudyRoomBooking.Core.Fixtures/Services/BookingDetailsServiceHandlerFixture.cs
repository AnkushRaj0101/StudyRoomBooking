using Moq;
using NUnit.Framework;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

[TestFixture]
public class BookingDetailsServiceHandlerTests
{
    private BookingDetailsServiceHandler _serviceHandler;
    private Mock<IBookingDetailsRepository> _mockBookingDetailsRepository;

    [SetUp]
    public void SetUp()
    {
        _mockBookingDetailsRepository = new Mock<IBookingDetailsRepository>();
        _serviceHandler = new BookingDetailsServiceHandler(_mockBookingDetailsRepository.Object);
    }

    [Test]
    public void ExecuteService_WhenCalled_ReturnsBookingDetailsFromRepository()
    {
        // Arrange
        var mockBookingDetailsResponse = new BookingDetailsResponse
        {
            BookingDetails = new List<BookingDetails>
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
            }
            }
        };

        _mockBookingDetailsRepository.Setup(repo => repo.GetAllBookingDetails())
                                     .Returns(mockBookingDetailsResponse);

        // Act
        var result = _serviceHandler.ExecuteService(EmptyRequest.Instance);

        // Assert
        Assert.That(result.BookingDetails.Count(), Is.EqualTo(2));
        _mockBookingDetailsRepository.Verify(repo => repo.GetAllBookingDetails(), Times.Once);
    }
}
