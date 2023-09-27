using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudyRoomBooking.DataAccess.Repositories;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess.Fixtures.Repositories
{
    [TestFixture]
    public class BookingRegistrationRepositoryFixture : IDisposable
    {
        private ApplicationDbContext _context;
        private BookingRegistrationRepository _bookingRegistrationRepository; // Assuming the method is in a service called YourService

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "StudyRoomBooking").Options;
            _context = new ApplicationDbContext(options);
            _bookingRegistrationRepository = new BookingRegistrationRepository(_context);

        }
        private void MockData()
        {
            var availableRoom = new StudyRoom
            {
                Id = 1,
                Name = "Earth",
                RoomNumber = "A101",
                IsAvailable = true
            };
            _context.StudyRooms.Add(availableRoom);
            _context.SaveChanges();
        }

        [Test]
        public void BookStudyRoom_AvailableRoom_ReturnsBookingId()
        {
            // Arrange

            MockData();

            var bookingDetails = new BookingDetails()
            {
                BookingId = 1,
                FirstName = "Rakesh",
                LastName = "Pernati",
                Email = "rakesh@gmail.com",
                Date = DateTime.Now
            };


            // Act
            var result = _bookingRegistrationRepository.BookStudyRoom(bookingDetails);

            // Assert
            Assert.That(result, Is.EqualTo(bookingDetails.BookingId));

        }


        [Test]
        public void IsAvailable_RoomAvailable_ReturnsRoomDetails()
        {

            // Arrange
            MockData();
            var studyRoom = new StudyRoom
            {
                Id = 1,
                Name = "Earth",
                RoomNumber = "A101",
                IsAvailable = true
            };

            // Act
            var result = _bookingRegistrationRepository.IsRoomAvilable();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsAvailable, Is.EqualTo(studyRoom.IsAvailable));
        }

        [Test]
        public void IsAvailable_NoRoomAvailable_ReturnsNull()
        {


            // Act
            var result = _bookingRegistrationRepository.IsRoomAvilable();

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
