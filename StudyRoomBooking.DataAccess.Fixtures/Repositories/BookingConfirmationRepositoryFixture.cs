using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess.Fixtures.Repositories
{
    [TestFixture]
    public class BookingConfirmationRepositoryFixture:IDisposable
    {
        private IBookingConfirmationRepository _bookingDetailsRepository;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Create a new instance of the DbContext with an in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _bookingDetailsRepository = new BookingConfirmationRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetBookingDetailsById_ValidId_ReturnsBookingDetailsResponse()
        {
            // Arrange
            int validId = 1;

            // Add a sample BookingDetails to the in-memory database
            _context.BookingDetails.Add(new BookingDetails { BookingId = validId, FirstName = "Siva", LastName = "Krishna", Email = "siva123@gmail.com", Date = DateTime.Now, StudyRoom = new StudyRoom { Id = 1, Name = "Earth", RoomNumber = "A123", IsAvailable = true } });
            _context.SaveChanges();

            // Act
            var result = _bookingDetailsRepository.GetBookingDetailsById(validId);

            // Assert
            Assert.NotNull(result);
            Assert.Multiple(() =>
            {
                Assert.That(result.BookingDetails.BookingId, Is.EqualTo(validId));
                Assert.That(result.BookingDetails.FirstName, Is.EqualTo("Siva"));
            });

        }

        [Test]
        public void GetBookingDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _bookingDetailsRepository.GetBookingDetailsById(invalidId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetBookingDetailsById_IdNotFound_ReturnsNull()
        {
            // Arrange
            int nonExistentId = 999;

            // Act
            var result = _bookingDetailsRepository.GetBookingDetailsById(nonExistentId);

            // Assert
            Assert.IsNull(result);
        }

        [TearDown]
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }


    }
}
