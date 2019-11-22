using System;
using System.Collections.Generic;

namespace sigmaslackoff
{
    public class Room
    {
        public List<User> user { get; set; }
        public string game { get; set; }
        public DateTime time { get; set; }

    }
}