using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
namespace BigRoom.Model.Entities
{
    public class Quize : AuditableEntity
    {
        public Quize()
        {
            Degrees = new HashSet<Degree>();
        }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<GroupPermission> GroupPermissions { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string Fileanswer { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime TimeStart { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}