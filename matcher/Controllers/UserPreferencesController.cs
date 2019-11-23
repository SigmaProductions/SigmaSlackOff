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
        private readonly ApplicationDbContext _context;

        public UserPreferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.UserPreferences.ToList());
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPreference(UserPreference preference)
        {
            preference.Id = (_context.UserPreferences.Count<UserPreference>() + 1).ToString();
            _context.UserPreferences.Add(preference);
            await _context.SaveChangesAsync();
            return Ok();

        }
        private bool UserPreferenceExists(string id)
        {
            return _context.UserPreferences.Any(e => e.Id == id);
        }
    }
}
