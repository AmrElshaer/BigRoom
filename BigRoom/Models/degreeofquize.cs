using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Models
{
    public class degreeofquize
    {
        public int id { get; set; }
        public int degree { get; set; }
        public string quizeid { get; set; }
        public Quize quize { get; set; }
        public string userid { get; set; }
        public User users { get; set; }
    }
}
