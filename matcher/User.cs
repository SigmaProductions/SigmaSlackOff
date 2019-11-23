using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace matcher
{
    public class User
    {
        public User()
        {
            preferences = new Collection<UserPreference>();
        }

        public string Id { get; set; }
        public string name { get; set; }
        
        public string password { get; set; }

        public Room room { get; set; }
        public ICollection<UserPreference> preferences { get; set; }

    }
}