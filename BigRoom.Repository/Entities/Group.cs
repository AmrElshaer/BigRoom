using BigRoom.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Entities
{
    public class Group: AuditableEntity
    {
        public Group()
        {
            Groups = new HashSet<UserGroups>();
            GroupPermissions = new HashSet<GroupPermission>();
        }
        public string CodeJion { get; set; }
        public string Name { get; set; }
        public ICollection<Quize> Quizes { get; set; }
        public ICollection<UserGroups> Groups { get; set; }
        public ICollection<GroupPermission> GroupPermissions { get; set; }
        public int AdminId { get; set; }
        public UserProfile Admin { get; set; }
    }
}
