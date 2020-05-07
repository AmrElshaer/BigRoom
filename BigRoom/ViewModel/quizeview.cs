using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigRoom.ViewModel
{
    public class quizeview
    {

        public int id { get; set; }
        [Required]
        [Remote(action: "filequestion", controller: "Quizes", ErrorMessage = "File Must Extention .csv")]
        public IFormFile file { get; set; }
        [Remote(action: "filequestionanswer", controller: "Quizes", ErrorMessage = "File Must Extention .txt")]
        public IFormFile fileanswer { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "TimeStart")]

        public DateTime TimeStart { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "TimeEnd")]

        public DateTime TimeEnd { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public string Description { get; set; }
        public string Groupid { get; set; }


    }
}
