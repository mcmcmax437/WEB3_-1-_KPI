using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotel_DAL.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Type { get; set; } 
        public decimal Price { get; set; } 
        public bool Available { get; set; } 
        public ICollection<Booking> Bookings { get; set; } 
    }
}
