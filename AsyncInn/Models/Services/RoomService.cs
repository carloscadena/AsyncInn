using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Room.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }

        //HotelRoom Methods
        public async Task<HotelRoom> GetHotelRoom(int? id)
        {
            return await _context.HotelRoom.FirstOrDefaultAsync(x => x.RoomID == id);
        }

        public IEnumerable<HotelRoom> GetHotelRoomsByRoom(int roomID)
        {
            var hotelRoom = _context.HotelRoom
                .Where(x => x.RoomID == roomID)
                .Include(h => h.Hotel)
                .Include(h => h.Room);

            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            var asyncInnDbContext = _context.HotelRoom.Include(h => h.Hotel).Include(h => h.Room);
            return await asyncInnDbContext.ToListAsync();
        }

        public async Task CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Update(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelRoom(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(HotelID, RoomNumber);
            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }
    }
}
