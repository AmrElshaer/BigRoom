using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Entities
{
    public class GroupPermission:AuditableEntity
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int? QuizeId { get; set; }
        public Quize Quize { get; set; }
        public bool Edit{ get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
    }
}
