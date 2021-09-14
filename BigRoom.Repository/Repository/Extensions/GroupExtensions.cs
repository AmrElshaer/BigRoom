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
            return (await repo.GetGroupByCodeAsync(codeJoin))!=null;
        }
        public static async Task<Group> GetGroupByCodeAsync(this IRepositoryAsync<Group> repo,string codeJoin)
        {
            return await repo.Entities.Include(a => a.Groups)
                .FirstOrDefaultAsync(a => a.CodeJion == codeJoin);
        }
        public static async Task<Group> GroupDetailsByIdAsync(this IRepositoryAsync<Group> repo, int id)
        {
            return await repo.Entities.Include(a => a.Groups).ThenInclude(a => a.UserProfile.ApplicationUser).Include(a => a.GroupPermissions)
                .Include(a => a.Admin).FirstOrDefaultAsync(a => a.Id == id);
        }
        public static async Task<bool> UniquesNameAsync(this IRepositoryAsync<Group> repo, string name)
        {
           return (await repo.Entities.FirstOrDefaultAsync(a => a.Name.ToLower().Contains(name.ToLower())))!=null;
        }
    }
}
