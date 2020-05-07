using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigRoom.Models
{
    public class Quize
    {
        public int id { get; set; }
        public string file { get; set; }
        public string fileanswer { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "TimeStart")]

        public DateTime TimeStart { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "TimeEnd")]

        public DateTime TimeEnd { get; set; }
        public int GroupId { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public Group Group { get; set; }
        public ICollection<Degree> Usersfquize { get; set; }
        public string Description { get; set; }
    }
}
