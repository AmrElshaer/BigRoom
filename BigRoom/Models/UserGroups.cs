using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Models
{
    public class UserGroups
    {
        
        public string UserName { get; set; }
        public User user { get; set; }

        
        
        [Remote(action: "GroupJoinUniqe", controller: "UserGroups", ErrorMessage = "CodeJoin Groups is Not Exits Please Enter another CodeJoin")]
        public string CodeJoin { get; set; }
        public Group group { get; set; }
    }
}
