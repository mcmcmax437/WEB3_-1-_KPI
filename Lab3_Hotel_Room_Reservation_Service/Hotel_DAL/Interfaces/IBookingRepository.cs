using Hotel_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DAL.Interfaces
{
    
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings(); 
        Booking GetBookingById(int id); 
        void AddBooking(Booking booking); 
        void DeleteBooking(int id); 
        void Save();
        Booking GetBookingByRoomId(int id);
    }
}
