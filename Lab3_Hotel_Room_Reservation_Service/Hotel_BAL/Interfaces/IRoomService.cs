using Hotel_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_BAL.Interfaces
{
  
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms(); 
        Room GetRoomById(int id); 
        void UpdateRoom(Room room); 
        void AddRoom(Room room);

        void Save();
        Room GetRoomByNumber(int roomNumber);
    }
}
