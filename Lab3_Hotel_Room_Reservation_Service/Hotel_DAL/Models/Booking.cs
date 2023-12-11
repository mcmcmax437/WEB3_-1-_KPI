using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotel_DAL.Models
{
    public class Booking
    {
        public int Id { get; set; } 
        public int RoomId { get; set; } 
        public Room Room { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
