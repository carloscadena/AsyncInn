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


    }
}
