using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task CreateRoom(Room room);

        Task UpdateRoom(Room room);

        Task DeleteRoom(int id);

        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int? id);

        //HotelRoom Methods
        Task<List<HotelRoom>> GetHotelRooms();

        Task<HotelRoom> GetHotelRoom(int? id);

        IEnumerable<HotelRoom> GetHotelRoomsByRoom(int roomID);

        Task CreateHotelRoom(HotelRoom hotelRoom);

        Task UpdateHotelRoom(HotelRoom hotelRoom);

        Task DeleteHotelRoom(int HotelID, int RoomNumber);
    }
}
