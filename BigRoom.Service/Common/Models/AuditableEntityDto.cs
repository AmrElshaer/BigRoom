using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Common.Models
{
    public class AuditableEntityDto:EntityDto
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
