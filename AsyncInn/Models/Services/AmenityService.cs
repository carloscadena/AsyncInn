using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityService: IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities hotel)
        {
            _context.Amenities.Add(hotel);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAmenity(int id)
        {
            Amenities hotel = await GetAmenity(id);
            _context.Amenities.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task UpdateAmenity(Amenities hotel)
        {
            _context.Amenities.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
