using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matcher.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matcher.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IHubContext<HomeHub> _hubContext;
        public UserController(IHubContext<HomeHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("getusers")]
        public async Task<IActionResult> Get()
        {
            var _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            await _context.UserPreferences.ToListAsync();
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string id, string pw)
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            await _context.UserPreferences.ToListAsync();
            var users = await _context.Users.ToListAsync();
            var user = _context.Users.Find(id);
            if (user.password == pw)
            {
                return Ok();
            }
            return Conflict("Bad password");
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser(User user)
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());

            //user.Id = (_context.Users.Count<User>() + 1).ToString();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPut]
        [Route("assignpreference")]
        public async Task<IActionResult> AssignPreference(int preferenceId, int userId)
        {
            var _context = new ApplicationDbContext(
               new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            var users = await _context.Users.ToListAsync();
            var preference = _context.UserPreferences.FirstOrDefault(x=> x.Id == preferenceId);
            var user = _context.Users.FirstOrDefault(x=> x.Id == userId);
            if (preference == null)
            {
                return NotFound("Preference not found");
            }
            if (user == null)
            {
                return NotFound("User not found");
            }
            //preference.user = user;
            user.preferences.Add(preference);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("resetall")]
        public async Task<IActionResult> Reset()
        {
            await _hubContext.Clients.All.SendAsync("HideWindows");
            return Ok();
        }
    }
}
