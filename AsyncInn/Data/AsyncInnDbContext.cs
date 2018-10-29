﻿using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext 
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base (options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Recognizes Composite Keys
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.RoomID, ce.AmenitiesID }
                );

            modelBuilder.Entity<HotelRoom>().HasKey(
                ce => new { ce.RoomID, ce.HotelID }
                );
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
