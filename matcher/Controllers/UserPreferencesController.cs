using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using matcher;

namespace matcher.Controllers
{
    [Route("api/[controller]")]
    public class UserPreferencesController : Controller
    {

        public UserPreferencesController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            var users = await _context.Users.ToListAsync();
            return Ok(_context.UserPreferences.ToList());
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPreference(UserPreference preference)
        {
            var _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            var users = await _context.Users.ToListAsync();
            preference.Id = (_context.UserPreferences.Count<UserPreference>() + 1);
            _context.UserPreferences.Add(preference);
            await _context.SaveChangesAsync();
            return Ok();

        }
        private async Task<bool> UserPreferenceExists(int id)
        {
            var _context = new ApplicationDbContext(
                new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
            var rooms = await _context.Rooms.ToListAsync();
            var users = await _context.Users.ToListAsync();
            return _context.UserPreferences.Any(e => e.Id == id);
        }
    }
}
