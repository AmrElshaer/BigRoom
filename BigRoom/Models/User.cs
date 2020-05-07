using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BigRoom.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            userquizes = new HashSet<Degree>();
            Groups = new HashSet<UserGroups>();
            GroupsThatAdmin = new HashSet<Group>();
        }
        public string Image { get; set; }
        public ICollection<Degree> userquizes { get; set; }
        public ICollection<UserGroups> Groups { get; set; }
        public ICollection<Group> GroupsThatAdmin { get; set; }
    }
}
