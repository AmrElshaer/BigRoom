using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Entities
{
    public class Group: AuditableEntity
    {
        public Group()
        {
            Groups = new HashSet<UserGroups>();
        }
        public string CodeJion { get; set; }
        public string Name { get; set; }
        public ICollection<Quize> Quizes { get; set; }
        public ICollection<UserGroups> Groups { get; set; }
        public int AdminId { get; set; }
        public UserProfile Admin { get; set; }
    }
}
