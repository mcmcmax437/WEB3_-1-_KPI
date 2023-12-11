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
    public class RoomRepository : IRoomRepository
    {
        private HotelContext context;

        public RoomRepository(HotelContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return context.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            return context.Rooms.Find(id);
        }

        public void UpdateRoom(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
        }

        public void AddRoom(Room room)
        {                          
                context.Entry(room).State = EntityState.Added;
                context.SaveChanges();
        }



        public void Save()
        {
            context.SaveChanges();
        }
    }
}
