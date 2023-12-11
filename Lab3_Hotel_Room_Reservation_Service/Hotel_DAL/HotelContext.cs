using Hotel_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hotel_DAL
{
    public class HotelContext : DbContext
    {

  
        private const string connectionString = "server=127.0.0.1;user=root;password=Kukimyhund437*;database=HotelDB;port=3306";    
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        // Seeding some initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "101", Type = "Single", Price = 100, Available = true },
                new Room { Id = 2, Name = "102", Type = "Double", Price = 150, Available = true },
                new Room { Id = 3, Name = "103", Type = "Suite", Price = 200, Available = true }               
            );
        }
    }
}

