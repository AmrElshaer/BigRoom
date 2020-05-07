using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigRoom.Models
{
    public class Group
    {
        public Group()
        {
            Groups = new HashSet<UserGroups>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "CodeJoin")]

        public string CodeJion { get; set; }
        [Required]
        [Display(Name = "Name")]
        [Remote(action: "GroupNameUNiqe", controller: "Groups", ErrorMessage = "Name Groups is Exits Please Enter another Email")]
        public string Name { get; set; }
        public ICollection<Quize> quizes { get; set; }

        public ICollection<UserGroups> Groups { get; set; }
        public string AdminId { get; set; }
        public User Admin { get; set; }
    }
}
