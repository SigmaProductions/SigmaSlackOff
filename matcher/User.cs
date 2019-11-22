using System.ComponentModel.DataAnnotations;
using System;

namespace sigmaslackoff
{
    public class User
    {
        [Required]
        public string name { get; set; }
        
        [Required]
        public string password { get; set; }

        public Room room { get; set; }
    }
}