using BigRoom.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Entities
{
    public  class UserGroups:Entity
    {
        public UserProfile UserProfile { get; set; }
        public int? UserProfileId { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
