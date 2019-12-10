using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Models
{
    public class Quize
    {
        public int id { get; set; }
        public string file { get; set; }
        public string fileanswer { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="TimeStart")]
        
        public DateTime TimeStart { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "TimeEnd")]
       
        public DateTime TimeEnd { get; set; }
        public string GroupId { get; set; }
        
        public Group Group { get; set; }
        public ICollection<Degree> Usersfquize { get; set; }
    }
}
