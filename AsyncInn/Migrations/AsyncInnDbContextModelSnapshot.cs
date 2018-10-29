﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { ID = 1, Name = "Fireplace" },
                        new { ID = 2, Name = "Sauna" },
                        new { ID = 3, Name = "Hot Tub" },
                        new { ID = 4, Name = "Free PPV" },
                        new { ID = 5, Name = "Open Bar" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Hotel");

                    b.HasData(
                        new { ID = 1, Address = "1 Hotel Street", Name = "Hotel 1", Phone = "233-566-7087" },
                        new { ID = 2, Address = "2 Hotel Street", Name = "Hotel 2", Phone = "555-555-5555" },
                        new { ID = 3, Address = "3 Hotel Street", Name = "Hotel 3", Phone = "111-222-3333" },
                        new { ID = 4, Address = "4 Hotel Street", Name = "Hotel 4", Phone = "444-444-4444" },
                        new { ID = 5, Address = "5 Hotel Street", Name = "Hotel 5", Phone = "123-123-1234" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("HotelID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomNumber");

                    b.HasKey("RoomID", "HotelID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Room");

                    b.HasData(
                        new { ID = 1, Layout = 0, Name = "Funroom" },
                        new { ID = 2, Layout = 1, Name = "Sunroom" },
                        new { ID = 3, Layout = 2, Name = "BunRoom" },
                        new { ID = 4, Layout = 0, Name = "Nunroom" },
                        new { ID = 5, Layout = 1, Name = "Punroom" },
                        new { ID = 6, Layout = 2, Name = "Stunroom" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("AmenitiesID");

                    b.HasKey("RoomID", "AmenitiesID");

                    b.HasIndex("AmenitiesID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
