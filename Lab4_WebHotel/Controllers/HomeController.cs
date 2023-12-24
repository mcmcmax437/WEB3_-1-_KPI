using Hotel_BAL.Interface_Implementation;
using Hotel_BAL.Interfaces;
using Hotel_DAL.Models;
using Lab4_WebHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab4_WebHotel.Controllers
{
    public class HomeController : Controller
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

        // GET: Home/ViewAvailableRooms
        public IActionResult ViewAvailableRooms()
        {
            var rooms = roomService.GetAllRooms().Where(r => r.Available).ToList();
            return View(rooms);
        }

        // GET: Home/ViewBookedRooms
        public IActionResult ViewBookedRooms()
        {
            var bookings = bookingService.GetAllBookings().ToList();
            return View(bookings);
        }
        // GET: /Home/BookRoom/
        public async Task<IActionResult> BookRoom(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var room = roomService.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            var booking = new Booking
            {
                RoomId = room.Id,
                Room = room
            };

            return View(booking);
        }

        // POST: /Home/BookRoom/
        [HttpPost, ActionName("BookRoom")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookRoom(int id, [Bind("Id,Room,RoomId,CustomerName,CheckIn,CheckOut")] Booking booking)
        {
            if (id != booking.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking2 = new Booking
                    {
                        Id = booking.Id,
                        RoomId = booking.RoomId,
                        CustomerName = booking.CustomerName,
                        CheckIn = booking.CheckIn,
                        CheckOut = booking.CheckOut
                    };
                    bookingService.AddBooking(booking2);
                     bookingService.Save();

                    var room = roomService.GetRoomById(booking.RoomId);
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
            return View(booking);
        }

        private bool BookingExists(int id)
        {
            return bookingService.GetBookingById(id) != null;
        }
    
        // GET: Home/AddNewRoom
        public IActionResult AddNewRoom()
        {
            return View();
        }

        // POST: Home/AddNewRoom
        [HttpPost, ActionName("AddNewRoom")]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewRoom([Bind("Id,Name,Price,IsAvailable,Type")] Room room)
        {
            if (ModelState.IsValid)
            {
                if (!room.Available)
                {
                    room.Available = true;
                }

                roomService.AddRoom(room);
                return RedirectToAction(nameof(ViewAvailableRooms));
            }
            return View(room);
        }

        // GET: Home/CancelReservation/5
        public IActionResult CancelReservation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingService.GetBookingById(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Home/CancelReservation/5
        [HttpPost, ActionName("CancelReservation")]
        [ValidateAntiForgeryToken]
        public IActionResult CancelReservationConfirmed(int id)
        {
            var booking = bookingService.GetBookingById(id);
            bookingService.DeleteBooking(id);
            bookingService.Save();

            var room = roomService.GetRoomById(booking.RoomId);
            room.Available = true;
            roomService.UpdateRoom(room);
            roomService.Save();

            return RedirectToAction(nameof(ViewAvailableRooms));
        }

        

        private bool RoomExists(int id)
        {
            return roomService.GetRoomById(id) != null;
        }
    }
}

