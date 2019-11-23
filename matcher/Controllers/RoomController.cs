using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matcher.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoomController()
        {
            _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        }

        [HttpGet]
        [Route("getrooms")]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.Rooms.ToList());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoom(Room room)
        {
            room.Id = (_context.Rooms.Count<Room>() + 1).ToString();
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("assignUser")]
        public async Task<IActionResult> AssignUser(string roomId, string userId)
        {
            var room = _context.Rooms.Find(roomId);
            var user = _context.Users.Find(userId);
            if (room == null){
                return NotFound("Room not found");
            }
            if (user == null)
            {
                return NotFound("User not found");
            }
            user.room = room;
            room.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
