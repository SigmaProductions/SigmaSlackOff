using System;
using System.Collections.Generic;

namespace sigmaslackoff
{
    public class Room
    {
        public string Id { get; set; }
        public List<User> user { get; set; }
        public string game { get; set; }
        public DateTime time { get; set; }

    }
}