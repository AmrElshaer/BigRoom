using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Models
{
    public class User:IdentityUser
    {
        public string Image { get; set; }
        public ICollection<Degree> userquizes { get; set; }
        public ICollection<UserGroups> Groups { get; set; }
    }
}
