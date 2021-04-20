using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Entities
{
    public  class UserGroups:Entity
    {
        public UserProfile UserProfile { get; set; }
        public int? UserProfileId { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
