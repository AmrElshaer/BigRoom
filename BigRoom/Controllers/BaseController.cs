using BigRoom.Repository.Contexts;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace BigRoom.Controllers
{
    public class BaseController: Controller
    {
		protected  IUserManager UserManager=> userManager!=null?userManager: HttpContext.RequestServices.GetService<IUserManager>();
        private IUserManager userManager;
        protected async Task<string> GetCurrentUserId()
		{
			ApplicationUser usr = await GetCurrentUserAsync();
			return usr?.Id;
		}
        protected async Task<ApplicationUser> GetCurrentUserAsync() =>await UserManager.GetApplicationUserAsync(HttpContext.User);
		protected async Task<string> GetRoleAsync() => await UserManager.GetRole(User);
	}
}
