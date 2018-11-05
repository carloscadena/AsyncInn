﻿using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = await GetAmenity(id);
            _context.Amenities.Remove(amenity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.Amenities.Update(amenity);
            await _context.SaveChangesAsync();
        }
    }
}