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
        public RoomController()
        {
        }

        [HttpGet]
        [Route("getrooms")]
        public async Task<IActionResult> Get()
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());

            return Ok(_context.Rooms.ToList());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoom(Room room)
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("assignUser")]
        public async Task<IActionResult> AssignUser(int roomId, int userId)
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var room = _context.Rooms.FirstOrDefault(x => x.Id == roomId);
            var user = _context.Users.FirstOrDefault(x=> x.Id == userId);
            if (room == null){
                return NotFound("Room not found");
            }
            if (user == null)
            {
                return NotFound("User not found");
            }
            user.room = room;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
