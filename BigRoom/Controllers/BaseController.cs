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
            const string userId = "UserId";
            var id=  HttpContext.Session.GetInt32(userId);
            if (id is null)
            {
                id = (await UserProfileService.GetUserProfileIdAsync((await GetCurrentUserAsync()).Id));
                HttpContext.Session.SetInt32(userId, id.Value);
            }
            return id.Value;
        }
        protected async Task<ApplicationUser> GetCurrentUserAsync() => await UserManager.GetApplicationUserAsync(HttpContext.User.Identity.Name);
	}
}
