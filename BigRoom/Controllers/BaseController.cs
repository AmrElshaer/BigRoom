using BigRoom.Repository.Contexts;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace BigRoom.Controllers
{
    public class BaseController: Controller
    {
		protected  IUserManager UserManager=>HttpContext.RequestServices.GetService<IUserManager>();
		protected IUserProfileService UserProfileService => HttpContext.RequestServices.GetService<IUserProfileService>();
		protected async Task<int> GetUserProfileId()
        {
            var identityId = (await GetCurrentUserAsync()).Id;
            return (await UserProfileService.GetFirstAsync(a => a.UserId == identityId)).Id;
        }
        protected async Task<ApplicationUser> GetCurrentUserAsync() => await UserManager.GetApplicationUserAsync(HttpContext.User.Identity.Name);
	}
}
