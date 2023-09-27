using Microsoft.EntityFrameworkCore;
using StudyRoomBooking.Models.DomainModels;

namespace StudyRoomBooking.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Db set properties
        public DbSet<StudyRoom> StudyRooms { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 1,
                    Name = "Earth",
                    RoomNumber = "A101",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 2,
                    Name = "Neptune",
                    RoomNumber = "A102",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 3,
                    Name = "Mercury",
                    RoomNumber = "A103",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 4,
                    Name = "Saturn",
                    RoomNumber = "A201",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 5,
                    Name = "Uranus",
                    RoomNumber = "A202",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 6,
                    Name = "Mars",
                    RoomNumber = "A203",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 7,
                    Name = "Venus",
                    RoomNumber = "A301",
                    IsAvailable = true
                }
            );
            modelBuilder.Entity<StudyRoom>().HasData(
                new StudyRoom
                {
                    Id = 8,
                    Name = "Jupiter",
                    RoomNumber = "A302",
                    IsAvailable = true
                }
            );
        }
    }
}
