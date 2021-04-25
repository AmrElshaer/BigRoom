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
		protected IUserProfileService UserProfileService => HttpContext.RequestServices.GetService<IUserProfileService>();
		private IUserManager userManager;
		protected async Task<int> GetUserProfileId()
        {
			return (await UserProfileService.GetUserProfileIdAsync((await  GetCurrentUserAsync()).Id));
        }
        protected async Task<ApplicationUser> GetCurrentUserAsync() =>await UserManager.GetApplicationUserAsync(HttpContext.User);
	}
}
