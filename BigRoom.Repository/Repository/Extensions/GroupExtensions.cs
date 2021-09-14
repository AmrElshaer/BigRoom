using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository.Extensions
{
    public static class GroupExtensions
    {
        public static async Task<bool> IsExistAsync(this IRepositoryAsync<Group> repo, string codeJoin)
        {
            var group = await repo.GetGroupByCodeAsync(codeJoin);
            return group != null ? true : false;
        }
        public static async Task<Group> GetGroupByCodeAsync(this IRepositoryAsync<Group> repo,string codeJoin)
        {
            var group = await repo.Entities.Include(a => a.Groups).FirstOrDefaultAsync(a => a.CodeJion == codeJoin);
            return group;
        }
        public static async Task<Group> GroupDetailsByIdAsync(this IRepositoryAsync<Group> repo, int id)
        {
            var group = await repo.Entities.Include(a => a.Groups).ThenInclude(a => a.UserProfile.ApplicationUser).Include(a => a.GroupPermissions)
                .Include(a => a.Admin).FirstOrDefaultAsync(a => a.Id == id);
            return group;
        }
        public static async Task<bool> UniquesNameAsync(this IRepositoryAsync<Group> repo, string name)
        {
            var user = await repo.Entities.FirstOrDefaultAsync(a => a.Name.ToLower().Contains(name.ToLower()));
            return user != null ? false : true;
        }
    }
}
