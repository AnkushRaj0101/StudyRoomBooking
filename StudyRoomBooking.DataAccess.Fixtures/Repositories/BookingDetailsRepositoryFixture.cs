using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.Models.DomainModels;

[TestFixture]
public class BookingDetailsRepositoryTests:IDisposable
{
    private BookingDetailsRepository _repository;
    private Mock<DbSet<BookingDetails>> _mockSet;
    private ApplicationDbContext _context;

    [SetUp]
    public void SetUp()
    {
        _mockSet = new Mock<DbSet<BookingDetails>>();
       
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;

        _context = new ApplicationDbContext(options);

        _repository = new BookingDetailsRepository(_context);
    }

    [Test]
    public void GetAllBookingDetails_WhenBookingsExist_ReturnsExpectedResult()
    {
        // Arrange
        var mockBookingList = new List<BookingDetails>
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
        }.AsQueryable();

        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.Provider).Returns(mockBookingList.Provider);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.Expression).Returns(mockBookingList.Expression);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.ElementType).Returns(mockBookingList.ElementType);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.GetEnumerator()).Returns(mockBookingList.GetEnumerator());

        _context.BookingDetails.AddRange(mockBookingList);
        _context.SaveChanges();

        // Act
        var result = _repository.GetAllBookingDetails();

        // Assert
        Assert.That(result.BookingDetails.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetAllBookingDetails_WhenNoBookingsExist_ReturnsEmptyList()
    {
        // Arrange
        var mockBookingList = new List<BookingDetails>().AsQueryable();

        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.Provider).Returns(mockBookingList.Provider);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.Expression).Returns(mockBookingList.Expression);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.ElementType).Returns(mockBookingList.ElementType);
        _mockSet.As<IQueryable<BookingDetails>>().Setup(m => m.GetEnumerator()).Returns(mockBookingList.GetEnumerator());

        _context.BookingDetails.AddRange(mockBookingList);
        _context.SaveChanges();

        // Act
        var result = _repository.GetAllBookingDetails();

        // Assert
        Assert.That(result.BookingDetails.Count(), Is.EqualTo(0));
    }
    [TearDown]
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    
    
}
