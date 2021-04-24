using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigRoom.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private readonly IUserProfileService profileService;

        public StudentController(IUserProfileService profileService)
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