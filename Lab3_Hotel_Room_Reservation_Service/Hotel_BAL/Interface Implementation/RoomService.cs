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
 
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository; 

        
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return roomRepository.GetAllRooms();
        }


        public Room GetRoomById(int id)
        {
            return roomRepository.GetRoomById(id);
        }


        public void UpdateRoom(Room room)
        {
            roomRepository.UpdateRoom(room);
        }

     
        public void Save()
        {
            roomRepository.Save();
        }
    }
}
