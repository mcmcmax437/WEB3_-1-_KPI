using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_DAL.Models;

namespace Hotel_DAL.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAllRooms(); 
        Room GetRoomById(int id); 
        void UpdateRoom(Room room); 
        void AddRoom(Room room);
        void Save();
        Room GetRoomByNumber(int roomNumber);
    }
}
