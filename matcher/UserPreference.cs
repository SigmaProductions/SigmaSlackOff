using matcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matcher
{
    public class UserPreference
    {
        public UserPreference()
        {
            this.time = DateTime.Now;
        }
        public int Id { get; set; }
        public string game { get; set; }
        public DateTime time { get; set; }
    }
}
