using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext 
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base (options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Recognizes Composite Keys
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.RoomID, ce.AmenitiesID }
                );

            modelBuilder.Entity<HotelRoom>().HasKey(
                ce => new { ce.RoomID, ce.HotelID }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Hotel 1",
                    Address = "1 Hotel Street",
                    Phone = "233-566-7087"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hotel 2",
                    Address = "2 Hotel Street",
                    Phone = "555-555-5555"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Hotel 3",
                    Address = "3 Hotel Street",
                    Phone = "111-222-3333"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Hotel 4",
                    Address = "4 Hotel Street",
                    Phone = "444-444-4444"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel 5",
                    Address = "5 Hotel Street",
                    Phone = "123-123-1234"
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Funroom",
                    Layout = Layout.Studio,
                },
                new Room
                {
                    ID = 2,
                    Name = "Sunroom",
                    Layout = Layout.OneBedroom,
                },
                new Room
                {
                    ID = 3,
                    Name = "BunRoom",
                    Layout = Layout.TwoBedroom,
                },
                new Room
                {
                    ID = 4,
                    Name = "Nunroom",
                    Layout = Layout.Studio,
                },
                new Room
                {
                    ID = 5,
                    Name = "Punroom",
                    Layout = Layout.OneBedroom,
                },
                new Room
                {
                    ID = 6,
                    Name = "Stunroom",
                    Layout = Layout.TwoBedroom,
                }
            );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Fireplace",
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Sauna",
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Hot Tub",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Free PPV",
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Open Bar",
                }
            );
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
