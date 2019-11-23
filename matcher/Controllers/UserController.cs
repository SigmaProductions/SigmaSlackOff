using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matcher.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matcher.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IHubContext<HomeHub> _hubContext;
        private readonly ApplicationDbContext _context;
        public UserController(IHubContext<HomeHub> hubContext)
        {
            this._hubContext = hubContext;
            _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        }

        [HttpGet]
        [Route("getusers")]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.Users.ToList());
        }
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string id, string pw)
        {
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
            user.Id = (_context.Users.Count<User>() + 1).ToString();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPut]
        [Route("assignpreference")]
        public async Task<IActionResult> AssignPreference(string preferenceId, string userId)
        {
            var preference = _context.UserPreferences.Find(preferenceId);
            var user = _context.Users.Find(userId);
            if (preference == null)
            {
                return NotFound("Preference not found");
            }
            if (user == null)
            {
                return NotFound("User not found");
            }
            preference.user = user;
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
