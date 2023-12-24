using Microsoft.AspNetCore.Mvc;
using Hotel_BAL.Interfaces;
using Hotel_DAL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab5_WebApi.Controllers
{ 

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService roomService;
        private readonly IBookingService bookingService;

        public HomeController(ILogger<HomeController> logger, IRoomService roomService, IBookingService bookingService)
        {
            _logger = logger;
            this.roomService = roomService;
            this.bookingService = bookingService;
        }


        [HttpGet("ViewAvailableRooms")]
        public ActionResult<IEnumerable<Room>> ViewAvailableRooms()
        {
            var rooms = roomService.GetAllRooms().Where(r => r.Available).ToList();
            return Ok(rooms);
        }

        [HttpGet("ViewBookedRooms")]
        public ActionResult<IEnumerable<Booking>> ViewBookedRooms()
        {
            var bookings = bookingService.GetAllBookings().ToList();
            return Ok(bookings);
        }
 
        [HttpPost("BookRoom/{roomName}")]
        public async Task<ActionResult> BookRoom(int roomName, [FromBody] Booking booking)
        {
            var room = roomService.GetRoomByNumber(roomName);

            if (room == null)
            {
                return NotFound($"Room with name {roomName} not found.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking2 = new Booking
                    {
                        Id = booking.Id,
                        RoomId = room.Id,
                        CustomerName = booking.CustomerName,
                        CheckIn = booking.CheckIn,
                        CheckOut = booking.CheckOut
                    };
                    bookingService.AddBooking(booking2);
                    bookingService.Save();

                    room.Available = false;
                    roomService.UpdateRoom(room);
                    roomService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return BadRequest(ModelState);
        }


        [HttpPost("AddNewRoom")]
        public IActionResult AddNewRoom([FromBody] Room roomInput)
        {
            if (ModelState.IsValid)
            {
                var room = new Room
                {
                    Name = roomInput.Name,
                    Price = roomInput.Price,
                    Available = roomInput.Available,
                    Type = roomInput.Type
                };

                if (!room.Available)
                {
                    room.Available = true;
                }

                roomService.AddRoom(room);
                return CreatedAtAction(nameof(ViewAvailableRooms), new { id = room.Id }, room);
            }

            return BadRequest(ModelState);
        }




        [HttpPost("CancelReservationByRoom/{roomNumber}")]
        public IActionResult CancelReservationByRoom(int roomNumber)
        {
         
            var room = roomService.GetRoomByNumber(roomNumber);

            if (room == null)
            {
                return NotFound($"No room found with room number {roomNumber}.");
            }
            var booking = bookingService.GetBookingByRoomId(room.Id);

            if (booking == null)
            {
                return NotFound($"No booking found for room number {roomNumber}.");
            }

            bookingService.DeleteBooking(booking.Id);
            bookingService.Save();

            room.Available = true;
            roomService.UpdateRoom(room);
            roomService.Save();

            return Ok($"Reservation for room number {roomNumber} has been canceled.");
        }



        private bool BookingExists(int id)
        {
            return bookingService.GetBookingById(id) != null;
        }
    }
}
