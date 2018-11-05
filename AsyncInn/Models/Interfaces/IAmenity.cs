using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        //Create
        Task CreateAmenity(Amenities amenity);

        //Update
        Task UpdateAmenity(Amenities amenity);

        //Delete
        Task DeleteAmenity(int id);

        //Read all
        Task<IEnumerable<Amenities>> GetAmenities();

        //Read one
        Task<Amenities> GetAmenity(int? id);
    }
}