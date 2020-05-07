using Microsoft.AspNetCore.Mvc;

namespace BigRoom.Models
{
    public class UserGroups
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public User user { get; set; }
        public string userId { get; set; }
        public int groupId { get; set; }



        [Remote(action: "GroupJoinUniqe", controller: "UserGroups", ErrorMessage = "CodeJoin Groups is Not Exits Please Enter another CodeJoin")]
        public string CodeJoin { get; set; }
        public Group group { get; set; }
    }
}
