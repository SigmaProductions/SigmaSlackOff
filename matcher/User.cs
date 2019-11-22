using System.ComponentModel.DataAnnotations;
using System;

namespace sigmaslackoff
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string name { get; set; }
        
        [Required]
        public string password { get; set; }

        public Room room { get; set; }
    }
}