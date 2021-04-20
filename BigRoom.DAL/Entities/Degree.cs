using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Model.Entities
{
    public class Degree:Entity
    {
        public Quize Quize { get; set; }
        public int QuizeId { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int ExamDegree { get; set; }
        public int TotalDegree { get; set; }
    }
}
