using System;
using System.Collections.Generic;
using System.Text;
using BigRoom.Repository.Entities;
using Microsoft.AspNetCore.Identity;

namespace BigRoom.Repository.Contexts
{
    public class ApplicationUser: IdentityUser
    {
        public string Image { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}
