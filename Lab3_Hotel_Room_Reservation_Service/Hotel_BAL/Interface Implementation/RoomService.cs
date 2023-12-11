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

        public void AddRoom(Room room)
        {          
            var existingRoom = roomRepository.GetAllRooms().FirstOrDefault(r => r.Name == room.Name);

            if (existingRoom == null)
            {          
                roomRepository.AddRoom(room);
                roomRepository.Save();
            }
            else
            {              
                Console.WriteLine($"Room with name {room.Name} already exists.");
            }
        }

        public void Save()
        {
            roomRepository.Save();
        }
    }
}
