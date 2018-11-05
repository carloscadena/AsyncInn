using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        Task CreateAmenity(Amenities amenity);

        Task UpdateAmenity(Amenities amenity);

        Task DeleteAmenity(int id);

        Task<List<Amenities>> GetAmenities();

        Task<Amenities> GetAmenity(int? id);
    }
}
