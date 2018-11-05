using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        //Create
        Task CreateRoom(Room room);

        //Update
        Task UpdateRoom(Room room);

        //Delete
        Task DeleteRoom(int id);

        //Read all
        Task<IEnumerable<Room>> GetRooms();

        //Read one
        Task<Room> GetRoom(int? id);
    }
}