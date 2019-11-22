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
        public UserController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()//IEnumerable<User> GetUsers()
        {
            //return from i in users
            //       select i;
            return Ok("jsjsjsjjsjs");
        }
        [Route("getusers")]
        public async Task<IActionResult> Get()//string Get(string name)
        {
            //return from i in users
            //      where name = i.name
            //      select i;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            return Ok();

        }
        
        //[HttpPost]
        //public void CreateRoom(Room room)
        //{

        //}
    }
}
