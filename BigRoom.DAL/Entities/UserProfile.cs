using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Entities
{
    public class UserProfile:Entity
    {
        public UserProfile()
        {
            Degrees = new HashSet<Degree>();
            Groups = new HashSet<UserGroups>();
            GroupsThatAdmin = new HashSet<Group>();
            QuizesCreate = new HashSet<Quize>();
        }
        public string UserId { get; set; }
        public ICollection<Degree> Degrees { get; set; }
        public ICollection<UserGroups> Groups { get; set; }
        public ICollection<Group> GroupsThatAdmin { get; set; }
        public ICollection<Quize> QuizesCreate { get; set; }
        public ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
