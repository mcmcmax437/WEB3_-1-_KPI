using Hotel_BAL.Interfaces;
using Hotel_DAL.Interfaces;
using Hotel_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_BAL.Interface_Implementation
{

    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

      
        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

   
        public IEnumerable<Booking> GetAllBookings()
        {
            return bookingRepository.GetAllBookings();
        }

    
        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        
        public void AddBooking(Booking booking)
        {
            bookingRepository.AddBooking(booking);
        }

        
        public void DeleteBooking(int id)
        {
            bookingRepository.DeleteBooking(id);
        }

      
        public void Save()
        {
            bookingRepository.Save();
        }

        public Booking GetBookingByRoomId(int id)
        {
            return bookingRepository.GetBookingByRoomId(id);
        }
    }
}

