using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Common
{
    public abstract class AuditableEntity:Entity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
