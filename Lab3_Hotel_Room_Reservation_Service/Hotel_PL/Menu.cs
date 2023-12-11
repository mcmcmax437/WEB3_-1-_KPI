using Hotel_BAL;
using Hotel_BAL.Interface_Implementation;
using Hotel_DAL.Interface_Imlementation;
using Hotel_DAL;
using Hotel_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_BAL.Interfaces;

namespace Hotel_PL
{
    public class Menu
    {
        public static void StartMainMenu()
        {

            using (var context = new HotelContext())
            {
                bool exit = false;
                context.Database.EnsureCreated();

                var roomService = new RoomService(new RoomRepository(context));
                var bookingService = new BookingService(new BookingRepository(context));

                Console.WriteLine("Welcome to Hotel Booking System");
                while (exit == false)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. View available rooms and prices");
                    Console.WriteLine("2. Book a room");
                    Console.WriteLine("3. View booked rooms");
                    Console.WriteLine("4. Add new room");
                    Console.WriteLine("5. Cancele reservation");
                    Console.WriteLine("6. Exit");

                    var input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            // View available rooms and prices
                            ViewAvailableRooms(roomService);
                            break;
                        case "2":
                            BookRoom(roomService, bookingService);
                            break;
                        case "3":                         
                            ViewBookedRooms(bookingService);
                            break;
                        case "4":
                            AddNewRoom(roomService);
                            break;
                        case "5":
                             CancelReservation(roomService, bookingService);
                            break;
                        case "6":                        
                            Console.WriteLine("Thank you for using Hotel Booking System");
                            exit = true;
                            break;
                        default:                      
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }
        }

     
        public static void ViewAvailableRooms(IRoomService roomService)
        {
           
            var rooms = roomService.GetAllRooms();

           
            Console.WriteLine("Available rooms and prices:");
            foreach (var room in rooms)
            {
                if (room.Available) 
                {
                    Console.WriteLine($"Room {room.Name}, Type: {room.Type}, Price: {room.Price}");
                }
            }
        }


        public static void ViewBookedRooms(IBookingService bookingService)
        {
            // Get all bookings
            var bookings = bookingService.GetAllBookings();

            // Display booking details
            Console.WriteLine("Booked rooms:");
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Room {booking.Room.Name}, Customer: {booking.CustomerName}, Check-in: {booking.CheckIn}, Check-out: {booking.CheckOut}");
            }
        }

        public static void BookRoom(IRoomService roomService, IBookingService bookingService)
        {
            // Get the available rooms and prices
            var rooms = roomService.GetAllRooms().Where(r => r.Available).ToList();

            // Check if there are any available rooms
            if (rooms.Count > 0)
            {
                // Display the available rooms and prices
                Console.WriteLine("Available rooms and prices:");
                foreach (var room in rooms)
                {
                    Console.WriteLine($"Room {room.Name}, Type: {room.Type}, Price: {room.Price}");
                }

                // Prompt the user to enter the booking details
                Console.WriteLine("Please enter the room name:");
                var roomName = Console.ReadLine();
                Console.WriteLine("Please enter the customer name:");
                var customerName = Console.ReadLine();
                Console.WriteLine("Please enter the check-in date (yyyy-mm-dd):");
                var checkIn = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the check-out date (yyyy-mm-dd):");
                var checkOut = DateTime.Parse(Console.ReadLine());

                // Validate the input
                if (checkOut > checkIn && rooms.Any(r => r.Name == roomName))
                {
                    // Create a new booking object
                    var booking = new Booking
                    {
                        RoomId = rooms.First(r => r.Name == roomName).Id,
                        CustomerName = customerName,
                        CheckIn = checkIn,
                        CheckOut = checkOut
                    };

                    // Add the booking to the database
                    bookingService.AddBooking(booking);
                    bookingService.Save();

                    // Update the room availability
                    var room = roomService.GetRoomById(booking.RoomId);
                    room.Available = false;
                    roomService.UpdateRoom(room);
                    roomService.Save();

                    // Display the booking confirmation
                    Console.WriteLine("Booking confirmed:");
                    Console.WriteLine($"Room {booking.Room.Name}, Customer: {booking.CustomerName}, Check-in: {booking.CheckIn}, Check-out: {booking.CheckOut}");
                }
                else
                {
                    // Display the error message
                    Console.WriteLine("Invalid input");
                }
            }
            else
            {
                // Display the message that there are no available rooms
                Console.WriteLine("No rooms available");
            }
        }


        
        public static void AddNewRoom(IRoomService roomService)
        {
            Console.WriteLine("Please enter the room details:");
            Console.WriteLine("Room Name:");
            var roomName = Console.ReadLine();
            Console.WriteLine("Room Type (Single/Double/Suite):");
            var roomType = Console.ReadLine();
            Console.WriteLine("Room Price per Night:");
            var roomPrice = decimal.Parse(Console.ReadLine());

         
            var newRoom = new Room
            {
                Name = roomName,
                Type = roomType,
                Price = roomPrice,
                Available = true
            };       
           // var existingRoom = roomService.GetRoomById(newRoom.Id);
         
                roomService.AddRoom(newRoom);
                roomService.Save();

                Console.WriteLine($"New room added successfully: Room {newRoom.Name}, Type: {newRoom.Type}, Price: {newRoom.Price}");

        }
        public static void CancelReservation(IRoomService roomService, IBookingService bookingService)
        {
            Console.WriteLine("Please enter the booking ID to cancel:");
            var bookingId = int.Parse(Console.ReadLine());

            // Get the booking by ID
            var booking = bookingService.GetBookingById(bookingId);

            if (booking != null)
            {
                // Update the room availability
                var room = roomService.GetRoomById(booking.RoomId);
                room.Available = true;
                roomService.UpdateRoom(room);
                roomService.Save();

                // Delete the booking from the database
                bookingService.DeleteBooking(bookingId);
                bookingService.Save();

                Console.WriteLine("Reservation canceled successfully.");
            }
            else
            {
                Console.WriteLine("Invalid booking ID. No reservation found.");
            }
        }
        
    }
}


