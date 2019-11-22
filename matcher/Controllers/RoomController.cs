using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sigmaslackoff.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        public RoomController()
        {

        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AssignUser(Room room, User user)
        {
            return Ok();
        }

    }
}
