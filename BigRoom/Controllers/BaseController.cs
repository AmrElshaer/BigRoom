using BigRoom.Repository.Contexts;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    public class BaseController: Controller
    {
		protected readonly IUserManager UserManager;

		public BaseController(IUserManager userManager)
		{
			UserManager = userManager;
		}

		protected async Task<string> GetCurrentUserId()
		{
			ApplicationUser usr = await GetCurrentUserAsync();
			return usr?.Id;
		}
        protected async Task<ApplicationUser> GetCurrentUserAsync() =>await UserManager.GetApplicationUserAsync(HttpContext.User);
		protected async Task<string> GetRoleAsync() => await UserManager.GetRole(User);
	}
}
