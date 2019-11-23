using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace matcher
{
    public class Room
    {
        public Room()
        {
            this.time = DateTime.Now;
            //users = new Collection<User>();
        }

        public int Id { get; set; }
        public string game { get; set; }
        public DateTime time { get; set; }

    }
}