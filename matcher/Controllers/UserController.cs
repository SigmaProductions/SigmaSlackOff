using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sigmaslackoff.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController()
        {
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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
