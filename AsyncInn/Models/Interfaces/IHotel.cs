using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        //Create
        Task CreateHotel(Hotel hotel);

        //Update
        Task UpdateHotel(Hotel hotel);

        //Delete
        Task DeleteHotel(int id);

        //Read all
        Task<IEnumerable<Hotel>> GetHotels();

        //Read one
        Task<Hotel> GetHotel(int? id);
    }
}