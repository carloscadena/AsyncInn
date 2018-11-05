using System;
using Xunit;
using AsyncInn;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using System.Linq;

namespace AsyncInnTest
{
    public class UnitTest1
    {
        [Fact]
        public void CorrectRoomNameTest()
        {
            Room room = new Room();
            room.Name = "roomroom";
            Assert.True("roomroom" == room.Name);
        }

        [Fact]
        public void ChangeRoomNameTest()
        {
            Room room = new Room();
            room.Name = "roomroom";
            room.Name = "rooom";
            Assert.Equal("rooom", room.Name);
        }

        [Fact]
        public async void CRUDRoomTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Room")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                Room room = new Room();
                room.Name = "roomroom";
                room.Layout = Layout.Studio;

                context.Room.Add(room);
                context.SaveChanges();

                //READ
                var myRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == room.Name);
                Assert.Equal("roomroom", myRoom.Name);

                //UPDATE
                myRoom.Name = "blah";
                context.Update(myRoom);
                context.SaveChanges();

                var newRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == myRoom.Name);
                Assert.Equal("blah", newRoom.Name);

                //DELETE
                context.Room.Remove(newRoom);
                context.SaveChanges();

                var deletedRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == newRoom.Name);
                Assert.True(deletedRoom == null);
            }
        }

        [Fact]
        public void ReturnCorrectAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Free water";

            Assert.Equal("Free water", amenity.Name);
        }
        
        [Fact]
        public void ChangeAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Free water";

            amenity.Name = "Free TP";

            Assert.Equal("Free TP", amenity.Name);
        }
        
        [Fact]
        public async void CRUDAmenitiesTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Amenity")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                Amenities amenity = new Amenities();
                amenity.Name = "BBQ";
                context.Amenities.Add(amenity);
                context.SaveChanges();

                //READ
                var myAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == amenity.Name);
                Assert.Equal("BBQ", myAmenity.Name);


                //UPDATE
                myAmenity.Name = "Free Beer";
                context.Update(myAmenity);
                context.SaveChanges();
                var newAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == myAmenity.Name);
                Assert.Equal("Free Beer", newAmenity.Name);

                //DELETE
                context.Amenities.Remove(newAmenity);
                context.SaveChanges();
                var deletedAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == newAmenity.Name);
                Assert.True(deletedAmenity == null);
            }
        }

        [Fact]
        public void ReturnCorrectHotelNameTest()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "hotelhotel";

            Assert.Equal("hotelhotel", hotel.Name);
        }
        
        [Fact]
        public void ChangeHotelNameTest()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "hotelhotel";
            hotel.Name = "hotelzz";

            Assert.Equal("hotelzz", hotel.Name);
        }
        
        [Fact]
        public async void CRUDHotelTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Hotel")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                Hotel hotel = new Hotel();
                hotel.Name = "The Prancing Pony";
                hotel.Phone = "(425)333-9090";
                hotel.Address = "Pony St.";
                context.Hotel.Add(hotel);
                context.SaveChanges();

                //READ
                var myHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == hotel.Name);

                Assert.Equal("The Prancing Pony", myHotel.Name);


                //UPDATE
                myHotel.Name = "The Thundering Horses";
                context.Update(myHotel);
                context.SaveChanges();
                var newHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == myHotel.Name);
                Assert.Equal("The Thundering Horses", newHotel.Name);

                //DELETE
                context.Hotel.Remove(newHotel);
                context.SaveChanges();
                var deletedHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == newHotel.Name);
                Assert.True(deletedHotel == null);
            }
        }

        [Fact]
        public void ReturnCorrectHotelRoomTest()
        {
            HotelRoom myHotelRoom = new HotelRoom();
            myHotelRoom.HotelID = 1;
            myHotelRoom.RoomID = 1;
            myHotelRoom.Rate = 100;
            myHotelRoom.RoomNumber = 13;

            Assert.Equal(1, myHotelRoom.HotelID);
        }
        
        [Fact]
        public void CanChangeHotelRoomsTest()
        {
            HotelRoom myHotelRoom = new HotelRoom();
            myHotelRoom.HotelID = 1;
            myHotelRoom.RoomID = 1;
            myHotelRoom.Rate = 100;
            myHotelRoom.RoomNumber = 13;

            myHotelRoom.RoomNumber = 10;

            Assert.Equal(10, myHotelRoom.RoomNumber);
        }
        
        [Fact]
        public async void HotelRoomsCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("HotelRoom")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                HotelRoom myHotelRoom = new HotelRoom();
                myHotelRoom.HotelID = 1;
                myHotelRoom.RoomID = 1;
                myHotelRoom.RoomNumber = 13;
                myHotelRoom.Rate = 100;
                context.Add(myHotelRoom);
                context.SaveChanges();

                //READ
                var newHotelRoom = await context.HotelRoom.FirstOrDefaultAsync(hr => hr.HotelID == myHotelRoom.HotelID && hr.RoomID == myHotelRoom.RoomID);

                Assert.Equal(100, myHotelRoom.Rate);
                Assert.Equal(1, myHotelRoom.HotelID);

                //UPDATE
                newHotelRoom.Rate = 150;
                context.Update(newHotelRoom);
                context.SaveChanges();

                var changeHotelRoom = await context.HotelRoom.FirstOrDefaultAsync(hr => hr.HotelID == newHotelRoom.HotelID && hr.RoomID == newHotelRoom.RoomID);
                Assert.Equal(150, changeHotelRoom.Rate);

                //DELETE
                context.HotelRoom.Remove(changeHotelRoom);
                context.SaveChanges();
                var deletedHotelRoom = await context.HotelRoom.FirstOrDefaultAsync(hr => hr.HotelID == changeHotelRoom.HotelID && hr.RoomID == changeHotelRoom.RoomID);
                Assert.True(deletedHotelRoom == null);
            }
        }
    }
}
