using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace sigmaslackoff
{
    public class Room
    {
        public Room()
        {
            this.time = DateTime.Now;
            users = new Collection<User>();
        }

        public string Id { get; set; }
        public ICollection<User> users { get; set; }
        public string game { get; set; }
        public DateTime time { get; set; }

    }
}