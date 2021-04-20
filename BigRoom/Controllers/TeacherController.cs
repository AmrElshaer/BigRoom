using BigRoom.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly IUserProfileService profileService;

        public TeacherController(IUserProfileService profileService, IUserManager userManager) : base(userManager)
        {
            this.profileService = profileService;
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var user = await profileService.GetUserProfileAsync(await GetCurrentUserId());
            return View(user);
        }
    }
}