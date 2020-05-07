using Microsoft.AspNetCore.Identity;

namespace BigRoom.Helper
{
    public class SeedRole
    {
        public static void SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!(roleManager.RoleExistsAsync("Teacher").Result))
            {
                roleManager.CreateAsync(new IdentityRole { Id = "1", Name = "Teacher" });
            }
            if (!(roleManager.RoleExistsAsync("Student").Result))
            {
                roleManager.CreateAsync(new IdentityRole { Id = "2", Name = "Student" });
            }
        }

    }
}
