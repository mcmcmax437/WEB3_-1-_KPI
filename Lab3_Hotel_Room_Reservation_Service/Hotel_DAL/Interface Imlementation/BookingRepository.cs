using Hotel_DAL.Interfaces;
using Hotel_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DAL.Interface_Imlementation
{

    public class BookingRepository : IBookingRepository
    {
        private HotelContext context; 

        public BookingRepository(HotelContext context)
        {
            this.context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return context.Bookings.Include(b => b.Room).ToList();
        }

        public Booking GetBookingById(int id)
        {
            return context.Bookings.Include(b => b.Room).FirstOrDefault(b => b.Id == id);
        }

        public void AddBooking(Booking booking)
        {
            context.Bookings.Add(booking);
        }

        public void DeleteBooking(int id)
        {
            Booking booking = context.Bookings.Find(id);
            context.Bookings.Remove(booking);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

